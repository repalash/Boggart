using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_CatchEventScript))]
public class Editor_FPH_CatchEventScript : Editor {


	public override void OnInspectorGUI(){
		FPH_CatchEventScript myInspector = (FPH_CatchEventScript) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		EditorGUIUtility.labelWidth = 100.0f;
		myInspector.eventType = EditorGUILayout.Popup("Catch event:", myInspector.eventType, myInspector.eventTypeArray);

		if(myInspector.eventType == 0){
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 100.0f;
			myInspector.neededKey = EditorGUILayout.TextField("Key To Retrieve:", myInspector.neededKey);
			
			myInspector.keyType = EditorGUILayout.Popup("Var to retrieve:", myInspector.keyType, myInspector.keyTypeArray);
			
			EditorGUIUtility.labelWidth = 165.0f;
			if(myInspector.keyType == 0){
				myInspector.valueToCheck_Float = EditorGUILayout.FloatField("Check for this value (Float):", myInspector.valueToCheck_Float);
			}
			else if(myInspector.keyType == 1){
				myInspector.valueToCheck_Int = EditorGUILayout.IntField("Check for this value (Int):", myInspector.valueToCheck_Int);
			}
			else if(myInspector.keyType == 2){
				myInspector.valueToCheck_String = EditorGUILayout.TextField("Check for this value (String):", myInspector.valueToCheck_String);
			}
			else if(myInspector.keyType == 3){
				myInspector.valueToCheck_Bool = EditorGUILayout.Toggle("Check for this value (Bool):", myInspector.valueToCheck_Bool);
			}
		}
		
		EditorGUIUtility.labelWidth = 130.0f;
		if(myInspector.eventType == 1 || myInspector.eventType == 2){
			GUILayout.Space(10.0f); //Put some spece between different elements

			myInspector.collideWithPlayer = EditorGUILayout.Toggle("Collide with Player?", myInspector.collideWithPlayer);
			if(!myInspector.collideWithPlayer){
				myInspector.collObj = (GameObject) EditorGUILayout.ObjectField("Object to collide with:", myInspector.collObj, typeof(GameObject), true);
			}
		}

		GUILayout.Space(10.0f); //Put some spece between different elements
		
		EditorGUIUtility.labelWidth = 80.0f;
		myInspector.actionType = EditorGUILayout.Popup("Action Type:", myInspector.actionType, myInspector.actionTypeArray);

		EditorGUI.indentLevel = 1;
		if(myInspector.actionType == 0){
			EditorGUIUtility.labelWidth = 150.0f;

			myInspector.toggleThisObj = EditorGUILayout.Toggle("Deactivate this Obect?", myInspector.toggleThisObj);
			if(!myInspector.toggleThisObj){
				EditorGUI.indentLevel = 2;
				SerializedObject serTarget = new SerializedObject(target);
				SerializedProperty objListProperty = serTarget.FindProperty("objList");
				EditorGUILayout.PropertyField(objListProperty, new GUIContent("Objects to deactivate"), true);
				serTarget.ApplyModifiedProperties();
				EditorGUI.indentLevel = 0;
			}
		}
		if(myInspector.actionType == 1){
			EditorGUIUtility.labelWidth = 120.0f;
			myInspector.sendMessageTo = (GameObject) EditorGUILayout.ObjectField("SendMessage To:", myInspector.sendMessageTo, typeof(GameObject), true);
			myInspector.messageToSend = EditorGUILayout.TextField("Message To Send:", myInspector.messageToSend);
		}
		EditorGUI.indentLevel = 0;

		GUILayout.Space(10.0f); //Put some spece between different elements
	}
}