using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private string nextScene;
    private int _inGoal;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player1 || other.gameObject == player2)
        {
            _inGoal++;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player1 || other.gameObject == player2)
        {
            _inGoal--;
        }
    }

    void Update()
    {
        if (_inGoal < 2) return;
        
        if (_inGoal >= 2) SceneManager.LoadScene(nextScene);
    }
}
