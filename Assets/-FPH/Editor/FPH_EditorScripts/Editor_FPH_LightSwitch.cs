using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_LightSwitch))] 
public class Editor_FPH_LightSwitch : Editor {
	
	public override void OnInspectorGUI() {
		FPH_LightSwitch myInspector = (FPH_LightSwitch) target;
		
		EditorGUIUtility.labelWidth = 130.0f;
		myInspector.interactionInt = EditorGUILayout.Popup("Lightswitch Behaviour:", myInspector.interactionInt, myInspector.interactionKind);
		if(myInspector.interactionInt != 1){
			myInspector.sendMessOnEnd = EditorGUILayout.Toggle("Send Message On End:", myInspector.sendMessOnEnd);
			myInspector.saveState = EditorGUILayout.Toggle("Save State on End:", myInspector.saveState);
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		myInspector.objToAnimate = (Animation) EditorGUILayout.ObjectField("Animate Object:", myInspector.objToAnimate, typeof(Animation), true);
		myInspector.switchAnim = EditorGUILayout.TextField("Switch animation:", myInspector.switchAnim);
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		if(myInspector.interactionInt != 2){
			EditorGUILayout.BeginHorizontal();
			myInspector.switchLightAfter = EditorGUILayout.FloatField("Switch Light After", myInspector.switchLightAfter);
			if(GUILayout.Button("Use Animation Duration", GUILayout.Width(140.0f), GUILayout.Height(15.0f))){
				myInspector.SetSwitchAfter();
			}
			EditorGUILayout.EndHorizontal();

			if(myInspector.interactionInt == 0){
				myInspector.switchInt = EditorGUILayout.Popup("Switch To:", myInspector.switchInt, myInspector.switchKind);
			}
			SerializedObject serTarget = new SerializedObject(target);
			SerializedProperty lightsObjList = serTarget.FindProperty("lightsToSwitch");
			EditorGUILayout.PropertyField(lightsObjList, new GUIContent("Lights to switch"), true);
			serTarget.ApplyModifiedProperties();
		}
		
		if(myInspector.interactionInt == 2){
			myInspector.messageToSend = EditorGUILayout.TextField("Message To Send:", myInspector.messageToSend);
			myInspector.sendMessageTo = (GameObject) EditorGUILayout.ObjectField("Send Message To:", myInspector.sendMessageTo, typeof(GameObject), true);
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		if(myInspector.interactionInt == 0){
			if(myInspector.sendMessOnEnd){
				myInspector.sendMessageAfter = EditorGUILayout.FloatField("Send Message After", myInspector.sendMessageAfter);
				myInspector.messageToSend = EditorGUILayout.TextField("Message To Send:", myInspector.messageToSend);
				myInspector.sendMessageTo = (GameObject) EditorGUILayout.ObjectField("Send Message To:", myInspector.sendMessageTo, typeof(GameObject), true);
			}
		}

		if(myInspector.interactionInt != 1){
			if(myInspector.saveState){
				GUILayout.Space(10.0f); //Put some spece between different elements

				myInspector.keyToSave = EditorGUILayout.TextField("Key To Save:", myInspector.keyToSave);
			}
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements
	}
}