using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public bool isPaused = false;
    
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            PauseGame();
        }
    }

    void PauseGame() {
        if (isPaused) {
            Time.timeScale = 0;
        }
        else 
        {
            Time.timeScale = 1;
        }
    }
    
}
