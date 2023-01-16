using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    string parentName = "";
    public bool rendered = false;
    RenderBox rb;

    public GameObject[] ObjectPrefab;
    GameObject[] Object;

    public int numberOfBosses = 3;

    public GameObject Enemy;
    public GameObject Boss;

    public GameObject gbObj;
    public GlobalVariable gb;

    void Awake()
    {
        rb = GetComponent<RenderBox>();
        gb = gbObj.GetComponent<GlobalVariable>();

        Object = new GameObject[ObjectPrefab.Length];
        for (int i = 0; i < ObjectPrefab.Length; i++)
        {
            Object[i] = Instantiate(ObjectPrefab[i], transform.position, transform.rotation);
        }
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