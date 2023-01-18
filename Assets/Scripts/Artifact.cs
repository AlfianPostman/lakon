using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    bool isTaking = false;
    public Animator anim;
    GameObject plyr;
    PlayerHealth ph;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player") {
            plyr = col.gameObject;
            ph = plyr.GetComponent<PlayerHealth>();
            StartCoroutine("Taken");
        }
    }

    IEnumerator Taken()
    {
        if(isTaking == false) {
            IngameSceneManager.artifact++;
            ph.currentHP += 5;
            isTaking = true;
            anim.Play("ArtifactTaken");

            yield return new WaitForSeconds(2);

            isTaking = false;
            Destroy(this.gameObject);
        }
    }
}
