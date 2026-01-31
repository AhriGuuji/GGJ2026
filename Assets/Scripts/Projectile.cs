using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1.0f;
    
    private void Start()
    {
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        YieldInstruction wfs = new WaitForSeconds(lifeTime);

        yield return wfs;
        
        gameObject.SetActive(false);
    }
}