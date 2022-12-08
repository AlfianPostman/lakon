using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ObjectPrefab;
    public GameObject[] Object;

    void Start()
    {
        Object = new GameObject[ObjectPrefab.Length];
        for (int i = 0; i < ObjectPrefab.Length; i++)
        {
            Object[i] = Instantiate(ObjectPrefab[i], transform.position, transform.rotation, this.gameObject.transform.parent);
        }   
    }
}