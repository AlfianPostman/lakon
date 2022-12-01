using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBox : MonoBehaviour
{
    GameObject Platform;
    Renderer mr;
    
    void Start()
    {
        Platform = this.transform.parent.gameObject;
        mr = Platform.GetComponent<Renderer>();

        mr.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            mr.enabled = true;
        }
    }
}
