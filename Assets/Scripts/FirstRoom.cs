using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour
{
    public GameObject gate;

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Gate")
		{
			gate = col.gameObject;
    		gate.SetActive(false);
		}
    }
}
