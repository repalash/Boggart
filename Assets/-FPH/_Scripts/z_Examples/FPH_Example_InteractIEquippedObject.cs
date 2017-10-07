using UnityEngine;
using System.Collections;

public class FPH_Example_InteractIEquippedObject : MonoBehaviour {

	public string neededObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Interact(){
		if(FPH_InventoryManager.equippedItem == neededObj){
			StartCoroutine("HaveObject");
		}
		else{
			StartCoroutine("NotHaveObject");
		}
	}
	
	IEnumerator HaveObject(){
		FPH_LanguageManager.static_observeTextMesh.text = neededObj + " has been equipped.";
		
		yield return new WaitForSeconds(2.0f);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
	}
	IEnumerator NotHaveObject(){
		FPH_LanguageManager.static_observeTextMesh.text = neededObj + " has not been equipped.";
		
		yield return new WaitForSeconds(2.0f);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
	}
}