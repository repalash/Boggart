using UnityEngine;
using System.Collections;

public class FPH_PlayDialogTrigger : MonoBehaviour {

	/*
	 * This script plays a dialog when the player 
	 * enter inside of object trigger.
	 */

	public FPH_DialogCreator dialog;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(dialog != null && !FPH_DialogManager.isEnabled){
				dialog.SendMessage("Play");
				FPH_DialogManager.currentDialog = gameObject;
			}
		}
	}
	
	void OnTriggerStay(Collider col){
		if(col.gameObject.tag == "Player"){
			if(dialog != null && !FPH_DialogManager.isEnabled){
				dialog.SendMessage("Play");
				FPH_DialogManager.currentDialog = gameObject;
			}
		}
	}
}
