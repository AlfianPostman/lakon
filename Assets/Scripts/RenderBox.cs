using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBox : MonoBehaviour
{
    Spawner sp;
    GameObject Platform;
    Renderer mr;
    public bool playerInside = false;

    public GameObject gbObj;
    public GlobalVariable gb;
    
    void Start()
    {
        Platform = this.transform.parent.gameObject;
        mr = Platform.GetComponent<Renderer>();
        sp = GetComponent<Spawner>();
        gb = gbObj.GetComponent<GlobalVariable>();

        mr.enabled = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            mr.enabled = true;
            Platform.layer = LayerMask.NameToLayer("PlatformRendered");

            if(GlobalVariable.firstRender) {
                sp.rendered = true;
                gb.DoneRendering();

                return;
            }
            else {
                sp.Render();
            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Environment")
        {
            Debug.Log("asdad");
        }
    }
}
