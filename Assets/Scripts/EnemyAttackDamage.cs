using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{
    public GameObject Obj;
    PlayerHealth hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Obj = col.gameObject;
            hp = Obj.GetComponent<PlayerHealth>();
            Debug.Log(hp);
            StartCoroutine("DamageEnemy");
        }
    }

    IEnumerator DamageEnemy()
    {
        hp.TakeDamage(2f);
        yield return new WaitForSeconds(.1f);
    }
}
