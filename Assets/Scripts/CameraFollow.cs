using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = Target.position + offset;
    }
}
