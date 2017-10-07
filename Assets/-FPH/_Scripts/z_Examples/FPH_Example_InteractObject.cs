using UnityEngine;
using System.Collections;

public class FPH_Example_InteractObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Interact(){
		StartCoroutine("PrivateInteract");
	}

	IEnumerator PrivateInteract(){
		FPH_LanguageManager.static_observeTextMesh.text = "Interacted with object: " + gameObject.name;

		yield return new WaitForSeconds(2.0f);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
	}
}