using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_NumPad_Interactor))] 
public class Editor_FPH_NumPad_Interactor : Editor {
	
	private bool showKeyboardControl = false;


	public override void OnInspectorGUI() {
		FPH_NumPad_Interactor myInspector = (FPH_NumPad_Interactor) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		GUILayout.BeginHorizontal();
		EditorGUIUtility.labelWidth = 80.0f;
		myInspector.ingameCamera = (GameObject) EditorGUILayout.ObjectField("Ingame Cam: ", myInspector.ingameCamera, typeof(GameObject), true);
		myInspector.numpadCamera = (GameObject) EditorGUILayout.ObjectField("Numpad Cam: ", myInspector.numpadCamera, typeof(GameObject), true);
		GUILayout.EndHorizontal();

		showKeyboardControl = EditorGUILayout.Foldout(showKeyboardControl, "Keyboard Control");
		if(showKeyboardControl){
			EditorGUI.indentLevel = 1;
			EditorGUIUtility.labelWidth = 230.0f;
			myInspector.controlWithKeyboard = EditorGUILayout.Toggle("Control with keyboard?", myInspector.controlWithKeyboard);
			if(myInspector.controlWithKeyboard){
				EditorGUIUtility.labelWidth = 195.0f;
				
				myInspector.numpadButtons00 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 0 (Script):", myInspector.numpadButtons00, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtons01 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 1 (Script):", myInspector.numpadButtons01, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtons02 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 2 (Script):", myInspector.numpadButtons02, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtons03 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 3 (Script):", myInspector.numpadButtons03, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtons04 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 4 (Script):", myInspector.numpadButtons04, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtons05 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 5 (Script):", myInspector.numpadButtons05, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtons06 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 6 (Script):", myInspector.numpadButtons06, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtons07 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 7 (Script):", myInspector.numpadButtons07, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtons08 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 8 (Script):", myInspector.numpadButtons08, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtons09 = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button 9 (Script):", myInspector.numpadButtons09, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtonsBack = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button Back (Script):", myInspector.numpadButtonsBack, typeof(FPH_NumPad_Buttons), true);
				myInspector.numpadButtonsConfirm = (FPH_NumPad_Buttons) EditorGUILayout.ObjectField("Numpad Button Confirm (Script):", myInspector.numpadButtonsConfirm, typeof(FPH_NumPad_Buttons), true);

				GUILayout.Space(10.0f); //Put some spece between different elements
				
				myInspector.numpadButtonMeshes00 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 0 (Mesh):", myInspector.numpadButtonMeshes00, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshes01 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 1 (Mesh):", myInspector.numpadButtonMeshes01, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshes02 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 2 (Mesh):", myInspector.numpadButtonMeshes02, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshes03 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 3 (Mesh):", myInspector.numpadButtonMeshes03, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshes04 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 4 (Mesh):", myInspector.numpadButtonMeshes04, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshes05 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 5 (Mesh):", myInspector.numpadButtonMeshes05, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshes06 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 6 (Mesh):", myInspector.numpadButtonMeshes06, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshes07 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 7 (Mesh):", myInspector.numpadButtonMeshes07, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshes08 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 8 (Mesh):", myInspector.numpadButtonMeshes08, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshes09 = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button 9 (Mesh):", myInspector.numpadButtonMeshes09, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshesBack = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button Back (Mesh):", myInspector.numpadButtonMeshesBack, typeof(MeshRenderer), true);
				myInspector.numpadButtonMeshesConfirm = (MeshRenderer) EditorGUILayout.ObjectField("Numpad Button Confirm (Mesh):", myInspector.numpadButtonMeshesConfirm, typeof(MeshRenderer), true);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				myInspector.selectedMaterial = (Material) EditorGUILayout.ObjectField("Selected Button (Material):", myInspector.selectedMaterial, typeof(Material), true);
				myInspector.notSelectedMaterial = (Material) EditorGUILayout.ObjectField("Not Selected Button (Material):", myInspector.notSelectedMaterial, typeof(Material), true);
			}
			EditorGUI.indentLevel = 0;
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		EditorGUIUtility.labelWidth = 130.0f;
		myInspector.codeToCheck = EditorGUILayout.TextField("Numpad OK code:", myInspector.codeToCheck);
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		myInspector.onOk = EditorGUILayout.Popup("Action on OK code:", myInspector.onOk, myInspector.onOkArray);
		EditorGUIUtility.labelWidth = 150.0f;
		myInspector.reEnableOnOk = EditorGUILayout.Toggle("ReEnable collider on exit:", myInspector.reEnableOnOk);

		if(myInspector.onOk == 0){ // SendMessage
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 130.0f;
			myInspector.sendMessageTo = (GameObject) EditorGUILayout.ObjectField("SendMessage To: ", myInspector.sendMessageTo, typeof(GameObject), true);
			myInspector.messageToSend = EditorGUILayout.TextField("Message To Send:", myInspector.messageToSend);
		}
		if(myInspector.onOk == 1){ // SetVar
			GUILayout.Space(10.0f); //Put some spece between different elements

			EditorGUIUtility.labelWidth = 130.0f;
			myInspector.keyType = EditorGUILayout.Popup("Value To Save:", myInspector.keyType, myInspector.keyTypeArray);
			myInspector.neededKey = EditorGUILayout.TextField("Key To Save:", myInspector.neededKey);

			GUILayout.Space(10.0f); //Put some spece between different elements

			if(myInspector.keyType == 0){ // Float
				myInspector.valueToSet_Float = EditorGUILayout.FloatField("Value To Save (Float):", myInspector.valueToSet_Float);
			}
			if(myInspector.keyType == 1){ // Int
				myInspector.valueToSet_Int = EditorGUILayout.IntField("Value To Save (Int):", myInspector.valueToSet_Int);
			}
			if(myInspector.keyType == 2){ // String
				myInspector.valueToSet_String = EditorGUILayout.TextField("Value To Save (String):", myInspector.valueToSet_String);
			}
			if(myInspector.keyType == 3){ // Bool
				myInspector.valueToSet_Bool = EditorGUILayout.Toggle("Value To Save (Bool):", myInspector.valueToSet_Bool);
			}
		}
	}
}