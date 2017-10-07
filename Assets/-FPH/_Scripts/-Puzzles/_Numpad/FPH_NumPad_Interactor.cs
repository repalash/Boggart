using UnityEngine;
using System.Collections;

public class FPH_NumPad_Interactor : MonoBehaviour {
	
	public GameObject numpadCamera;
	public GameObject ingameCamera;
	
	public string codeToCheck;

	public bool controlWithKeyboard;
	public FPH_NumPad_Buttons numpadButtons00;
	public FPH_NumPad_Buttons numpadButtons01;
	public FPH_NumPad_Buttons numpadButtons02;
	public FPH_NumPad_Buttons numpadButtons03;
	public FPH_NumPad_Buttons numpadButtons04;
	public FPH_NumPad_Buttons numpadButtons05;
	public FPH_NumPad_Buttons numpadButtons06;
	public FPH_NumPad_Buttons numpadButtons07;
	public FPH_NumPad_Buttons numpadButtons08;
	public FPH_NumPad_Buttons numpadButtons09;
	public FPH_NumPad_Buttons numpadButtonsBack;
	public FPH_NumPad_Buttons numpadButtonsConfirm;
	public MeshRenderer numpadButtonMeshes00;
	public MeshRenderer numpadButtonMeshes01;
	public MeshRenderer numpadButtonMeshes02;
	public MeshRenderer numpadButtonMeshes03;
	public MeshRenderer numpadButtonMeshes04;
	public MeshRenderer numpadButtonMeshes05;
	public MeshRenderer numpadButtonMeshes06;
	public MeshRenderer numpadButtonMeshes07;
	public MeshRenderer numpadButtonMeshes08;
	public MeshRenderer numpadButtonMeshes09;
	public MeshRenderer numpadButtonMeshesBack;
	public MeshRenderer numpadButtonMeshesConfirm;
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

	private Collider thisColl;
	private string[,] keyboardArray = new string[4, 3] {
		{"1", "2", "3"}, 
		{"4", "5", "6"}, 
		{"7", "8", "9"}, 
		{"BACK", "0", "OK"} 
	};
	private Vector2 arrayPos = new Vector2(0.0f, 0.0f);

	// Use this for initialization
	void Start(){
		thisColl = gameObject.GetComponent<Collider>();
	
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
		if(controlWithKeyboard && numpadCamera.activeSelf){
			if(Input.GetKeyUp(KeyCode.RightArrow)){
				if(arrayPos.x <= 2.0f){
					arrayPos.x++;
				}
				if(arrayPos.x > 2.0f){
					arrayPos.x = 0;
				}
			}
			if(Input.GetKeyUp(KeyCode.LeftArrow)){
				if(arrayPos.x >= 0.0f){
					arrayPos.x--;
				}
				if(arrayPos.x < 0.0f){
					arrayPos.x = 2.0f;
				}
			}
			
			if(Input.GetKeyUp(KeyCode.UpArrow)){
				if(arrayPos.y >= 0.0f){
					arrayPos.y--;
				}
				if(arrayPos.y < 0.0f){
					arrayPos.y = 3.0f;
				}
			}
			if(Input.GetKeyUp(KeyCode.DownArrow)){
				if(arrayPos.y <= 3.0f){
					arrayPos.y++;
				}
				if(arrayPos.y > 3.0f){
					arrayPos.y = 0;
				}
			}
			
			string currentSelected = keyboardArray[(int)arrayPos.y, (int)arrayPos.x];
			if(currentSelected == "0"){
				numpadButtonMeshes00.material = selectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons00.OnTouchUp();
				}
			}
			if(currentSelected == "1"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = selectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons01.OnTouchUp();
				}
			}
			if(currentSelected == "2"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = selectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons02.OnTouchUp();
				}
			}
			if(currentSelected == "3"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = selectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons03.OnTouchUp();
				}
			}
			if(currentSelected == "4"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = selectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons04.OnTouchUp();
				}
			}
			if(currentSelected == "5"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = selectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons05.OnTouchUp();
				}
			}
			if(currentSelected == "6"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = selectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons06.OnTouchUp();
				}
			}
			if(currentSelected == "7"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = selectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons07.OnTouchUp();
				}
			}
			if(currentSelected == "8"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = selectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons08.OnTouchUp();
				}
			}
			if(currentSelected == "9"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = selectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtons09.OnTouchUp();
				}
			}
			if(currentSelected == "BACK"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = selectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtonsBack.OnTouchUp();
				}
			}
			if(currentSelected == "OK"){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = selectedMaterial;
				
				if(Input.GetKeyUp(KeyCode.Return)){
					numpadButtonsConfirm.OnTouchUp();
				}
			}
		}
	}

	public void Interact(){
		FPH_ControlManager.isScreenLocked = false; // Screen.lockCursor = false;
		thisColl.enabled = false;
		ingameCamera.SetActive(false);
		numpadCamera.SetActive(true);
		FPH_ControlManager.canBeControlled = false;
	}

	// If the code is right we send the message/setvalue and then deactivate the numpadCamera
	public void DoneCode(){
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

			if(controlWithKeyboard){
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
			}
			ingameCamera.SetActive(true);
			numpadCamera.SetActive(false);
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
				numpadButtonMeshes00.material = notSelectedMaterial;
				numpadButtonMeshes01.material = notSelectedMaterial;
				numpadButtonMeshes02.material = notSelectedMaterial;
				numpadButtonMeshes03.material = notSelectedMaterial;
				numpadButtonMeshes04.material = notSelectedMaterial;
				numpadButtonMeshes05.material = notSelectedMaterial;
				numpadButtonMeshes06.material = notSelectedMaterial;
				numpadButtonMeshes07.material = notSelectedMaterial;
				numpadButtonMeshes08.material = notSelectedMaterial;
				numpadButtonMeshes09.material = notSelectedMaterial;
				numpadButtonMeshesBack.material = notSelectedMaterial;
				numpadButtonMeshesConfirm.material = notSelectedMaterial;
			}
			ingameCamera.SetActive(true);
			numpadCamera.SetActive(false);
			FPH_ControlManager.canBeControlled = true;
			FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		}
	}

	public void ExitNumpad(){
		if(controlWithKeyboard){
			numpadButtonMeshes00.material = notSelectedMaterial;
			numpadButtonMeshes01.material = notSelectedMaterial;
			numpadButtonMeshes02.material = notSelectedMaterial;
			numpadButtonMeshes03.material = notSelectedMaterial;
			numpadButtonMeshes04.material = notSelectedMaterial;
			numpadButtonMeshes05.material = notSelectedMaterial;
			numpadButtonMeshes06.material = notSelectedMaterial;
			numpadButtonMeshes07.material = notSelectedMaterial;
			numpadButtonMeshes08.material = notSelectedMaterial;
			numpadButtonMeshes09.material = notSelectedMaterial;
			numpadButtonMeshesBack.material = notSelectedMaterial;
			numpadButtonMeshesConfirm.material = notSelectedMaterial;
		}
		FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		thisColl.enabled = true;
		ingameCamera.SetActive(true);
		numpadCamera.SetActive(false);
		FPH_ControlManager.canBeControlled = true;
	}
}