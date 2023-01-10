using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject enemyObj;

    bool onDamageCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "EnemyHurtBox")
        {
            enemyObj = col.gameObject;
            StartCoroutine("DamageEnemy");
        }
    }

    IEnumerator DamageEnemy()
    {
        if(!onDamageCooldown){
            onDamageCooldown = true;
            enemyObj.GetComponentInParent<EnemyHealth>().TakeDamage(2f);
            yield return new WaitForSeconds(2f);
            
            onDamageCooldown = false;
        }
    }
}
