using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    bool isTaking = false;
    public Animator anim;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player") {
            StartCoroutine("Taken");
        }
    }

    IEnumerator Taken()
    {
        if(isTaking == false) {
            IngameSceneManager.artifact++;
            isTaking = true;
            anim.Play("ArtifactTaken");

            yield return new WaitForSeconds(2);

            isTaking = false;
            Destroy(this.gameObject);
        }
    }
}
