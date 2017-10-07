using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_ObserveObject))]
public class Editor_FPH_ObserveObject : Editor {
	
	private string language = "English";
	
	public override void OnInspectorGUI(){
		FPH_ObserveObject myInspector = (FPH_ObserveObject) target;
		
		EditorGUIUtility.labelWidth = 85.0f;
		myInspector.observeInt = EditorGUILayout.Popup("Observe Type:", myInspector.observeInt, myInspector.observeKind);

		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 75.0f;
		myInspector.secToOserve = EditorGUILayout.FloatField("Observe for: ", myInspector.secToOserve);

		if(myInspector.observeInt == 1){
			EditorGUIUtility.labelWidth = 92.0f;
			GUILayout.Space(10.0f); //Put some spece between different elements

			myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("Ingame Camera: ", myInspector.inGameCamera, typeof(GameObject), true);
			myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Zoom Camera: ", myInspector.closeupCamera, typeof(GameObject), true);
			myInspector.interactingCollider = (GameObject) EditorGUILayout.ObjectField("Interact. Coll: ", myInspector.interactingCollider, typeof(GameObject), true);
		}

		EditorGUIUtility.labelWidth = 75.0f;

		GUILayout.Space(10.0f); //Put some spece between different elements
		
		GUILayout.BeginHorizontal(GUILayout.MinWidth(60.0f));
		if(GUILayout.Button("English", GUILayout.Width(80.0f))){
			language = "English";
		}
		if(GUILayout.Button("Italian", GUILayout.Width(80.0f))){
			language = "Italian";
		}
		if(GUILayout.Button("Spanish", GUILayout.Width(80.0f))){
			language = "Spanish";
		}
		if(GUILayout.Button("Russian", GUILayout.Width(80.0f))){
			language = "Russian";
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(GUILayout.MinWidth(60.0f));
		if(GUILayout.Button("German", GUILayout.Width(80.0f))){
			language = "German";
		}
		if(GUILayout.Button("French", GUILayout.Width(80.0f))){
			language = "French";
		}
		if(GUILayout.Button("Chinese", GUILayout.Width(80.0f))){
			language = "Chinese";
		}
		if(GUILayout.Button("Japanese", GUILayout.Width(80.0f))){
			language = "Japanese";
		}
		GUILayout.EndHorizontal();
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		
		if(language == "English"){
			EditorGUILayout.LabelField("Text (English):");
			EditorGUI.indentLevel = 5;
			myInspector.observMessage_English = EditorGUILayout.TextArea(myInspector.observMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Italian"){
			EditorGUILayout.LabelField("Text (Italian):");
			EditorGUI.indentLevel = 5;
			myInspector.observMessage_Italian = EditorGUILayout.TextArea(myInspector.observMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Spanish"){
			EditorGUILayout.LabelField("Text (Spanish):");
			EditorGUI.indentLevel = 5;
			myInspector.observMessage_Spanish = EditorGUILayout.TextArea(myInspector.observMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "German"){
			EditorGUILayout.LabelField("Text (German):");
			EditorGUI.indentLevel = 5;
			myInspector.observMessage_German = EditorGUILayout.TextArea(myInspector.observMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "French"){
			EditorGUILayout.LabelField("Text (French):");
			EditorGUI.indentLevel = 5;
			myInspector.observMessage_French = EditorGUILayout.TextArea(myInspector.observMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Chinese"){
			EditorGUILayout.LabelField("Text (Chinese):");
			EditorGUI.indentLevel = 5;
			myInspector.observMessage_Chinese = EditorGUILayout.TextArea(myInspector.observMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Japanese"){
			EditorGUILayout.LabelField("Text (Japanese):");
			EditorGUI.indentLevel = 5;
			myInspector.observMessage_Japanese = EditorGUILayout.TextArea(myInspector.observMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Russian"){
			EditorGUILayout.LabelField("Text (Russian):");
			EditorGUI.indentLevel = 5;
			myInspector.observMessage_Russian = EditorGUILayout.TextArea(myInspector.observMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
	}
}
