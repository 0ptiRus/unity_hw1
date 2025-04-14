using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenu : MonoBehaviour
{
    bool isPaused = false;

    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            isPaused = TogglePause();
            PauseMenu.SetActive(isPaused);
        }
    }
    
	
    bool TogglePause()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Debug.Log("Paused");
            return(false);
        }
        Time.timeScale = 0f;
        Debug.Log("Unpaused");
        return(true);
    }
}
