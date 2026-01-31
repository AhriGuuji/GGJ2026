using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    [SerializeField] private List<Attack>  attacks;
    [SerializeField] private Vector2 cooldownBreak;
    private int _health;
    [SerializeField] private int maxHealth = 5;
    private bool _isAlive;  
    
    private void Start()
    {
        _isAlive = true;
        _health = maxHealth;
        
        StartCoroutine(AttackAction());
    }

    private IEnumerator AttackAction()
    {
        while (true)
        {
            if (!_isAlive) yield break;
            
            YieldInstruction wfs = new WaitForSeconds(Random.Range(cooldownBreak.x, cooldownBreak.y));

            attacks[Random.Range(0, attacks.Count)].DoAttack();
    
            yield return wfs;
        }
    }

    private void TakeDamage()
    {
        _health -= 1;
        if (_health <= 0)
        {
            _isAlive = false;
            //PLAY DEATH ANIMATION
            
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.SetActive(false);
    }
}
