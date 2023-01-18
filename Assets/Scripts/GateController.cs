using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player") {
            anim.SetBool("isOpen", false);
        }
    }
}
