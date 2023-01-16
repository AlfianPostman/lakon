using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{
    public GameObject Obj;
    public float damage = 2f;
    PlayerHealth hp;

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
        hp.TakeDamage(damage);
        yield return new WaitForSeconds(.1f);
    }
}
