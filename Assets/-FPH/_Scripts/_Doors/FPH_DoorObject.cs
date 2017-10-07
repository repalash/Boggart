using UnityEngine;
using System.Collections;

public class FPH_DoorObject : MonoBehaviour {
	
	public string[] observeKind = new string[] {"Normal", "Closeup"};
	public int observeInt = 0;

	public float secToOserve = 1.3f;

	public GameObject inGameCamera;
	public GameObject closeupCamera;
	public GameObject interactingCollider;

	public string openDoorAniString = "OpenDoor";
	public string closeDoorAniString = "CloseDoor";

	public bool autoclose;
	public float closeAfter = 3.0f;
	
	public bool removeItemWhenUsed;
	public string hasBeenUnlockedKey;

	public bool canBeObserved;
	public GameObject objectToAnimate;
	public AudioClip lockedSound;
	public AudioClip openSound;
	public AudioClip closeSound;

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

	public bool enterOrEsc = true; //true is enter false is esc
	
	private bool isOpen;
	private bool hasBeenUnlocked;
	
	// Use this for initialization
	void Start(){
		isOpen = false;
		hasBeenUnlocked = FPH_ControlManager.LoadBool(hasBeenUnlockedKey);
		if(hasBeenUnlocked){
			doorType = 0;
		}
	}
	
	// Update is called once per frame
	void Update(){
	}
	
	public void OpenDoor(){
		if(doorType == 0){
			if(!isOpen){
				isOpen = true;
				PrivateOpen();
				return;
			}
			if(isOpen){
				isOpen = false;
				PrivateClose();
				return;
			}
		}
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
			if(FPH_InventoryManager.equippedItem == neededObject_Name){
				PrivateOpen();
			}
		}
		if(doorType == 3){
			bool boolValue = FPH_ControlManager.LoadBool(neededKey);
			if(boolValue){
				PrivateOpen();
			}
			else{
				StartCoroutine("PrivateLocked");
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
	
	
	void PrivateOpen(){
		if(openSound){
			GetComponent<AudioSource>().PlayOneShot(openSound);
		}
		objectToAnimate.GetComponent<Animation>().CrossFade(openDoorAniString);
		
		if(autoclose){
			StartCoroutine("CloseAfterOpen");
		}
		
		if(FPH_InventoryManager.equippedItem == neededObject_Name && !hasBeenUnlocked){
			hasBeenUnlocked = true;
			FPH_ControlManager.SaveBool(hasBeenUnlockedKey, hasBeenUnlocked);
			doorType = 0;
			isOpen = true;
			
			if(removeItemWhenUsed){
				FPH_InventoryManager.RemoveInventoryItem(FPH_InventoryManager.equippedItem_Index);
			}
			//Afte we used the item we unequip it
			FPH_InventoryManager.equippedItem = "";
			FPH_InventoryManager.equippedItem_Index = -1;
			FPH_InventoryManager.SaveInventory();
		}
	}

	void PrivateClose(){
		if(!autoclose){
			if(closeSound){
				GetComponent<AudioSource>().PlayOneShot(closeSound);
			}
			objectToAnimate.GetComponent<Animation>().CrossFade(closeDoorAniString);
		}
	}

	IEnumerator CloseAfterOpen(){
		yield return new WaitForSeconds(closeAfter);
		
		if(closeSound){
			GetComponent<AudioSource>().PlayOneShot(closeSound);
		}
		objectToAnimate.GetComponent<Animation>().CrossFade(closeDoorAniString);
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
	}

	/*
	 * We toggle the cameras and  show a text, everything will be reset
	 * after " secToOserve "
	 */
	IEnumerator PrivateObserve_Closeup(){
		inGameCamera.SetActive(false);
		closeupCamera.SetActive(true);
		interactingCollider.GetComponent<Collider>().enabled = false;
		FPH_ControlManager.canBeControlled = false;
		
		yield return new WaitForSeconds(0.1f);
		//FPH_LanguageManager.static_observeTextMesh.text = "";
		
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
		interactingCollider.GetComponent<Collider>().enabled = true;
		closeupCamera.SetActive(false);
		FPH_ControlManager.canBeControlled = true;
	}
}