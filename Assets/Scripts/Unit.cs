using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	// public Transform target;
	public float speed = 3f;
	Vector3[] path;
	int targetIndex = 0;

	public GameObject drop;
	public GameObject player;
	Animator anim;

	public bool needPath = true;
	bool isAlive = true;

	public GameObject gate;

	EnemyHealth enemyHP;

	public ParticleSystem hit;
	public ParticleSystem die;

	void Start() {
		anim = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		enemyHP = GetComponent<EnemyHealth>();
		// PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
	}

	void Update() {
		// if (Input.GetKeyDown("r"))
        // {
		// 	PathRequestManager.RequestPath(transform.position, player.transform.position, OnPathFound);
        // }
		if (enemyHP.currentHP <= 0)
        {
			isAlive = false;
			StartCoroutine("Died");
        }
		if (path != null && needPath) {
			if (targetIndex >= path.Length) {
				StartCoroutine("GetNewPath");
			}
		}
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful && isAlive) {
			path = newPath;
			targetIndex = 0;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}


	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];
		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
                    path = new Vector3[0];
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			Vector3 targetPostition = new Vector3( currentWaypoint.x, this.transform.position.y, currentWaypoint.z);
			transform.LookAt( targetPostition );
			transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
			yield return null;
		}
	}

	public IEnumerator GetNewPath() {
		yield return new WaitForSeconds (.5f);
		PathRequestManager.RequestPath(transform.position, player.transform.position, OnPathFound);
	}
	
	public void StopPathFind() {
		needPath = false;
		path = null;
	}

	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.white;
				Gizmos.DrawCube(path[i], new Vector3(0.5f, 0.5f, 0.5f));

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}

	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            needPath = true;
			StartCoroutine("GetNewPath");
        }
		if(col.gameObject.tag == "Gate")
		{
			gate = col.gameObject;
		}
    }

	void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            needPath = true;
			StartCoroutine("GetNewPath");
        }
    }

	public void Attacking()
	{
		if(isAlive)
			StartCoroutine("Attack");
	}

	IEnumerator Attack()
	{
		transform.LookAt( player.transform );
		anim.SetBool("isAttacking", true);
		yield return new WaitForSeconds(.1f);
		anim.SetBool("isAttacking", false);
	}
	
	public IEnumerator AttackSpecial()
	{
		if(isAlive) {
			transform.LookAt( player.transform );
			anim.SetBool("isAttacking", true);
			yield return new WaitForSeconds(.1f);
			anim.SetBool("isAttacking", false);
		}
	}

	public void Hurt()
	{
		StartCoroutine("Attacked");
	}

	IEnumerator Attacked()
	{
		transform.LookAt( player.transform );
		anim.SetBool("isAttacked", true);
		yield return new WaitForSeconds(.1f);
		anim.SetBool("isAttacked", false);
	}

	IEnumerator Died()
	{
		hit.Play();
		die.Play();
		yield return new WaitForSeconds(3f);
		gate.SetActive(false);
		if(drop != null) {
			Instantiate(drop, transform.position, transform.rotation);
		}
		Destroy(this.gameObject);
	}
}
