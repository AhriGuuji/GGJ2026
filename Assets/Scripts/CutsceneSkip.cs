using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneSkip : MonoBehaviour
{
    [SerializeField] private string level;

    private void Update()
    {
        if (Input.anyKeyDown)
            SceneManager.LoadScene(level);
    }
}
