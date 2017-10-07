using UnityEngine;
using System.Collections;

public class FPH_CircleChecker : MonoBehaviour {

	public GameObject obj;
	public FPH_CircleInteract rotCheck;


	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject == obj){
			rotCheck.currentCircle++;
		}
	}
	void OnTriggerExit(Collider col){
		if(col.gameObject == obj){
			rotCheck.currentCircle--;
		}
	}
}
