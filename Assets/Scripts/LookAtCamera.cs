using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        target = GameObject.FindWithTag("MainCamera").transform;
    }

    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
