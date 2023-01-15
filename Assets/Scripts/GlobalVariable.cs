using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    public bool firstRender;
    public int bossCount;

    private void Start() 
    {
        GameObject.DontDestroyOnLoad(this);
        firstRender = true;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("Boss Count: " + bossCount);
        }
    }

    public void DoneRendering()
    {
        Debug.Log("ASDSADASD");
        firstRender = false;
    }
}
