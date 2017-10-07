using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {

	Vector3 initLocation;
	Quaternion initRotation;
	Animation animation;
	Rigidbody rigidBody;
	GameObject player;
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
		StartCoroutine ("KillRoutine");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn() {
		ResetLocation ();
		rigidBody.isKinematic = false;
	}

	public void ResetLocation(){
		transform.position = initLocation;
		transform.rotation = initRotation;
		rigidBody.isKinematic = true;
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
			animation.Blend ("attack1");
			yield return new WaitForSeconds (Random.Range(2f,5f));
			animation.Blend ("attack2");
		}
	}

	IEnumerator JumpRoutine(){
		yield return new WaitForSeconds (Random.Range(2f,5f));
		while (true) {
			yield return new WaitForSeconds (Random.Range(4f,9f));
			animation.Blend ("jump");
		}
	}
		
	IEnumerator KillRoutine(){
		yield return new WaitForSeconds (Random.Range(2f,5f));
		while (true) {
			yield return new WaitForSeconds (Random.Range(2f,18f));
			animation.Play ("death2");
			yield return new WaitForSeconds (5f);
			Spawn ();
			yield return new WaitForSeconds (7f);
		}
	}

}
