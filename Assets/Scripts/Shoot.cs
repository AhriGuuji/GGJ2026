using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private string shoot = "Interact";
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float projectileForce;
    [SerializeField] private float forceMultiplier;
    private InputAction _shoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _shoot = InputSystem.actions.FindAction(shoot);
    }

    // Update is called once per frame
    void Update()
    {
        if(_shoot.WasPressedThisFrame()) OnShoot();
    }

    public void OnShoot()
    {
        Vector2 direction = projectile.transform.right;
        
        GameObject bullet = Instantiate(projectile, shootPoint);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        float force = projectileForce * forceMultiplier;
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // Draw the potential spawn circle around the shoot point
        Gizmos.DrawWireSphere(shootPoint.position, 0.5f);
        
    }
}