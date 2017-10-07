using UnityEngine;
using System.Collections;

public class FPH_RotPuzzle_Interactor : MonoBehaviour {
	
	public GameObject rotPuzzleCamera;
	public GameObject ingameCamera;
	
	public string codeToCheck;
	
	public bool controlWithKeyboard;
	public GameObject rotDiskObject01;
	public GameObject rotDiskObject02;
	public GameObject rotDiskObject03;
	public GameObject rotDiskObject04;

	public MeshRenderer rotDiskMesh01;
	public MeshRenderer rotDiskMesh02;
	public MeshRenderer rotDiskMesh03;
	public MeshRenderer rotDiskMesh04;
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
	
	[HideInInspector] public int disk01Pos = 1;
	[HideInInspector] public int disk02Pos = 1;
	[HideInInspector] public int disk03Pos = 1;
	[HideInInspector] public int disk04Pos = 1;

	// In case you want to save a value you can choose from four different value
	public string neededKey;
	public float valueToSet_Float;
	public int valueToSet_Int;
	public string valueToSet_String;
	public bool valueToSet_Bool;

	private Collider thisColl;
	private bool checkedCode;
	private int selectedPosition;


	// Use this for initialization
	void Start(){
		thisColl = gameObject.GetComponent<Collider>();
		checkedCode = false;
		selectedPosition = 0;
	
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
	void Update(){
		if(!ingameCamera.activeSelf && rotPuzzleCamera.activeSelf){
			if(controlWithKeyboard){
				if(Input.GetKeyUp(KeyCode.UpArrow)){
					if(selectedPosition == 0){
						iTween.RotateAdd(rotDiskObject01, new Vector3(rotDiskObject01.transform.eulerAngles.x, rotDiskObject01.transform.eulerAngles.y, 73.0f), 1.0f);
					}
					if(selectedPosition == 1){
						iTween.RotateAdd(rotDiskObject02, new Vector3(rotDiskObject02.transform.eulerAngles.x, rotDiskObject02.transform.eulerAngles.y, 73.0f), 1.0f);
					}
					if(selectedPosition == 2){
						iTween.RotateAdd(rotDiskObject03, new Vector3(rotDiskObject03.transform.eulerAngles.x, rotDiskObject03.transform.eulerAngles.y, 73.0f), 1.0f);
					}
					if(selectedPosition == 3){
						iTween.RotateAdd(rotDiskObject04, new Vector3(rotDiskObject04.transform.eulerAngles.x, rotDiskObject04.transform.eulerAngles.y, 73.0f), 1.0f);
					}
				}
				if(Input.GetKeyUp(KeyCode.DownArrow)){
					if(selectedPosition == 0){
						iTween.RotateAdd(rotDiskObject01, new Vector3(rotDiskObject01.transform.eulerAngles.x, rotDiskObject01.transform.eulerAngles.y, -73.0f), 1.0f);
					}
					if(selectedPosition == 1){
						iTween.RotateAdd(rotDiskObject02, new Vector3(rotDiskObject02.transform.eulerAngles.x, rotDiskObject02.transform.eulerAngles.y, -73.0f), 1.0f);
					}
					if(selectedPosition == 2){
						iTween.RotateAdd(rotDiskObject03, new Vector3(rotDiskObject03.transform.eulerAngles.x, rotDiskObject03.transform.eulerAngles.y, -73.0f), 1.0f);
					}
					if(selectedPosition == 3){
						iTween.RotateAdd(rotDiskObject04, new Vector3(rotDiskObject04.transform.eulerAngles.x, rotDiskObject04.transform.eulerAngles.y, -73.0f), 1.0f);
					}
				}
				
				if(Input.GetKeyUp(KeyCode.RightArrow)){
					if(selectedPosition <= 3){
						selectedPosition++;
					}
					if(selectedPosition > 3){
						selectedPosition = 0;
					}
				}
				if(Input.GetKeyUp(KeyCode.LeftArrow)){
					if(selectedPosition >= 0){
						selectedPosition--;
					}
					if(selectedPosition < 0){
						selectedPosition = 3;
					}
				}
				
				if(selectedPosition == 0){
					rotDiskMesh01.material = selectedMaterial;
					rotDiskMesh02.material = notSelectedMaterial;
					rotDiskMesh03.material = notSelectedMaterial;
					rotDiskMesh04.material = notSelectedMaterial;
				}
				if(selectedPosition == 1){
					rotDiskMesh01.material = notSelectedMaterial;
					rotDiskMesh02.material = selectedMaterial;
					rotDiskMesh03.material = notSelectedMaterial;
					rotDiskMesh04.material = notSelectedMaterial;
				}
				if(selectedPosition == 2){
					rotDiskMesh01.material = notSelectedMaterial;
					rotDiskMesh02.material = notSelectedMaterial;
					rotDiskMesh03.material = selectedMaterial;
					rotDiskMesh04.material = notSelectedMaterial;
				}
				if(selectedPosition == 3){
					rotDiskMesh01.material = notSelectedMaterial;
					rotDiskMesh02.material = notSelectedMaterial;
					rotDiskMesh03.material = notSelectedMaterial;
					rotDiskMesh04.material = selectedMaterial;
				}
			}

			string completeDiskPos = disk01Pos.ToString() + disk02Pos.ToString() + disk03Pos.ToString() + disk04Pos.ToString();
			if(!checkedCode && completeDiskPos == codeToCheck){
				checkedCode = true;
				StartCoroutine("DoneCode");
			}
		}
	}
	
	public void Interact(){
		FPH_ControlManager.isScreenLocked = false; // Screen.lockCursor = false;
		thisColl.enabled = false;
		ingameCamera.SetActive(false);
		rotPuzzleCamera.SetActive(true);
		FPH_ControlManager.canBeControlled = false;
	}

	// If the code is right we send the message/setvalue and then deactivate the rotPuzzleCamera
	IEnumerator DoneCode(){
		if(onOk == 0){ // SendMessage
			if(sendMessageTo != null){
				sendMessageTo.SendMessage(messageToSend);
			}
			if(sendMessageTo == null){
				Debug.LogWarning("No receiver for message - FPH_NumPad_Interactor " + this.gameObject.name);
			}

			if(reEnableOnOk){
				thisColl.enabled = true;
			}

			yield return new WaitForSeconds(0.5f);
			
			if(controlWithKeyboard){
				rotDiskMesh01.material = notSelectedMaterial;
				rotDiskMesh02.material = notSelectedMaterial;
				rotDiskMesh03.material = notSelectedMaterial;
				rotDiskMesh04.material = notSelectedMaterial;
			}
			ingameCamera.SetActive(true);
			rotPuzzleCamera.SetActive(false);
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
			
			yield return new WaitForSeconds(0.5f);
			
			if(controlWithKeyboard){
				rotDiskMesh01.material = notSelectedMaterial;
				rotDiskMesh02.material = notSelectedMaterial;
				rotDiskMesh03.material = notSelectedMaterial;
				rotDiskMesh04.material = notSelectedMaterial;
			}
			ingameCamera.SetActive(true);
			rotPuzzleCamera.SetActive(false);
			FPH_ControlManager.canBeControlled = true;
			FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		}
	}

	public void ExitRotPuzzle(){
		if(controlWithKeyboard){
			rotDiskMesh01.material = notSelectedMaterial;
			rotDiskMesh02.material = notSelectedMaterial;
			rotDiskMesh03.material = notSelectedMaterial;
			rotDiskMesh04.material = notSelectedMaterial;
		}
		FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		thisColl.enabled = true;
		ingameCamera.SetActive(true);
		rotPuzzleCamera.SetActive(false);
		FPH_ControlManager.canBeControlled = true;
	}
}