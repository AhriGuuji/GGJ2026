using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndCheck : MonoBehaviour
{
    [SerializeField] private Boss boss;
    [SerializeField] private string endScene = "EndScene";
    private bool _end;

    private void Update()
    {
        if (!boss) return;

        if (!boss.IsAlive && !_end)
            StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        _end = true;

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(endScene);
    }
}