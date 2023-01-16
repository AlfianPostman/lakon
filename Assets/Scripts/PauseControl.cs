using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseScreen;
    
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void PauseGame() {
        isPaused = !isPaused;

        if (isPaused) {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }
    
}
