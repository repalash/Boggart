using UnityEngine;
using System.Collections;

public class FPH_DoorObject_Drag : MonoBehaviour {

	/*
	 * This script is for doors which can be opened dragging on the screen
	 */

	public float factor = 2.0f; // How fast will be the movement
	public float minRot = 0.0f;
	public float maxRot = 90.0f;


	public string[] observeKind = new string[] {"Normal", "Closeup"};
	public int observeInt = 0; // this variable is used inside of the Editor script
	
	public float secToOserve = 1.3f; // After this amount of seconds the text will reset
	
	public GameObject inGameCamera;
	public GameObject closeupCamera;
	
	public bool removeItemWhenUsed;
	public string hasBeenUnlockedKey;
	
	public bool canBeObserved;
	public AudioClip lockedSound;
	
	public string observMessage_English;
	public string observMessage_Italian;
	public string observMessage_Spanish;
	public string observMessage_German;
	public string observMessage_French;
	public string observMessage_Japanese;
	public string observMessage_Chinese;
	public string observMessage_Russian;
	
	public string lockedMessage_English;
	public string lockedMessage_Italian;
	public string lockedMessage_Spanish;
	public string lockedMessage_German;
	public string lockedMessage_French;
	public string lockedMessage_Japanese;
	public string lockedMessage_Chinese;
	public string lockedMessage_Russian;
	
	public string wrongItemMessage_English;
	public string wrongItemMessage_Italian;
	public string wrongItemMessage_Spanish;
	public string wrongItemMessage_German;
	public string wrongItemMessage_French;
	public string wrongItemMessage_Japanese;
	public string wrongItemMessage_Chinese;
	public string wrongItemMessage_Russian;


	public int doorType = 0;
	/*
	 * A dor can be:
	 * " Normally Open " - The door is always open
	 * " Locked " - The door is always locked and CAN'T be opened
	 * " Need Equipped Object " - The door is locked but can be opened if the player equip an object
	 * " Need Activated Key " - The door is locked but can be opened if a PlayerPres key is " 1 " which means true
	 */
	public string[] doorTypeArray = new string[] {"Normally Open", "Locked", "Need Equipped Object", "Need Activated Key"};
	public string neededObject_Name;
	public string neededKey;


	private Vector3 startRot;
	private float startPlayerRot;
	private float currRot;
	private float playerRot;
	private float delta = 0;
	private Transform playerTransform;
	private bool canbeOpen;
	public float openDirection;
	private bool hasBeenUnlocked;


	void Start(){
		openDirection = -1.0f;

		playerTransform = GameObject.FindWithTag("Player").transform;
		startRot = this.gameObject.GetComponent<Transform>().eulerAngles;
		delta = 0;

		hasBeenUnlocked = FPH_ControlManager.LoadBool(hasBeenUnlockedKey);
		if(hasBeenUnlocked){
			doorType = 0;
		}
	}

	void Update(){
		if(doorType == 0){
			canbeOpen = true;
		}
		if(doorType == 1){
			canbeOpen = false;
		}
		if(doorType == 2){
			if(FPH_InventoryManager.equippedItem != neededObject_Name && FPH_InventoryManager.equippedItem != "" && FPH_InventoryManager.equippedItem != " "){
				canbeOpen = false;
			}
			if(FPH_InventoryManager.equippedItem == "" || FPH_InventoryManager.equippedItem == " "){
				canbeOpen = false;
			}
			if(FPH_InventoryManager.equippedItem == neededObject_Name){
				canbeOpen = true;
			}
		}
		if(doorType == 3){
			bool boolValue = FPH_ControlManager.LoadBool(neededKey);
			if(boolValue){
				canbeOpen = true;
			}
			else{
				canbeOpen = false;
			}
		}
	}
	
	public void OnMouseDown(){
		if(canbeOpen){
			startPlayerRot = playerTransform.eulerAngles.y;
		}
	}

	public void OnMouseUp(){
		if(doorType == 1){
			StartCoroutine("PrivateLocked");
		}
		if(doorType == 2){
			if(FPH_InventoryManager.equippedItem != neededObject_Name && FPH_InventoryManager.equippedItem != "" && FPH_InventoryManager.equippedItem != " "){
				StartCoroutine("PrivateWrongItem");
			}
			if(FPH_InventoryManager.equippedItem == "" || FPH_InventoryManager.equippedItem == " "){
				StartCoroutine("PrivateLocked");
			}
		}
		if(doorType == 3 && !canbeOpen){
			StartCoroutine("PrivateLocked");
		}
		
		if(canbeOpen){
			startRot.y = currRot;
			delta = 0;

			if(FPH_InventoryManager.equippedItem == neededObject_Name && !hasBeenUnlocked){
				hasBeenUnlocked = true;
				FPH_ControlManager.SaveBool(hasBeenUnlockedKey, hasBeenUnlocked);
				doorType = 0;
				
				//Afte we used the item we unequip it
				FPH_InventoryManager.equippedItem = "";
				FPH_InventoryManager.equippedItem_Index = -1;
				if(removeItemWhenUsed){
					FPH_InventoryManager.RemoveInventoryItem(FPH_InventoryManager.equippedItem_Index);
					FPH_InventoryManager.SaveInventory();
				}
			}
		}
	}

	void OnMouseDrag(){
		if(canbeOpen){
			playerRot = playerTransform.eulerAngles.y;
			delta = (playerRot - startPlayerRot) * openDirection; // openDirection si important or player rotation will be the inverse of door rot
			currRot = (startRot.y + (delta * factor));
			currRot = Mathf.Clamp(currRot, minRot, maxRot); // door rotation can't be bigger or smaller than min and max rot
			transform.eulerAngles = new Vector3(startRot.x, currRot, startRot.z);

			if(FPH_InventoryManager.equippedItem == neededObject_Name && !hasBeenUnlocked){
				hasBeenUnlocked = true;
				FPH_ControlManager.SaveBool(hasBeenUnlockedKey, hasBeenUnlocked);
				doorType = 0;
				
				//Afte we used the item we unequip it
				FPH_InventoryManager.equippedItem = "";
				FPH_InventoryManager.equippedItem_Index = -1;
				if(removeItemWhenUsed){
					FPH_InventoryManager.RemoveInventoryItem(FPH_InventoryManager.equippedItem_Index);
					FPH_InventoryManager.SaveInventory();
				}
			}
		}
	}
	
	public void Observe(){
		if(observeInt == 0){
			StartCoroutine("PrivateObserve_Normal");
		}
		if(observeInt == 1){
			StartCoroutine("PrivateObserve_Closeup");
		}
	}
	
	IEnumerator PrivateLocked(){
		FPH_LanguageManager.static_observeTextMesh.text = "";
		if(lockedSound){
			GetComponent<AudioSource>().PlayOneShot(lockedSound);
		}
		
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_LanguageManager.static_observeTextMesh.text = lockedMessage_English;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = lockedMessage_Italian;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = lockedMessage_Spanish;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = lockedMessage_German;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = lockedMessage_French;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = lockedMessage_Japanese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = lockedMessage_Chinese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = lockedMessage_Russian;
		}
		
		yield return new WaitForSeconds(secToOserve);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
	}
	
	IEnumerator PrivateWrongItem(){
		FPH_LanguageManager.static_observeTextMesh.text = "";
		if(lockedSound){
			GetComponent<AudioSource>().PlayOneShot(lockedSound);
		}
		
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_LanguageManager.static_observeTextMesh.text = wrongItemMessage_English;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = wrongItemMessage_Italian;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = wrongItemMessage_Spanish;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = wrongItemMessage_German;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = wrongItemMessage_French;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = wrongItemMessage_Japanese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = wrongItemMessage_Chinese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = wrongItemMessage_Russian;
		}
		
		yield return new WaitForSeconds(secToOserve);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
	}
	
	IEnumerator PrivateObserve_Normal(){
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){ // If language is ....
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_English; // Set this thext
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Italian;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Spanish;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_German;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_French;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Japanese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Chinese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Russian;
		}
		
		yield return new WaitForSeconds(secToOserve); // After " secToOserve " ...
		
		FPH_LanguageManager.static_observeTextMesh.text = ""; // Reset the text
	}

	/*
	 * We toggle the cameras and  show a text, everything will be reset
	 * after " secToOserve "
	 */
	IEnumerator PrivateObserve_Closeup(){
		inGameCamera.SetActive(false);
		closeupCamera.SetActive(true);
		FPH_ControlManager.canBeControlled = false;
		
		yield return new WaitForSeconds(0.1f);

		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_English;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Italian;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Spanish;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_German;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_French;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Japanese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Chinese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Russian;
		}
		
		yield return new WaitForSeconds(secToOserve);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
		
		yield return new WaitForSeconds(0.3f);
		
		inGameCamera.SetActive(true);
		closeupCamera.SetActive(false);
		FPH_ControlManager.canBeControlled = true;
	}
}