using UnityEngine;
using UnityEngine.InputSystem;

public class Mask : MonoBehaviour
{
    [SerializeField] private Sprite playerSpriteNoMask;
    [SerializeField] private Sprite playerSpriteWithMask;
    [SerializeField] private string input = "PutMask";
    public bool HasMask { get; private set; }
    private InputAction _putMask;
    private SpriteRenderer _playerSprite;
    private PlayerMovement _playerMovement;
    private Shoot _playerShoot;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HasMask = false;
        _putMask = InputSystem.actions.FindAction(input);
        _playerSprite = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShoot = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasMask && _putMask.WasPressedThisFrame())
        {
            HasMask = false;
            _playerMovement.CanJump = true;
            _playerShoot.CanShoot = false;
            _playerSprite.sprite = playerSpriteNoMask;
        }
        else if (!HasMask && _putMask.WasPressedThisFrame())
        {
            HasMask = true;
            _playerMovement.CanJump = false;
            _playerShoot.CanShoot = true;
            _playerSprite.sprite = playerSpriteWithMask;
        }
    }
}
