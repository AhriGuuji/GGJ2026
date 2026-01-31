using System;
using System.Collections;
using SmallHedge.SoundManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Character
{
    [Header("Input Settings")]
    [SerializeField] private string moveInput = "Move";
    [SerializeField] private string jumpInput = "Jump";
    [SerializeField] private string jumpReleaseInput = "JumpRelease";
    [SerializeField] private string dodgeInput = "Dodge";

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 12f;
    [SerializeField][Range(0.0f, 1.0f)] private float jumpCutMultiplier;
    [SerializeField] private float jumpBufferTime;
    [SerializeField] private float jumpCoyoteTime;
    [SerializeField] private float fallGravityMultiplier;

    [Header("Dodge Settings")]
    [SerializeField] private float dodgeForce;
    [SerializeField] private float imunityTime;

    [Header("Settings")]
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private Animator playerAnimator;
    public bool CanJump { get; set; }
    private float _lastGroundedTime;
    private float _lastJumpTime;
    private bool _isJumping;
    private float _gravityScale;
    
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _jumpReleaseAction;
    private InputAction _dodgeAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        _gravityScale = rb.gravityScale;
        CanJump = true;

        _moveAction = InputSystem.actions.FindAction(moveInput);
        _jumpAction = InputSystem.actions.FindAction(jumpInput);
        _jumpReleaseAction = InputSystem.actions.FindAction(jumpReleaseInput);
        _dodgeAction = InputSystem.actions.FindAction(dodgeInput);
    }

    // Update is called once per frame
    protected override void Update()
    {
        playerDir = _moveAction.ReadValue<Vector2>();
        ComputeGroundState();

        #region Timer and Resets
        _lastGroundedTime -= Time.deltaTime;
        _lastJumpTime -= Time.deltaTime;

        if (rb.linearVelocityY == 0) _isJumping = false;
        #endregion

        base.Update();
        
        playerAnimator.SetFloat("VelocityX", Mathf.Abs(rb.linearVelocityX));
    }

    protected override void FixedUpdate()
    {
        #region Jump
        // Handle jump cooldown and jump execution
        if (_lastGroundedTime > 0 && !_isJumping && _jumpAction.WasPressedThisFrame() && CanJump)
        {
            Jump();
            SoundManager.PlaySound(SoundType.JUMP);
        }

        // Handle gravity scaling
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = _gravityScale * fallGravityMultiplier;
        }
        else
        {
            rb.gravityScale = _gravityScale;
        }
        #endregion

        base.FixedUpdate();
    }

    private void Jump()
    {
        //apply force, using impluse force mode
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _lastGroundedTime = 0;
        _lastJumpTime = 0;
        _isJumping = true;
    }

    public void Dodge()
    {
        Debug.Log("hey listen");
        playerCollider.enabled = false;
        rb.AddForce(Vector2.right * GetDirection() * dodgeForce, ForceMode2D.Impulse);
        StartCoroutine(OnDodge());
    }

    private IEnumerator OnDodge()
    {
        yield return new WaitForSeconds(imunityTime);

        playerCollider.enabled = true;
    }

    public void OnJump() => _lastJumpTime = jumpBufferTime;

    public void OnJumpUp()
    {
        if (rb.linearVelocityY > 0 && _isJumping)
        {
            //reduce current y velocity by amount (0 to 1)
            rb.AddForce(Vector2.down * rb.linearVelocityY * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
        }
        _lastJumpTime = 0;
    }

    public override float GetDirection()
    {
        return playerDir.x;
    }

    protected override void ComputeGroundState()
    {
        base.ComputeGroundState();

        if (isGrounded)
        {
            _lastGroundedTime = jumpCoyoteTime;
        }
    }
}