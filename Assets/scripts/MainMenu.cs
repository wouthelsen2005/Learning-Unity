using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    
    public void PlayGame()
    {
        
        SceneManager.LoadSceneAsync("Defender2");
    }
    public void SettingsMenu()
    {
        
        SceneManager.LoadSceneAsync("OptionsMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpgradeMenu()
    {
        SceneManager.LoadSceneAsync("UpgradeMenu");
    }
        
}
