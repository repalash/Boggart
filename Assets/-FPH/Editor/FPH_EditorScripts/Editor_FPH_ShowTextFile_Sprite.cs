using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_ShowTextFile_Sprite))] 
public class Editor_FPH_ShowTextFile_Sprite : Editor {

	private string language = "English";
	private Vector2 englishScroll;

	public override void OnInspectorGUI(){
		FPH_ShowTextFile_Sprite myInspector = (FPH_ShowTextFile_Sprite) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		//Choose what kind of dialog you want to create

		EditorGUIUtility.labelWidth = 100.0f;

		myInspector.neededInt = EditorGUILayout.IntField("ID#:", myInspector.neededInt, GUILayout.ExpandWidth(false));
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		myInspector.existNextPage = EditorGUILayout.Toggle("Exist next page?:", myInspector.existNextPage);
		/*
		if(myInspector.existNextPage){
			myInspector.moveToID = EditorGUILayout.IntField("Move to ID#: ", myInspector.moveToID, GUILayout.ExpandWidth(false));
		}
		*/
		EditorGUIUtility.labelWidth = 50.0f;
		
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
			myInspector.englishTextFile = EditorGUILayout.TextArea(myInspector.englishTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Italian"){
			EditorGUILayout.LabelField("Text (Italian):");
			EditorGUI.indentLevel = 5;
			myInspector.italianTextFile = EditorGUILayout.TextArea(myInspector.italianTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Spanish"){
			EditorGUILayout.LabelField("Text (Spanish):");
			EditorGUI.indentLevel = 5;
			myInspector.spanishTextFile = EditorGUILayout.TextArea(myInspector.spanishTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "German"){
			EditorGUILayout.LabelField("Text (German):");
			EditorGUI.indentLevel = 5;
			myInspector.germanTextFile = EditorGUILayout.TextArea(myInspector.germanTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "French"){
			EditorGUILayout.LabelField("Text (French):");
			EditorGUI.indentLevel = 5;
			myInspector.frenchTextFile = EditorGUILayout.TextArea(myInspector.frenchTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Chinese"){
			EditorGUILayout.LabelField("Text (Chinese):");
			EditorGUI.indentLevel = 5;
			myInspector.chineseTextFile = EditorGUILayout.TextArea(myInspector.chineseTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Japanese"){
			EditorGUILayout.LabelField("Text (Japanese):");
			EditorGUI.indentLevel = 5;
			myInspector.japaneseTextFile = EditorGUILayout.TextArea(myInspector.japaneseTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Russian"){
			EditorGUILayout.LabelField("Text (Russian):");
			EditorGUI.indentLevel = 5;
			myInspector.russianTextFile = EditorGUILayout.TextArea(myInspector.russianTextFile, GUILayout.Height(150.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		if(GUILayout.Button("Add another page", GUILayout.Width(150.0f))){
			myInspector.AssignScript();
		}
	}
}
