using SmallHedge.SoundManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private string shoot = "Interact";
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float projectileForce;
    [SerializeField] private float forceMultiplier;
    [SerializeField] private float shootCountdown = 1.0f;
    public bool CanShoot { get; set; }
    private InputAction _shoot;
    private PlayerMovement _player;
    private float _timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shoot = InputSystem.actions.FindAction(shoot);
        _player = GetComponent<PlayerMovement>();
        CanShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_shoot.WasPressedThisFrame() && CanShoot && _timer > shootCountdown)
        {
            OnShoot();
            SoundManager.PlaySound(SoundType.SHOOT);
        }
        
        _timer += Time.deltaTime;
    }

    private void OnShoot()
    {
        float direction = _player.transform.right.x;
        
        GameObject bullet = Instantiate(projectile, shootPoint.position,  Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        float force = projectileForce * forceMultiplier;
        rb.AddForce(Vector2.right * (direction * force), ForceMode2D.Impulse);
        
        _timer = 0.0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // Draw the potential spawn circle around the shoot point
        Gizmos.DrawWireSphere(shootPoint.position, 0.5f);
        
    }
}