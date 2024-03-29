using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Unit unit;
    bool attackCooldown = false;

    void Start() {
        unit = GetComponentInParent<Unit>();
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            unit.StopPathFind();
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            unit.StopPathFind();
            StartCoroutine("Attack");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            unit.StartCoroutine("GetNewPath");
        }
    }

    IEnumerator Attack()
    {
        if(!attackCooldown) {
            yield return new WaitForSeconds(.3f);
            unit.Attacking();
            attackCooldown = true;
            yield return new WaitForSeconds(1f);
            attackCooldown = false;
        }
    }

    IEnumerator AttackFireBall()
    {
        if(!attackCooldown) {
            yield return new WaitForSeconds(.5f);
            StartCoroutine("unit.AttackSpecial");
            attackCooldown = true;
            yield return new WaitForSeconds(1f);
            attackCooldown = false;
        }
    }
}
