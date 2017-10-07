using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_ChangeLevelOrPos))]
public class Editor_FPH_ChangeLevelOrPos : Editor {
	
	private string language = "English";
	
	public override void OnInspectorGUI(){
		FPH_ChangeLevelOrPos myInspector = (FPH_ChangeLevelOrPos) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		EditorGUIUtility.labelWidth = 110.0f;
		myInspector.changeLevelUI = (GameObject) EditorGUILayout.ObjectField("Change Level UI: ", myInspector.changeLevelUI, typeof(GameObject), true);
		
		myInspector.interactionInt = EditorGUILayout.Popup("Behaviour:", myInspector.interactionInt, myInspector.interactionKind);
		
		myInspector.interactionTypeInt = EditorGUILayout.Popup("Interaction Type:", myInspector.interactionTypeInt, myInspector.interactionType);

		if(myInspector.interactionTypeInt == 0){
			myInspector.canBeObserved = EditorGUILayout.Toggle("Can be Observed:", myInspector.canBeObserved);
			
			EditorGUIUtility.labelWidth = 160.0f;
			myInspector.showChangeLevelText = EditorGUILayout.Toggle("Show Change Level Message:", myInspector.showChangeLevelText);
		}



		GUILayout.Space(10.0f); //Put some spece between different elements
		
		if(myInspector.interactionInt == 0){
			EditorGUIUtility.labelWidth = 85.0f;
			myInspector.levelToLoad = EditorGUILayout.TextField("Level To Load:", myInspector.levelToLoad);
		}
		if(myInspector.interactionInt == 1){
			EditorGUIUtility.labelWidth = 85.0f;
			myInspector.newPos = EditorGUILayout.Vector3Field("New Position:", myInspector.newPos);
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		if(myInspector.interactionTypeInt == 0){
			if(myInspector.showChangeLevelText || myInspector.canBeObserved){
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
			}
			
			if(myInspector.showChangeLevelText){
				EditorGUIUtility.labelWidth = 160.0f;
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				if(language == "English"){
					myInspector.messageToShow_English = EditorGUILayout.TextField("Change Level Text (English):", myInspector.messageToShow_English);
				}
				if(language == "Italian"){
					myInspector.messageToShow_Italian = EditorGUILayout.TextField("Change Level Text (Italian):", myInspector.messageToShow_Italian);
				}
				if(language == "Spanish"){
					myInspector.messageToShow_Spanish = EditorGUILayout.TextField("Change Level Text (Spanish):", myInspector.messageToShow_Spanish);
				}
				if(language == "German"){
					myInspector.messageToShow_German = EditorGUILayout.TextField("Change Level Text (German):", myInspector.messageToShow_German);
				}
				if(language == "French"){
					myInspector.messageToShow_French = EditorGUILayout.TextField("Change Level Text (French):", myInspector.messageToShow_French);
				}
				if(language == "Chinese"){
					myInspector.messageToShow_Chinese = EditorGUILayout.TextField("Change Level Text (Chinese):", myInspector.messageToShow_Chinese);
				}
				if(language == "Japanese"){
					myInspector.messageToShow_Japanese = EditorGUILayout.TextField("Change Level Text (Japanese):", myInspector.messageToShow_Japanese);
				}
				if(language == "Russian"){
					myInspector.messageToShow_Russian = EditorGUILayout.TextField("Change Level Text (Russian):", myInspector.messageToShow_Russian);
				}
			}
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(myInspector.canBeObserved){
				
				EditorGUIUtility.labelWidth = 85.0f;
				myInspector.observeInt = EditorGUILayout.Popup("Observe Type:", myInspector.observeInt, myInspector.observeKind);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				EditorGUIUtility.labelWidth = 75.0f;
				myInspector.secToOserve = EditorGUILayout.FloatField("Observe for: ", myInspector.secToOserve);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				if(myInspector.observeInt == 1){
					EditorGUIUtility.labelWidth = 92.0f;
					
					myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("InGame Camera: ", myInspector.inGameCamera, typeof(GameObject), true);
					myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Closeup Camera: ", myInspector.closeupCamera, typeof(GameObject), true);
					myInspector.interactingCollider = (GameObject) EditorGUILayout.ObjectField("Interact. Coll: ", myInspector.interactingCollider, typeof(GameObject), true);
					
					GUILayout.Space(10.0f); //Put some spece between different elements
				}
				
				
				if(language == "English"){
					EditorGUIUtility.labelWidth = 170.0f;
					
					GUILayout.Space(10.0f); //Put some spece between different elements
					
					if(myInspector.canBeObserved){
						EditorGUIUtility.labelWidth = 110.0f;
						
						EditorGUILayout.LabelField("Observe Text (English):");
						EditorGUI.indentLevel = 5;
						myInspector.observMessage_English = EditorGUILayout.TextArea(myInspector.observMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
						EditorGUI.indentLevel = 0;
					}
				}
				if(language == "Italian"){
					EditorGUIUtility.labelWidth = 170.0f;
					
					GUILayout.Space(10.0f); //Put some spece between different elements
					
					if(myInspector.canBeObserved){
						EditorGUIUtility.labelWidth = 110.0f;
						
						EditorGUILayout.LabelField("Observe Text (Italian):");
						EditorGUI.indentLevel = 5;
						myInspector.observMessage_Italian = EditorGUILayout.TextArea(myInspector.observMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
						EditorGUI.indentLevel = 0;
					}
				}
				if(language == "Spanish"){
					EditorGUIUtility.labelWidth = 170.0f;
					
					GUILayout.Space(10.0f); //Put some spece between different elements
					
					if(myInspector.canBeObserved){
						EditorGUIUtility.labelWidth = 110.0f;
						
						EditorGUILayout.LabelField("Observe Text (Spanish):");
						EditorGUI.indentLevel = 5;
						myInspector.observMessage_Spanish = EditorGUILayout.TextArea(myInspector.observMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
						EditorGUI.indentLevel = 0;
					}
				}
				if(language == "German"){
					EditorGUIUtility.labelWidth = 170.0f;
					
					GUILayout.Space(10.0f); //Put some spece between different elements
					
					if(myInspector.canBeObserved){
						EditorGUIUtility.labelWidth = 110.0f;
						
						EditorGUILayout.LabelField("Observe Text (German):");
						EditorGUI.indentLevel = 5;
						myInspector.observMessage_German = EditorGUILayout.TextArea(myInspector.observMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
						EditorGUI.indentLevel = 0;
					}
				}
				if(language == "French"){
					EditorGUIUtility.labelWidth = 170.0f;
					
					GUILayout.Space(10.0f); //Put some spece between different elements
					
					if(myInspector.canBeObserved){
						EditorGUIUtility.labelWidth = 110.0f;
						
						EditorGUILayout.LabelField("Observe Text (French):");
						EditorGUI.indentLevel = 5;
						myInspector.observMessage_French = EditorGUILayout.TextArea(myInspector.observMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
						EditorGUI.indentLevel = 0;
					}
				}
				if(language == "Chinese"){
					EditorGUIUtility.labelWidth = 170.0f;
					
					GUILayout.Space(10.0f); //Put some spece between different elements
					
					if(myInspector.canBeObserved){
						EditorGUIUtility.labelWidth = 110.0f;
						
						EditorGUILayout.LabelField("Observe Text (Chinese):");
						EditorGUI.indentLevel = 5;
						myInspector.observMessage_Chinese = EditorGUILayout.TextArea(myInspector.observMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
						EditorGUI.indentLevel = 0;
					}
				}
				if(language == "Japanese"){
					EditorGUIUtility.labelWidth = 170.0f;
					
					GUILayout.Space(10.0f); //Put some spece between different elements
					
					if(myInspector.canBeObserved){
						EditorGUIUtility.labelWidth = 110.0f;
						
						EditorGUILayout.LabelField("Observe Text (Japanese):");
						EditorGUI.indentLevel = 5;
						myInspector.observMessage_Japanese = EditorGUILayout.TextArea(myInspector.observMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
						EditorGUI.indentLevel = 0;
					}
				}
				if(language == "Russian"){
					EditorGUIUtility.labelWidth = 170.0f;
					
					GUILayout.Space(10.0f); //Put some spece between different elements
					
					if(myInspector.canBeObserved){
						EditorGUIUtility.labelWidth = 110.0f;
						
						EditorGUILayout.LabelField("Observe Text (Russian):");
						EditorGUI.indentLevel = 5;
						myInspector.observMessage_Russian = EditorGUILayout.TextArea(myInspector.observMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
						EditorGUI.indentLevel = 0;
					}
				}
			}
			if(myInspector.canBeObserved){
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				EditorGUIUtility.labelWidth = 112.0f;
			}
		}
	}
}
