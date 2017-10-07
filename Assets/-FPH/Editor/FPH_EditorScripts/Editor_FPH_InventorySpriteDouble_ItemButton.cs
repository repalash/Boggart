using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_InventorySpriteDouble_ItemButton))] 
public class Editor_FPH_InventorySpriteDouble_ItemButton : Editor {
	
	private string language = "English";
	
	public override void OnInspectorGUI(){
		FPH_InventorySpriteDouble_ItemButton myInspector = (FPH_InventorySpriteDouble_ItemButton) target;
		
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
		
		EditorGUIUtility.labelWidth = 150.0f;
		if(language == "English"){
			myInspector.obj01Name_English = EditorGUILayout.TextField("Object01 Name (English):", myInspector.obj01Name_English);
			myInspector.obj02Name_English = EditorGUILayout.TextField("Object02 Name (English):", myInspector.obj02Name_English);
		}
		if(language == "Italian"){
			myInspector.obj01Name_Italian = EditorGUILayout.TextField("Object01 Name (Italian):", myInspector.obj01Name_Italian);
			myInspector.obj02Name_Italian = EditorGUILayout.TextField("Object02 Name (Italian):", myInspector.obj02Name_Italian);
		}
		if(language == "Spanish"){
			myInspector.obj01Name_Spanish = EditorGUILayout.TextField("Object01 Name (Spanish):", myInspector.obj01Name_Spanish);
			myInspector.obj02Name_Spanish = EditorGUILayout.TextField("Object02 Name (Spanish):", myInspector.obj02Name_Spanish);
		}
		if(language == "German"){
			myInspector.obj01Name_German = EditorGUILayout.TextField("Object01 Name (German):", myInspector.obj01Name_German);
			myInspector.obj02Name_German = EditorGUILayout.TextField("Object02 Name (German):", myInspector.obj02Name_German);
		}
		if(language == "French"){
			myInspector.obj01Name_French = EditorGUILayout.TextField("Object01 Name (French):", myInspector.obj01Name_French);
			myInspector.obj02Name_French = EditorGUILayout.TextField("Object02 Name (French):", myInspector.obj02Name_French);
		}
		if(language == "Chinese"){
			myInspector.obj01Name_Chinese = EditorGUILayout.TextField("Object01 Name (Chinese):", myInspector.obj01Name_Chinese);
			myInspector.obj02Name_Chinese = EditorGUILayout.TextField("Object02 Name (Chinese):", myInspector.obj02Name_Chinese);
		}
		if(language == "Japanese"){
			myInspector.obj01Name_Japanese = EditorGUILayout.TextField("Object01 Name (Japanese):", myInspector.obj01Name_Japanese);
			myInspector.obj02Name_Japanese = EditorGUILayout.TextField("Object02 Name (Japanese):", myInspector.obj02Name_Japanese);
		}
		if(language == "Russian"){
			myInspector.obj01Name_Russian = EditorGUILayout.TextField("Object01 Name (Russian):", myInspector.obj01Name_Russian);
			myInspector.obj02Name_Russian = EditorGUILayout.TextField("Object02 Name (Russian):", myInspector.obj02Name_Russian);
		}

		GUILayout.Space(10.0f); //Put some spece between different elements
	}
}