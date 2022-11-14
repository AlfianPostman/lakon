using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    public float speed = 1;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + offset, speed * Time.deltaTime);
    }
}
