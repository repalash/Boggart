using UnityEngine;
using System.Collections;

public class FPH_CatchEventScript : MonoBehaviour {

	/*
	 * With this object you can toggle an object or other object in case
	 * the value of a retrieved key is the same of our check value.
	 */

	public string[] eventTypeArray = new string[] {"PlayerPref Retrieve", "OnTriggerEnter", "OnCollisionEnter"};
	public int eventType;

	public bool collideWithPlayer = true;
	public GameObject collObj;

	public string neededKey =  "";

	public string[] keyTypeArray = new string[] {"Float", "Int", "String", "Bool"};
	public int keyType;
	
	public float valueToCheck_Float;
	public int valueToCheck_Int;
	public string valueToCheck_String;
	public bool valueToCheck_Bool;

	public string[] actionTypeArray = new string[] {"Deactivate Object", "SendMessage"};
	public int actionType;
	
	public GameObject sendMessageTo;
	public string messageToSend;

	public bool toggleThisObj = true;
	public GameObject[] objList;


	// Use this for initialization
	void Start(){
		if(eventType == 0){
			if(keyType == 0){
				float retrievedFloat = PlayerPrefs.GetFloat(neededKey);
				if(retrievedFloat == valueToCheck_Float){
					if(actionType == 0){
						if(toggleThisObj){
							gameObject.SetActive(false);
						}
						else{
							for(int i = 0; i < objList.Length; i++){
								objList[i].SetActive(false);
							}
						}
					}
					if(actionType == 1){
						sendMessageTo.SendMessage(messageToSend);
					}
				}
			}
			else if(keyType == 1){
				int retrievedInt = PlayerPrefs.GetInt(neededKey);
				if(retrievedInt == valueToCheck_Int){
					if(actionType == 0){
						if(toggleThisObj){
							gameObject.SetActive(false);
						}
						else{
							for(int i = 0; i < objList.Length; i++){
								objList[i].SetActive(false);
							}
						}
					}
					if(actionType == 1){
						sendMessageTo.SendMessage(messageToSend);
					}
				}
			}
			else if(keyType == 2){
				string retrievedString = PlayerPrefs.GetString(neededKey);
				if(retrievedString == valueToCheck_String){
					if(actionType == 0){
						if(toggleThisObj){
							gameObject.SetActive(false);
						}
						else{
							for(int i = 0; i < objList.Length; i++){
								objList[i].SetActive(false);
							}
						}
					}
					if(actionType == 1){
						sendMessageTo.SendMessage(messageToSend);
					}
				}
			}
			else if(keyType == 3){
				bool retrievedBool = FPH_ControlManager.LoadBool(neededKey);
				if(retrievedBool == valueToCheck_Bool){
					if(actionType == 0){
						if(toggleThisObj){
							gameObject.SetActive(false);
						}
						else{
							for(int i = 0; i < objList.Length; i++){
								objList[i].SetActive(false);
							}
						}
					}
					if(actionType == 1){
						sendMessageTo.SendMessage(messageToSend);
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update(){
		if(eventType == 0){
			if(keyType == 0){
				float retrievedFloat = PlayerPrefs.GetFloat(neededKey);
				if(retrievedFloat == valueToCheck_Float){
					if(actionType == 0){
						if(toggleThisObj){
							gameObject.SetActive(false);
						}
						else{
							for(int i = 0; i < objList.Length; i++){
								objList[i].SetActive(false);
							}
						}
					}
					if(actionType == 1){
						sendMessageTo.SendMessage(messageToSend);
					}
				}
			}
			else if(keyType == 1){
				int retrievedInt = PlayerPrefs.GetInt(neededKey);
				if(retrievedInt == valueToCheck_Int){
					if(actionType == 0){
						if(toggleThisObj){
							gameObject.SetActive(false);
						}
						else{
							for(int i = 0; i < objList.Length; i++){
								objList[i].SetActive(false);
							}
						}
					}
					if(actionType == 1){
						sendMessageTo.SendMessage(messageToSend);
					}
				}
			}
			else if(keyType == 2){
				string retrievedString = PlayerPrefs.GetString(neededKey);
				if(retrievedString == valueToCheck_String){
					if(actionType == 0){
						if(toggleThisObj){
							gameObject.SetActive(false);
						}
						else{
							for(int i = 0; i < objList.Length; i++){
								objList[i].SetActive(false);
							}
						}
					}
					if(actionType == 1){
						sendMessageTo.SendMessage(messageToSend);
					}
				}
			}
			else if(keyType == 3){
				bool retrievedBool = FPH_ControlManager.LoadBool(neededKey);
				if(retrievedBool == valueToCheck_Bool){
					if(actionType == 0){
						if(toggleThisObj){
							gameObject.SetActive(false);
						}
						else{
							for(int i = 0; i < objList.Length; i++){
								objList[i].SetActive(false);
							}
						}
					}
					if(actionType == 1){
						sendMessageTo.SendMessage(messageToSend);
					}
				}
			}
		}
	}


	void OnTriggerEnter(Collider col){
		if(actionType == 0){
			if(collideWithPlayer){
				if(col.gameObject.tag == "Player"){
					if(toggleThisObj){
						gameObject.SetActive(false);
					}
					else{
						for(int i = 0; i < objList.Length; i++){
							objList[i].SetActive(false);
						}
					}
				}
			}
			else{
				if(col.gameObject == collObj){
					if(toggleThisObj){
						gameObject.SetActive(false);
					}
					else{
						for(int i = 0; i < objList.Length; i++){
							objList[i].SetActive(false);
						}
					}
				}
			}
		}
		if(actionType == 1){
			sendMessageTo.SendMessage(messageToSend);
		}
	}
	
	void OnCollisionEnter(Collision col){
		if(actionType == 0){
			if(collideWithPlayer){
				if(col.gameObject.tag == "Player"){
					if(toggleThisObj){
						gameObject.SetActive(false);
					}
					else{
						for(int i = 0; i < objList.Length; i++){
							objList[i].SetActive(false);
						}
					}
				}
			}
			else{
				if(col.gameObject == collObj){
					if(toggleThisObj){
						gameObject.SetActive(false);
					}
					else{
						for(int i = 0; i < objList.Length; i++){
							objList[i].SetActive(false);
						}
					}
				}
			}
		}
		if(actionType == 1){
			sendMessageTo.SendMessage(messageToSend);
		}
	}
}