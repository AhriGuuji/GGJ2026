using UnityEngine;
using UnityEngine.SceneManagement;

public class Headbutt : Attack
{
        [SerializeField] private Animator anim;
        
        public override void DoAttack()
        {
                anim.SetTrigger("Attack");
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.transform.TryGetComponent(out PlayerMovement player))
                { 
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
        }
}