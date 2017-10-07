using UnityEngine;
using System.Collections;

public class FPH_PlayDialogOnInteract : MonoBehaviour {

	// This script plays a dialog when the player interact with this object

	public FPH_DialogCreator dialog;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Talk(){
		if(dialog != null && !FPH_DialogManager.isEnabled){
			dialog.SendMessage("Play");
			FPH_DialogManager.currentDialog = gameObject;
		}
	}
}