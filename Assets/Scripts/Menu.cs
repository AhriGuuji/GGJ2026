using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private string gameScene = "GameScene";
    [SerializeField] private Canvas startMenu;
    [SerializeField] private Canvas exitMenu;
    [SerializeField] private Canvas settingsMenu;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private AudioMixer mixer;

    private void Start()
    {
        ExitExitMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {OpenExitMenu();}
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void OpenExitMenu()
    {
        if (startMenu) startMenu.enabled = false;
        exitMenu.enabled = true;
    }
        
    public void ExitExitMenu()
    {
        if (startMenu) startMenu.enabled = true;
        exitMenu.enabled = false;
    }
        
    public void OpenSettingsMenu()
    {
        if (startMenu) startMenu.enabled = false;
        settingsMenu.enabled = true;
    }
        
    public void ExitSettingsMenu()
    {
        if (startMenu) startMenu.enabled = true;
        settingsMenu.enabled = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SoundValueChange()
    {
        float volume = scrollbar.value;
        if (volume <= 0f)
            volume = 0.1f;
        
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundValue", volume);
    }
}