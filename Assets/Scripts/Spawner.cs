using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    RenderBox rb;

    public GameObject[] ObjectPrefab;
    GameObject[] Object;

    public GameObject[] RenderOnCollisions;
    GameObject[] RenderOnCollision;

    void Awake()
    {
        Object = new GameObject[ObjectPrefab.Length];
        for (int i = 0; i < ObjectPrefab.Length; i++)
        {
            Object[i] = Instantiate(ObjectPrefab[i], transform.position, transform.rotation);
            Object[i].transform.parent = this.gameObject.transform.parent;
        }

        rb = GetComponent<RenderBox>();
    }

    public void Render()
    {
        RenderOnCollision = new GameObject[RenderOnCollisions.Length];
        for (int i = 0; i < RenderOnCollisions.Length; i++)
        {
            RenderOnCollision[i] = Instantiate(RenderOnCollisions[i], transform.position, transform.rotation);
            // RenderOnCollision[i].transform.parent = this.gameObject.transform.parent;
        }
    }
}