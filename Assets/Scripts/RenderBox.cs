using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBox : MonoBehaviour
{
    Spawner sp;
    GameObject Platform;
    Renderer mr;
    public bool playerInside = false;
    
    void Start()
    {
        Platform = this.transform.parent.gameObject;
        mr = Platform.GetComponent<Renderer>();
        sp = GetComponent<Spawner>();

        mr.enabled = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            mr.enabled = true;
            Platform.layer = LayerMask.NameToLayer("PlatformRendered");

            sp.Render();
        }
    }
}
