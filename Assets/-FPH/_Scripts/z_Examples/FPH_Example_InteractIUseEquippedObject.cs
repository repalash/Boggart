using UnityEngine;
using System.Collections;

public class FPH_Example_InteractIUseEquippedObject : MonoBehaviour {

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
		FPH_InventoryManager.RemoveInventoryItem(FPH_InventoryManager.equippedItem_Index);
		FPH_InventoryManager.equippedItem = "";
		FPH_InventoryManager.equippedItem_Index = -1;
		FPH_LanguageManager.static_observeTextMesh.text = neededObj + " has been used and removed from inventory.";
		
		yield return new WaitForSeconds(2.0f);

		FPH_LanguageManager.static_observeTextMesh.text = "";
	}
	IEnumerator NotHaveObject(){
		FPH_LanguageManager.static_observeTextMesh.text = neededObj + " has not been equipped.";
		
		yield return new WaitForSeconds(2.0f);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
	}
}