using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {

	Vector3 initLocation;
	Vector3 gazePoint;
	Quaternion initRotation;
	Animation animation;
	Rigidbody rigidBody;
	GameObject player;
	bool isDead = true;
	// Use this for initialization
	void Start () {
		initLocation = transform.position;
		initRotation = transform.rotation;
		animation = GetComponent<Animation> ();
		rigidBody = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		Spawn ();
		StartCoroutine ("RandomAttack");
		StartCoroutine ("JumpRoutine");
		StartCoroutine ("KillRoutine");
		StartCoroutine ("WatchPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Vector3 direction = gazePoint - transform.position;
		Quaternion toRotation = Quaternion.FromToRotation (transform.forward, direction);
		transform.rotation = Quaternion.Lerp (transform.rotation, toRotation, Time.fixedDeltaTime);
	}

	public void Spawn() {
		ResetLocation ();
		rigidBody.isKinematic = false;
		isDead = false ;
	}

	public void ResetLocation(){
		transform.position = initLocation;
		transform.rotation = initRotation;
		rigidBody.isKinematic = true;
		isDead = true;
		MakeWalk ();
	}

	public void MakeWalk(){
		animation.Play ("walk");
		StartCoroutine ("StopWalking");
	}

	IEnumerator StopWalking(){
		yield return new WaitForSeconds(5f);
		animation.CrossFade ("idle", 0.5f);
	}

	IEnumerator RandomAttack(){
		yield return new WaitForSeconds (Random.Range(2f,5f));
		while (true) {
			yield return new WaitForSeconds (Random.Range(3f,6f));
			if(!isDead) animation.Blend ("attack1");
			yield return new WaitForSeconds (Random.Range(2f,5f));
			if(!isDead) animation.Blend ("attack2");
		}
	}

	IEnumerator JumpRoutine(){
		yield return new WaitForSeconds (Random.Range(2f,5f));
		while (true) {
			yield return new WaitForSeconds (Random.Range(4f,9f));
			if(!isDead) animation.Blend ("jump");
		}
	}
		
	IEnumerator KillRoutine(){
		yield return new WaitForSeconds (Random.Range(2f,5f));
		while (true) {
			yield return new WaitForSeconds (Random.Range(5f,20f));
			animation.Play ("death2");
			isDead = true;
			yield return new WaitForSeconds (2.5f);
			Spawn ();
			yield return new WaitForSeconds (7f);
		}
	}

	IEnumerator WatchPlayer(){
		yield return new WaitForSeconds (Random.Range(2f,5f));
		while (true) {
			yield return new WaitForSeconds (Random.Range(2f,3f));
			gazePoint = player.transform.position;
			if(!isDead) animation.CrossFade ("walk");
			yield return new WaitForSeconds (1f);
			if(!isDead) animation.CrossFade ("idle");
		}
	}
}
