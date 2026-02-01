using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Box : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LifeTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out PlayerMovement player))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(5.0f);
        
        gameObject.SetActive(false);
    }
}