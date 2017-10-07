using UnityEngine;
using System.Collections;

public class FPH_PlayDialogOnStart : MonoBehaviour {

	// This script plays a dialog when the game start 

	public FPH_DialogCreator dialog;


	// Use this for initialization
	void Start(){
		dialog.SendMessage("Play");
		FPH_DialogManager.currentDialog = gameObject;
	}
}
