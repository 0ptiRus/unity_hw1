using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public void StartGame() {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame() {
        Application.Quit();
    }

    public void Settings()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}