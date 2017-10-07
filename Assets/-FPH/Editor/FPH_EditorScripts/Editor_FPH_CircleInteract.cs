using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_CircleInteract))] 
public class Editor_FPH_CircleInteract : Editor {
	
	private bool showKeyboardControl = false;


	public override void OnInspectorGUI() {
		FPH_CircleInteract myInspector = (FPH_CircleInteract) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		GUILayout.BeginHorizontal();
		EditorGUIUtility.labelWidth = 80.0f;
		myInspector.ingameCamera = (GameObject) EditorGUILayout.ObjectField("Ingame Cam: ", myInspector.ingameCamera, typeof(GameObject), true);
		myInspector.circleCamera = (GameObject) EditorGUILayout.ObjectField("Circle Cam: ", myInspector.circleCamera, typeof(GameObject), true);
		GUILayout.EndHorizontal();
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		EditorGUIUtility.labelWidth = 130.0f;
		myInspector.circleNum = EditorGUILayout.IntField("Num of circles:", myInspector.circleNum);
		
		showKeyboardControl = EditorGUILayout.Foldout(showKeyboardControl, "Keyboard Control");
		if(showKeyboardControl){
			EditorGUI.indentLevel = 1;
			EditorGUIUtility.labelWidth = 230.0f;
			myInspector.controlWithKeyboard = EditorGUILayout.Toggle("Control with keyboard?", myInspector.controlWithKeyboard);
			if(myInspector.controlWithKeyboard){
				EditorGUIUtility.labelWidth = 195.0f;
				
				myInspector.rotCircleObject01 = (GameObject) EditorGUILayout.ObjectField("Circle 1:", myInspector.rotCircleObject01, typeof(GameObject), true);
				myInspector.rotCircleObject02 = (GameObject) EditorGUILayout.ObjectField("Circle 2:", myInspector.rotCircleObject02, typeof(GameObject), true);
				myInspector.rotCircleObject03 = (GameObject) EditorGUILayout.ObjectField("Circle 3:", myInspector.rotCircleObject03, typeof(GameObject), true);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				myInspector.rotCircleMesh01 = (MeshRenderer) EditorGUILayout.ObjectField("Circle 1 (Mesh):", myInspector.rotCircleMesh01, typeof(MeshRenderer), true);
				myInspector.rotCircleMesh02 = (MeshRenderer) EditorGUILayout.ObjectField("Circle 2 (Mesh):", myInspector.rotCircleMesh02, typeof(MeshRenderer), true);
				myInspector.rotCircleMesh03 = (MeshRenderer) EditorGUILayout.ObjectField("Circle 3 (Mesh):", myInspector.rotCircleMesh03, typeof(MeshRenderer), true);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				myInspector.selectedMaterial = (Material) EditorGUILayout.ObjectField("Selected Button (Material):", myInspector.selectedMaterial, typeof(Material), true);
				myInspector.notSelectedMaterial = (Material) EditorGUILayout.ObjectField("Not Selected Button (Material):", myInspector.notSelectedMaterial, typeof(Material), true);
			}
			EditorGUI.indentLevel = 0;
		}

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