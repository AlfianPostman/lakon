using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    string parentName = "";
    bool rendered = false;
    RenderBox rb;

    public GameObject[] ObjectPrefab;
    GameObject[] Object;

    public GameObject Enemy;
    public GameObject Boss;
    

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
        if(!rendered) {
            parentName = transform.parent.name;

            if(parentName == "T(Clone)" || parentName == "R(Clone)" || parentName == "B(Clone)" || parentName == "L(Clone)") {
                Instantiate(Boss, transform.position, transform.rotation);
            } 
            else {
                Instantiate(Enemy, transform.position, transform.rotation);
            }

            rendered = true;
        }
    }
}