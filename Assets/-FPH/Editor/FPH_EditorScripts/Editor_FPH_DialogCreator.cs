using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_DialogCreator))] 
public class Editor_FPH_DialogCreator : Editor {
	
	private string language = "English";
	private bool showChangeChara = false;
	private bool showMoveChara = false;
	private bool showFadeSprite = false;
	private bool showFlip = false;
	private bool showPlayAudio = false;
	private bool showDialogCamera = false;
	
	public override void OnInspectorGUI() {
		FPH_DialogCreator myInspector = (FPH_DialogCreator) target;
		
		GUILayout.BeginHorizontal();
		//Choose what kind of dialog you want to create
		EditorGUIUtility.labelWidth = 80.0f;
		myInspector.dialogType = EditorGUILayout.Popup("Dialog Type:", myInspector.dialogType, myInspector.dialogTypeArray);
		
		//What will be the ID of the current dialog?
		EditorGUIUtility.labelWidth = 27.0f;
		myInspector.dialogID = EditorGUILayout.IntField("ID#:", myInspector.dialogID, GUILayout.ExpandWidth(false));
		
		if(myInspector.dialogType == 0 || myInspector.dialogType == 2){
			EditorGUIUtility.labelWidth = 75.0f;
			myInspector.moveToID = EditorGUILayout.IntField("Move to ID#: ", myInspector.moveToID, GUILayout.ExpandWidth(false));
		}
		GUILayout.EndHorizontal();
		
		EditorGUIUtility.labelWidth = 100.0f;
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		showChangeChara = EditorGUILayout.Foldout(showChangeChara, "Change character(s) sprite");
		if(showChangeChara){
			EditorGUI.indentLevel = 1;
			EditorGUIUtility.labelWidth = 230.0f;
			myInspector.changeCharaSprite = EditorGUILayout.Toggle("What to change character(s) sprite?", myInspector.changeCharaSprite);
			if(myInspector.changeCharaSprite){
				EditorGUIUtility.labelWidth = 100.0f;
				SerializedObject serTarget = new SerializedObject(target);
				SerializedProperty charaList = serTarget.FindProperty("characters");
				EditorGUILayout.PropertyField(charaList, new GUIContent("Chatacters"), true);
				
				SerializedProperty spriteList = serTarget.FindProperty("charaSprite");
				EditorGUILayout.PropertyField(spriteList, new GUIContent("Character Sprite"), true);
				
				serTarget.ApplyModifiedProperties();
			}
			EditorGUI.indentLevel = 0;
		}
		
		showMoveChara = EditorGUILayout.Foldout(showMoveChara, "Move character(s)");
		if(showMoveChara){
			EditorGUI.indentLevel = 1;
			EditorGUIUtility.labelWidth = 230.0f;
			myInspector.moveChara = EditorGUILayout.Toggle("Want to move character(s)?", myInspector.moveChara);
			if(myInspector.moveChara){
				EditorGUIUtility.labelWidth = 100.0f;
				SerializedObject serTarget = new SerializedObject(target);
				SerializedProperty charaMoveList = serTarget.FindProperty("charactersToMove");
				EditorGUILayout.PropertyField(charaMoveList, new GUIContent("Chatacters to move"), true);
				
				SerializedProperty newPosList = serTarget.FindProperty("charactersNewPosition");
				EditorGUILayout.PropertyField(newPosList, new GUIContent("New Positions"), true);
				
				SerializedProperty timesList = serTarget.FindProperty("timesToMove");
				EditorGUILayout.PropertyField(timesList, new GUIContent("Times"), true);
				
				serTarget.ApplyModifiedProperties();
			}
			EditorGUI.indentLevel = 0;
		}
		
		showFadeSprite = EditorGUILayout.Foldout(showFadeSprite, "Fade character(s)");
		if(showFadeSprite){
			EditorGUI.indentLevel = 1;
			EditorGUIUtility.labelWidth = 230.0f;
			myInspector.fadeSprite = EditorGUILayout.Toggle("Want to fade character(s)?", myInspector.fadeSprite);
			if(myInspector.fadeSprite){
				EditorGUIUtility.labelWidth = 100.0f;
				SerializedObject serTarget = new SerializedObject(target);
				SerializedProperty spriteToFadeList = serTarget.FindProperty("spriteToFade");
				EditorGUILayout.PropertyField(spriteToFadeList, new GUIContent("Chatacters to fade"), true);
				
				SerializedProperty fadeValList = serTarget.FindProperty("fadeToVal");
				EditorGUILayout.PropertyField(fadeValList, new GUIContent("Fade to Value"), true);
				
				SerializedProperty timesFadeList = serTarget.FindProperty("timesToFade");
				EditorGUILayout.PropertyField(timesFadeList, new GUIContent("Times"), true);
				
				serTarget.ApplyModifiedProperties();
			}
			EditorGUI.indentLevel = 0;
		}
		
		showFlip = EditorGUILayout.Foldout(showFlip, "Rotate character(s)");
		if(showFlip){
			EditorGUI.indentLevel = 1;
			EditorGUIUtility.labelWidth = 230.0f;
			myInspector.flipChara = EditorGUILayout.Toggle("Want to rotate character?", myInspector.flipChara);
			if(myInspector.flipChara){
				EditorGUIUtility.labelWidth = 100.0f;
				SerializedObject rotTarget = new SerializedObject(target);
				SerializedProperty charaToFlipList = rotTarget.FindProperty("charaToFlip");
				EditorGUILayout.PropertyField(charaToFlipList, new GUIContent("Chatacters to rotate"), true);
				
				SerializedProperty rotToList = rotTarget.FindProperty("rotateCharaTo");
				EditorGUILayout.PropertyField(rotToList, new GUIContent("Rotate to"), true);
				
				SerializedProperty rotInTimeList = rotTarget.FindProperty("rotateInTime");
				EditorGUILayout.PropertyField(rotInTimeList, new GUIContent("Rotate chara in time"), true);
				
				rotTarget.ApplyModifiedProperties();
			}
			EditorGUI.indentLevel = 0;
		}
		
		showPlayAudio = EditorGUILayout.Foldout(showPlayAudio, "Play Audio");
		if(showPlayAudio){
			EditorGUI.indentLevel = 1;
			EditorGUIUtility.labelWidth = 150.0f;
			
			if(myInspector.dialogType == 0){
				myInspector.charaVoiceClip = (AudioClip) EditorGUILayout.ObjectField("Character voice: ", myInspector.charaVoiceClip, typeof(AudioClip), true);
			}
			myInspector.gameplayFxClip = (AudioClip) EditorGUILayout.ObjectField("Sound Fx: ", myInspector.gameplayFxClip, typeof(AudioClip), true);
			EditorGUI.indentLevel = 0;
		}
		
		showDialogCamera = EditorGUILayout.Foldout(showDialogCamera, "Dialog cameras");
		if(showDialogCamera){
			EditorGUI.indentLevel = 1;
			EditorGUIUtility.labelWidth = 230.0f;
			myInspector.useDialogCameras = EditorGUILayout.Toggle("Use dialog cameras?", myInspector.useDialogCameras);
			if(myInspector.useDialogCameras){
				EditorGUIUtility.labelWidth = 150.0f;
				if(myInspector.dialogID == 0){
					EditorGUILayout.HelpBox("Since current dialog ID is 0 you must assign player camera to 'Camera to Deactivate'.", MessageType.Info, true);
				}
				myInspector.cameraToDeactivate = (GameObject) EditorGUILayout.ObjectField("Camera to Deactivate:", myInspector.cameraToDeactivate, typeof(GameObject), true);
				myInspector.cameraToActivate = (GameObject) EditorGUILayout.ObjectField("Camera to Activate:", myInspector.cameraToActivate, typeof(GameObject), true);
			}
			EditorGUI.indentLevel = 0;
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("English", GUILayout.Width(80.0f))){
			language = "English";
		}
		if(GUILayout.Button("Italian", GUILayout.Width(80.0f))){
			language = "Italian";
		}
		if(GUILayout.Button("Spanish", GUILayout.Width(80.0f))){
			language = "Spanish";
		}
		if(GUILayout.Button("German", GUILayout.Width(80.0f))){
			language = "German";
		}
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("French", GUILayout.Width(80.0f))){
			language = "French";
		}
		if(GUILayout.Button("Japanese", GUILayout.Width(80.0f))){
			language = "Japanese";
		}
		if(GUILayout.Button("Chinese", GUILayout.Width(80.0f))){
			language = "Chinese";
		}
		if(GUILayout.Button("Russian", GUILayout.Width(80.0f))){
			language = "Russian";
		}
		GUILayout.EndHorizontal();
		
		#region StandardDialog
		//if Dialog type is standard show the dialog text area
		if(myInspector.dialogType == 0){
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 100.0f;
			myInspector.characterName = EditorGUILayout.TextField("Character Name:", myInspector.characterName, GUILayout.MaxWidth(410.0f), GUILayout.MinWidth(100.0f));
			
			if(language == "English"){
				EditorGUILayout.LabelField("Dialog Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.dialogText = EditorGUILayout.TextArea(myInspector.dialogText, GUILayout.Height(150.0f), GUILayout.MinWidth(100.0f), GUILayout.MaxWidth(595.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Dialog Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.dialogTextItalian = EditorGUILayout.TextArea(myInspector.dialogTextItalian, GUILayout.Height(150.0f), GUILayout.MinWidth(100.0f), GUILayout.MaxWidth(595.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Dialog Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.dialogText_Spanish = EditorGUILayout.TextArea(myInspector.dialogText_Spanish, GUILayout.Height(150.0f), GUILayout.MinWidth(100.0f), GUILayout.MaxWidth(595.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Dialog Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.dialogText_German = EditorGUILayout.TextArea(myInspector.dialogText_German, GUILayout.Height(150.0f), GUILayout.MinWidth(100.0f), GUILayout.MaxWidth(595.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Dialog Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.dialogText_French = EditorGUILayout.TextArea(myInspector.dialogText_French, GUILayout.Height(150.0f), GUILayout.MinWidth(100.0f), GUILayout.MaxWidth(595.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Dialog Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.dialogText_Japanese = EditorGUILayout.TextArea(myInspector.dialogText_Japanese, GUILayout.Height(150.0f), GUILayout.MinWidth(100.0f), GUILayout.MaxWidth(595.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Dialog Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.dialogText_Chinese = EditorGUILayout.TextArea(myInspector.dialogText_Chinese, GUILayout.Height(150.0f), GUILayout.MinWidth(100.0f), GUILayout.MaxWidth(595.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Dialog Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.dialogText_Russian = EditorGUILayout.TextArea(myInspector.dialogText_Russian, GUILayout.Height(150.0f), GUILayout.MinWidth(100.0f), GUILayout.MaxWidth(595.0f));
				EditorGUI.indentLevel = 0;
			}
			
			EditorGUIUtility.labelWidth = 75.0f;
			myInspector.textColor = EditorGUILayout.ColorField("Text color:", myInspector.textColor);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 160.0f;
			
			myInspector.wantToDestroyObj = EditorGUILayout.Toggle("Destroy object?", myInspector.wantToDestroyObj);
			if(myInspector.wantToDestroyObj){
				EditorGUI.indentLevel = 1;
				myInspector.objToDestroy = (GameObject) EditorGUILayout.ObjectField("Object to destroy:", myInspector.objToDestroy, typeof(GameObject), true);
				EditorGUI.indentLevel = 0;
			}
			
			myInspector.wantToSendMessageToObj = EditorGUILayout.Toggle("Send message to object?", myInspector.wantToSendMessageToObj);
			if(myInspector.wantToSendMessageToObj){
				EditorGUI.indentLevel = 1;
				myInspector.objToSendMessage = (GameObject) EditorGUILayout.ObjectField("Send message to:", myInspector.objToSendMessage, typeof(GameObject), true);
				myInspector.messageToSend = EditorGUILayout.TextField("Message to send:", myInspector.messageToSend);
				EditorGUI.indentLevel = 0;
			}
			
			myInspector.isLastOne = EditorGUILayout.Toggle("Is this the last dialog?", myInspector.isLastOne);
			if(myInspector.isLastOne){
				EditorGUI.indentLevel = 1;
				myInspector.colorReset = EditorGUILayout.Toggle("Want to reset color?", myInspector.colorReset);
				if(myInspector.colorReset){
					myInspector.resetColor = EditorGUILayout.ColorField("Reset color:", myInspector.resetColor);
				}
				
				myInspector.switchDialog = EditorGUILayout.Toggle("Want to switch dialog?", myInspector.switchDialog);
				if(myInspector.switchDialog){
					EditorGUI.indentLevel = 2;
					myInspector.newDialog = (GameObject) EditorGUILayout.ObjectField("New dialog:", myInspector.newDialog, typeof(GameObject), true);
					myInspector.destroyOnEnd = EditorGUILayout.Toggle("Destroy dialog on end?", myInspector.destroyOnEnd);
					EditorGUI.indentLevel = 1;
				}
				
				if(!myInspector.switchDialog){
					myInspector.destroyOnEnd = EditorGUILayout.Toggle("Destroy dialog on end?", myInspector.destroyOnEnd);
				}
				EditorGUI.indentLevel = 0;
			}
			if(!myInspector.isLastOne){
				myInspector.destroyOnEnd = false;
			}
		}
		#endregion
		
		#region MultipleQuestion
		// if Dialog Type is multiple choise show different option
		if(myInspector.dialogType == 1){
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 180.0f;
			//QUESTION ONE
			if(language == "English"){
				myInspector.questionOne = EditorGUILayout.TextField("First Question (English): ", myInspector.questionOne);
			}
			if(language == "Italian"){
				myInspector.questionOne_Italian = EditorGUILayout.TextField("First Question (Italian): ", myInspector.questionOne_Italian);
			}
			if(language == "Spanish"){
				myInspector.questionOne_Spanish = EditorGUILayout.TextField("First Question (Spanish): ", myInspector.questionOne_Spanish);
			}
			if(language == "German"){
				myInspector.questionOne_German = EditorGUILayout.TextField("First Question (German): ", myInspector.questionOne_German);
			}
			if(language == "French"){
				myInspector.questionOne_French = EditorGUILayout.TextField("First Question (French): ", myInspector.questionOne_French);
			}
			if(language == "Japanese"){
				myInspector.questionOne_Japanese = EditorGUILayout.TextField("First Question (Japanese): ", myInspector.questionOne_Japanese);
			}
			if(language == "Chinese"){
				myInspector.questionOne_Chinese = EditorGUILayout.TextField("First Question (Chinese): ", myInspector.questionOne_Chinese);
			}
			if(language == "Russian"){
				myInspector.questionOne_Russian = EditorGUILayout.TextField("First Question (Russian): ", myInspector.questionOne_Russian);
			}
			myInspector.questionOneToID = EditorGUILayout.IntField("First question brings to ID: ", myInspector.questionOneToID);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			//QUESTION TWO
			if(language == "English"){
				myInspector.questionTwo = EditorGUILayout.TextField("Second Question (English): ", myInspector.questionTwo);
			}
			if(language == "Italian"){
				myInspector.questionTwo_Italian = EditorGUILayout.TextField("Second Question (Italian): ", myInspector.questionTwo_Italian);
			}
			if(language == "Spanish"){
				myInspector.questionTwo_Spanish = EditorGUILayout.TextField("Second Question (Spanish): ", myInspector.questionTwo_Spanish);
			}
			if(language == "German"){
				myInspector.questionTwo_German = EditorGUILayout.TextField("Second Question (German): ", myInspector.questionTwo_German);
			}
			if(language == "French"){
				myInspector.questionTwo_French = EditorGUILayout.TextField("Second Question (French): ", myInspector.questionTwo_French);
			}
			if(language == "Japanese"){
				myInspector.questionTwo_Japanese = EditorGUILayout.TextField("Second Question (Japanese): ", myInspector.questionTwo_Japanese);
			}
			if(language == "Chinese"){
				myInspector.questionTwo_Chinese = EditorGUILayout.TextField("Second Question (Chinese): ", myInspector.questionTwo_Chinese);
			}
			if(language == "Russian"){
				myInspector.questionTwo_Russian = EditorGUILayout.TextField("Second Question (Russian): ", myInspector.questionTwo_Russian);
			}
			myInspector.questionTwoToID = EditorGUILayout.IntField("Second question brings to ID: ", myInspector.questionTwoToID);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			//QUESTION THREE
			if(language == "English"){
				myInspector.questionThree = EditorGUILayout.TextField("Third Question (English): ", myInspector.questionThree);
			}
			if(language == "Italian"){
				myInspector.questionThree_Italian = EditorGUILayout.TextField("Third Question (Italian): ", myInspector.questionThree_Italian);
			}
			if(language == "Spanish"){
				myInspector.questionThree_Spanish = EditorGUILayout.TextField("Third Question (Spanish): ", myInspector.questionThree_Spanish);
			}
			if(language == "German"){
				myInspector.questionThree_German = EditorGUILayout.TextField("Third Question (German): ", myInspector.questionThree_German);
			}
			if(language == "French"){
				myInspector.questionThree_French = EditorGUILayout.TextField("Third Question (French): ", myInspector.questionThree_French);
			}
			if(language == "Japanese"){
				myInspector.questionThree_Japanese = EditorGUILayout.TextField("Third Question (Japanese): ", myInspector.questionThree_Japanese);
			}
			if(language == "Chinese"){
				myInspector.questionThree_Chinese = EditorGUILayout.TextField("Third Question (Chinese): ", myInspector.questionThree_Chinese);
			}
			if(language == "Russian"){
				myInspector.questionThree_Russian = EditorGUILayout.TextField("Third Question (Russian): ", myInspector.questionThree_Russian);
			}
			myInspector.questionThreeToID = EditorGUILayout.IntField("Third question brings to ID: ", myInspector.questionThreeToID);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			//QUESTION FOUR
			if(language == "English"){
				myInspector.questionFour = EditorGUILayout.TextField("Fourth Question (English): ", myInspector.questionFour);
			}
			if(language == "Italian"){
				myInspector.questionFour_Italian = EditorGUILayout.TextField("Fourth Question (Italian): ", myInspector.questionFour_Italian);
			}
			if(language == "Spanish"){
				myInspector.questionFour_Spanish = EditorGUILayout.TextField("Fourth Question (Spanish): ", myInspector.questionFour_Spanish);
			}
			if(language == "German"){
				myInspector.questionFour_German = EditorGUILayout.TextField("Fourth Question (German): ", myInspector.questionFour_German);
			}
			if(language == "French"){
				myInspector.questionFour_French = EditorGUILayout.TextField("Fourth Question (French): ", myInspector.questionFour_French);
			}
			if(language == "Japanese"){
				myInspector.questionFour_Japanese = EditorGUILayout.TextField("Fourth Question (Japanese): ", myInspector.questionFour_Japanese);
			}
			if(language == "Chinese"){
				myInspector.questionFour_Chinese = EditorGUILayout.TextField("Fourth Question (Chinese): ", myInspector.questionFour_Chinese);
			}
			if(language == "Russian"){
				myInspector.questionFour_Russian = EditorGUILayout.TextField("Fourth Question (Russian): ", myInspector.questionFour_Russian);
			}
			myInspector.questionFourToID = EditorGUILayout.IntField("Fourth question brings to ID: ", myInspector.questionFourToID);
		}
		#endregion
		
		GUILayout.Space(30.0f); //Put some spece between different elements
		
		if(GUILayout.Button("Add Sentence", GUILayout.MinWidth(50.0f), GUILayout.Height(30.0f))){
			myInspector.AssignScript();
		}
	}
}