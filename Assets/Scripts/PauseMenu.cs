using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuPanel;

    public GameObject SettingsMenuPanel;
    // Start is called before the first frame update
    public void BackToGame()
    {
        PauseMenuCanvas.SetActive(false);   
        Time.timeScale = 1;
    }

    public void Settings()
    {
        PauseMenuPanel.SetActive(false);
        SettingsMenuPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        PauseMenuPanel.SetActive(true);
        SettingsMenuPanel.SetActive(false);
    }
    public void ExitGame() => Application.Quit();
}
