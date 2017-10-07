using UnityEngine;
using System.Collections;

public class FPH_ThirdPersonFixedCamera : MonoBehaviour {

	public float followSmoothness = 600.0f; // Higher value smoother rotation

	private Transform thisTransComp;
	private Transform playerTransform;


	void Awake(){
		thisTransComp = gameObject.GetComponent<Transform>();
		playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	// Use this for initialization
	void Start(){
		playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}

	void LateUpdate(){
		playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();

		if(playerTransform){
			//Look at and dampen the rotation
			Quaternion rotation = Quaternion.LookRotation(playerTransform.position - thisTransComp.position);
			thisTransComp.rotation = Quaternion.Slerp(thisTransComp.rotation, rotation, Time.deltaTime * followSmoothness);
		}
		else{
			Debug.LogWarning("No player found, are you sure that there is a player in this scene? Try to assign the TAG Player to one of your object.");
		}
	}
}