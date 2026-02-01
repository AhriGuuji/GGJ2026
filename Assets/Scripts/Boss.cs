using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    [SerializeField] private List<Attack>  attacks;
    [SerializeField] private Vector2 cooldownBreak;
    private int _health;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private Collider2D mainCollider;
    private bool _isAlive;  
    public bool IsAlive => _isAlive;
    [SerializeField] private string endScene;
    [SerializeField] private Animator anim;
    
    private void Start()
    {
        _isAlive = true;
        _health = maxHealth;
        
        StartCoroutine(AttackAction());
    }

    private IEnumerator AttackAction()
    {
        yield return new WaitForSeconds(5.0f);
        
        while (true)
        {
            if (!_isAlive) yield break;
            
            YieldInstruction wfs = new WaitForSeconds(Random.Range(cooldownBreak.x, cooldownBreak.y));

            attacks[Random.Range(0, attacks.Count)].DoAttack();
    
            yield return wfs;
        }
    }

    private IEnumerator Imunity()
    {
        mainCollider.enabled = false;
        
        anim.SetTrigger("Damaged");
        yield return new WaitForSeconds(1.0f);
        
        mainCollider.enabled = true;
    }

    private void TakeDamage()
    {
        _health -= 1;
        StartCoroutine(Imunity());
        
        if (_health <= 0)
        {
            _isAlive = false;
            //PLAY DEATH ANIMATION
            
            gameObject.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Projectile bullet))
            TakeDamage();
    }
}
