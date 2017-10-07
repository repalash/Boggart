using UnityEngine;
using System.Collections;

public class FPH_CircleInteract : MonoBehaviour {
	
	public GameObject circleCamera;
	public GameObject ingameCamera;

	public int circleNum;
	
	public bool controlWithKeyboard;
	public GameObject rotCircleObject01;
	public GameObject rotCircleObject02;
	public GameObject rotCircleObject03;
	
	public MeshRenderer rotCircleMesh01;
	public MeshRenderer rotCircleMesh02;
	public MeshRenderer rotCircleMesh03;
	public Material notSelectedMaterial;
	public Material selectedMaterial;
	
	// If the code we entered on the numpad is right we can send a message to an object or save a value
	public string[] onOkArray = new string[] {"SendMessage", "SetVar"};
	public int onOk;
	public bool reEnableOnOk; // Do you want to reenable the collider when you exit the numpad screen?
	
	public GameObject sendMessageTo; // Object you want to send the message to
	public string messageToSend; // The message we want to send
	
	public string[] keyTypeArray = new string[] {"Float", "Int", "String", "Bool"};
	public int keyType;
	
	// In case you want to save a value you can choose from four different value
	public string neededKey;
	public float valueToSet_Float;
	public int valueToSet_Int;
	public string valueToSet_String;
	public bool valueToSet_Bool;

	[HideInInspector] public int currentCircle;

	private bool called = false;
	private Collider thisColl;
	private int selectedCircle;


	// Use this for initialization
	void Start(){
		thisColl = gameObject.GetComponent<Collider>();
		selectedCircle = 0;
		
		if(onOk == 1){ // SetVar
			// We check if the value has been setted before, in this case we toggle the collider
			if(keyType == 0){ // Float
				float floatToCheck = PlayerPrefs.GetFloat(neededKey);
				if(floatToCheck == valueToSet_Float){
					thisColl.enabled = false;
				}
			}
			else if(keyType == 1){ // Int
				int intToCheck = PlayerPrefs.GetInt(neededKey);
				if(intToCheck == valueToSet_Int){
					thisColl.enabled = false;
				}
			}
			else if(keyType == 2){ // String
				string stringToCheck = PlayerPrefs.GetString(neededKey);
				if(stringToCheck == valueToSet_String){
					thisColl.enabled = false;
				}
			}
			else if(keyType == 3){ // Bool
				bool boolToCheck = FPH_ControlManager.LoadBool(neededKey);
				if(boolToCheck == valueToSet_Bool){
					thisColl.enabled = false;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!ingameCamera.activeSelf && circleCamera.activeSelf){
			if(controlWithKeyboard){
				if(Input.GetKeyUp(KeyCode.UpArrow)){
					if(selectedCircle <= 3){
						selectedCircle++;
					}
					if(selectedCircle > 2){
						selectedCircle = 0;
					}
				}
				if(Input.GetKeyUp(KeyCode.DownArrow)){
					if(selectedCircle >= 0){
						selectedCircle--;
					}
					if(selectedCircle < 0){
						selectedCircle = 2;
					}
				}
				
				if(selectedCircle == 0){
					rotCircleMesh01.material = selectedMaterial;
					rotCircleMesh02.material = notSelectedMaterial;
					rotCircleMesh03.material = notSelectedMaterial;
				}
				if(selectedCircle == 1){
					rotCircleMesh01.material = notSelectedMaterial;
					rotCircleMesh02.material = selectedMaterial;
					rotCircleMesh03.material = notSelectedMaterial;
				}
				if(selectedCircle == 2){
					rotCircleMesh01.material = notSelectedMaterial;
					rotCircleMesh02.material = notSelectedMaterial;
					rotCircleMesh03.material = selectedMaterial;
				}

				if(Input.GetKey(KeyCode.LeftArrow)){
					if(selectedCircle == 0){
						rotCircleObject01.transform.Rotate(Vector3.right, Time.deltaTime * 40.0f);
					}
					if(selectedCircle == 1){
						rotCircleObject02.transform.Rotate(Vector3.right, Time.deltaTime * 40.0f);
					}
					if(selectedCircle == 2){
						rotCircleObject03.transform.Rotate(Vector3.right, Time.deltaTime * 40.0f);
					}
				}
				if(Input.GetKey(KeyCode.RightArrow)){
					if(selectedCircle == 0){
						rotCircleObject01.transform.Rotate(-Vector3.right, Time.deltaTime * 50.0f);
					}
					if(selectedCircle == 1){
						rotCircleObject02.transform.Rotate(-Vector3.right, Time.deltaTime * 50.0f);
					}
					if(selectedCircle == 2){
						rotCircleObject03.transform.Rotate(-Vector3.right, Time.deltaTime * 50.0f);
					}
				}
			}


			if(circleNum == currentCircle && !called){
				called = true;
				DoneCircle();
			}
		}
	}
	
	public void Interact(){
		FPH_ControlManager.isScreenLocked = false; // Screen.lockCursor = false;
		thisColl.enabled = false;
		ingameCamera.SetActive(false);
		circleCamera.SetActive(true);
		FPH_ControlManager.canBeControlled = false;
	}
	
	public void ExitCirclePuzzle(){
		if(controlWithKeyboard){
			rotCircleMesh01.material = notSelectedMaterial;
			rotCircleMesh02.material = notSelectedMaterial;
			rotCircleMesh03.material = notSelectedMaterial;
		}
		FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		thisColl.enabled = true;
		ingameCamera.SetActive(true);
		circleCamera.SetActive(false);
		FPH_ControlManager.canBeControlled = true;
	}

	void DoneCircle(){
		if(onOk == 0){ // SendMessage
			if(sendMessageTo != null){
				sendMessageTo.SendMessage(messageToSend);
			}
			if(sendMessageTo == null){
				Debug.LogWarning("No receiver for message - FPH_CircleInteract " + this.gameObject.name);
			}
			
			if(reEnableOnOk){
				thisColl.enabled = true;
			}

			if(controlWithKeyboard){
				rotCircleMesh01.material = notSelectedMaterial;
				rotCircleMesh02.material = notSelectedMaterial;
				rotCircleMesh03.material = notSelectedMaterial;
			}
			ingameCamera.SetActive(true);
			circleCamera.SetActive(false);
			FPH_ControlManager.canBeControlled = true;
			FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		}
		else if(onOk == 1){ // SetVar
			if(keyType == 0){ // Float
				PlayerPrefs.SetFloat(neededKey, valueToSet_Float);
			}
			else if(keyType == 1){ // Int
				PlayerPrefs.SetInt(neededKey, valueToSet_Int);
			}
			else if(keyType == 2){ // String
				PlayerPrefs.SetString(neededKey, valueToSet_String);
			}
			else if(keyType == 3){ // Bool
				FPH_ControlManager.SaveBool(neededKey, valueToSet_Bool);
			}
			
			if(reEnableOnOk){
				thisColl.enabled = true;
			}
			
			if(controlWithKeyboard){
				rotCircleMesh01.material = notSelectedMaterial;
				rotCircleMesh02.material = notSelectedMaterial;
				rotCircleMesh03.material = notSelectedMaterial;
			}
			ingameCamera.SetActive(true);
			circleCamera.SetActive(false);
			FPH_ControlManager.canBeControlled = true;
			FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		}
	}
}