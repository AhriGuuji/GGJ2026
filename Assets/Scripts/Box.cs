using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerMovement player))
        {
            collision.gameObject.SetActive(false);
        }
        
        //DESTROY ANIMATION
        gameObject.SetActive(false);
    }
}