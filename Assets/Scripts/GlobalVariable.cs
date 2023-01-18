using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    public static bool firstRender;
    public static bool firstRoom;
    public static int bossCount;

    private void Start() 
    {
        firstRender = true;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            // Debug.Log("Boss Count: " + bossCount/2);
        }
    }

    public void DoneRendering()
    {
        firstRender = false;
    }
}
