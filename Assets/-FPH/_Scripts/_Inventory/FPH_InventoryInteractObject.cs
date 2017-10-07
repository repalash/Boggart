using UnityEngine;
using System.Collections;

public class FPH_InventoryInteractObject : MonoBehaviour {
	
	public string[] observeMode = new string[] {"Normal", "Closeup"};
	public int observeInt = 0;
	
	public GameObject inGameCamera;
	public GameObject closeupCamera;
	public GameObject interactingCollider;
	
	public bool removeOtherObject;
	public bool restoreOtherObjectToObtain;
	public GameObject otherObject;
	public string otherObjName_English;
	public string otherObjName_Italian;
	public string otherObjName_Spanish;
	public string otherObjName_German;
	public string otherObjName_French;
	public string otherObjName_Japanese;
	public string otherObjName_Chinese;
	public string otherObjName_Russian;
	public bool otherObjectHasKey;
	public string otherObjKey;
	
	public GameObject obtainedObj;
	public string objName_English;
	public string objName_Italian;
	public string objName_Spanish;
	public string objName_German;
	public string objName_French;
	public string objName_Japanese;
	public string objName_Chinese;
	public string objName_Russian;
	public Texture2D obj_Texture;
	public bool deleteIfKey;
	public string neededKey;
	
	public string obtainMessage_English;
	public string obtainMessage_Italian;
	public string obtainMessage_Spanish;
	public string obtainMessage_German;
	public string obtainMessage_French;
	public string obtainMessage_Japanese;
	public string obtainMessage_Chinese;
	public string obtainMessage_Russian;
	
	public bool canBeObserved;
	public string observMessage_English;
	public string observMessage_Italian;
	public string observMessage_Spanish;
	public string observMessage_German;
	public string observMessage_French;
	public string observMessage_Japanese;
	public string observMessage_Chinese;
	public string observMessage_Russian;
	
	public string description_English;
	public string description_Italian;
	public string description_Spanish;
	public string description_German;
	public string description_French;
	public string description_Japanese;
	public string description_Chinese;
	public string description_Russian;
	
	public float secToOserve = 1.3f;
	
	private bool hasObj;
	private bool hasOtherObj;
	private bool hasKey;
	
	
	/*
	 * If we already have this object in our inventory we deactivate it.
	 * Since and object has different inventory name for different languages
	 * we must perform a check for every languages.
	 */
	void Start(){
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			hasObj = FPH_InventoryManager.HasObject(objName_English);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			hasObj = FPH_InventoryManager.HasObject(objName_Italian);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			hasObj = FPH_InventoryManager.HasObject(objName_Spanish);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			hasObj = FPH_InventoryManager.HasObject(objName_German);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			hasObj = FPH_InventoryManager.HasObject(objName_French);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			hasObj = FPH_InventoryManager.HasObject(objName_Japanese);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			hasObj = FPH_InventoryManager.HasObject(objName_Chinese);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			hasObj = FPH_InventoryManager.HasObject(objName_Russian);
		}

		if(deleteIfKey){
			hasKey = FPH_ControlManager.LoadBool(neededKey);

			if(hasKey){
				if(obtainedObj == null && gameObject.activeSelf){
					gameObject.SetActive(false);
				}
				else if(obtainedObj != null && obtainedObj.activeSelf){
					obtainedObj.SetActive(false);
				}
			}
		}
		if(hasObj){
			if(obtainedObj == null && gameObject.activeSelf){
				gameObject.SetActive(false);
			}
			else if(obtainedObj != null && obtainedObj.activeSelf){
				obtainedObj.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update(){
		
	}

	/*
	 * When we obtain an object we must hide it and then show the obtain text and
	 * toogle the various var. We do not set its active state to false because this
	 * will stop the script. Setting it to false is ok on start because we do not care
	 * if this script is running or not.
	 */
	public void ObtainObj(){
		if(removeOtherObject){
			CheckDeleteOtherObject();
		}

		if(obtainedObj == null){
			gameObject.GetComponent<Renderer>().enabled = false;
			gameObject.GetComponent<Collider>().enabled = false;
		}
		else if(obtainedObj != null){
			obtainedObj.GetComponent<Renderer>().enabled = false;
			obtainedObj.GetComponent<Collider>().enabled = false;
		}
		
		StartCoroutine("ObtainMessage");
	}
	
	public void Observe(){
		if(observeInt == 0){ //Normal
			StartCoroutine("PrivateObserve_Normal");
		}
		if(observeInt == 1){ //Closeuo
			StartCoroutine("PrivateObserve_Closeup");
		}
	}

	/*
	 * When we obtain an object we show a message and then for every language we put
	 * the object into the inventory.
	 * We're doing that because an object will have different names and descriptions
	 * depending on game language.
	 */
	IEnumerator ObtainMessage(){
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_LanguageManager.static_observeTextMesh.text = obtainMessage_English;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = obtainMessage_Italian;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = obtainMessage_Spanish;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = obtainMessage_German;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = obtainMessage_French;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = obtainMessage_Japanese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = obtainMessage_Chinese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = obtainMessage_Russian;
		}
		
		yield return new WaitForSeconds(secToOserve);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
		
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_InventoryManager.AddInventoryItem(objName_English, obj_Texture.name.ToString(), description_English);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_InventoryManager.AddInventoryItem(objName_Italian, obj_Texture.name.ToString(), description_Italian);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_InventoryManager.AddInventoryItem(objName_Spanish, obj_Texture.name.ToString(), description_Spanish);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_InventoryManager.AddInventoryItem(objName_German, obj_Texture.name.ToString(), description_German);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_InventoryManager.AddInventoryItem(objName_French, obj_Texture.name.ToString(), description_French);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_InventoryManager.AddInventoryItem(objName_Japanese, obj_Texture.name.ToString(), description_Japanese);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_InventoryManager.AddInventoryItem(objName_Chinese, obj_Texture.name.ToString(), description_Chinese);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_InventoryManager.AddInventoryItem(objName_Russian, obj_Texture.name.ToString(), description_Russian);
		}
		
		FPH_InventoryManager.SaveInventory();
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
	
	IEnumerator PrivateObserve_Closeup(){
		inGameCamera.SetActive(false);
		closeupCamera.SetActive(true);
		interactingCollider.GetComponent<Collider>().enabled = false;
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
		FPH_ControlManager.canBeControlled = true;
		interactingCollider.GetComponent<Collider>().enabled = true;
		closeupCamera.SetActive(false);
	}

	void CheckDeleteOtherObject(){
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			hasOtherObj = FPH_InventoryManager.HasObject(otherObjName_English);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			hasOtherObj = FPH_InventoryManager.HasObject(otherObjName_Italian);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			hasOtherObj = FPH_InventoryManager.HasObject(otherObjName_Spanish);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			hasOtherObj = FPH_InventoryManager.HasObject(otherObjName_German);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			hasOtherObj = FPH_InventoryManager.HasObject(otherObjName_French);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			hasOtherObj = FPH_InventoryManager.HasObject(otherObjName_Japanese);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			hasOtherObj = FPH_InventoryManager.HasObject(otherObjName_Chinese);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			hasOtherObj = FPH_InventoryManager.HasObject(otherObjName_Russian);
		}

		if(hasOtherObj){
			int deleteAtIndex = -1;
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
				deleteAtIndex = FPH_InventoryManager.inventoryName.IndexOf(otherObjName_English);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
				deleteAtIndex = FPH_InventoryManager.inventoryName.IndexOf(otherObjName_Italian);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
				deleteAtIndex = FPH_InventoryManager.inventoryName.IndexOf(otherObjName_Spanish);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
				deleteAtIndex = FPH_InventoryManager.inventoryName.IndexOf(otherObjName_German);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
				deleteAtIndex = FPH_InventoryManager.inventoryName.IndexOf(otherObjName_French);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
				deleteAtIndex = FPH_InventoryManager.inventoryName.IndexOf(otherObjName_Japanese);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
				deleteAtIndex = FPH_InventoryManager.inventoryName.IndexOf(otherObjName_Chinese);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
				deleteAtIndex = FPH_InventoryManager.inventoryName.IndexOf(otherObjName_Russian);
			}

			if(restoreOtherObjectToObtain){
				otherObject.SetActive(true);
				otherObject.GetComponent<Renderer>().enabled = true;
				otherObject.GetComponent<Collider>().enabled = true;
			}

			FPH_InventoryManager.RemoveInventoryItem(deleteAtIndex);

			if(otherObjectHasKey && PlayerPrefs.HasKey(otherObjKey)){
				PlayerPrefs.DeleteKey(otherObjKey);
			}
		}
	}
}