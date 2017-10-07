using UnityEngine;
using System.Collections;

public class FPH_InteractComputer : MonoBehaviour {

	public GameObject inGameCamera;
	public GameObject closeupCamera;
	public GameObject interactingCollider;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Interact(){
		FPH_ControlManager.isScreenLocked = false; // Screen.lockCursor = false;
		inGameCamera.SetActive(false);
		closeupCamera.SetActive(true);
		interactingCollider.GetComponent<Collider>().enabled = false;
		FPH_ControlManager.canBeControlled = false;
	}
}
