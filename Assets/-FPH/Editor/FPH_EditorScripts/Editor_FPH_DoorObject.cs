using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_DoorObject))] 
public class Editor_FPH_DoorObject : Editor {
	
	private string language = "English";
	
	
	public override void OnInspectorGUI() {
		FPH_DoorObject myInspector = (FPH_DoorObject) target;

		
		GUILayout.Space(10.0f); //Put some spece between different elements

		GUILayout.BeginHorizontal();
		EditorGUIUtility.labelWidth = 60.0f;
		myInspector.openDoorAniString = EditorGUILayout.TextField("Open Ani:", myInspector.openDoorAniString, GUILayout.MinWidth(100.0f), GUILayout.MinWidth(100.0f));
		myInspector.closeDoorAniString = EditorGUILayout.TextField("Close Ani:", myInspector.closeDoorAniString, GUILayout.MinWidth(100.0f), GUILayout.MinWidth(100.0f));
		GUILayout.EndHorizontal();

		GUILayout.Space(10.0f); //Put some spece between different elements
		
		GUILayout.BeginHorizontal();
		EditorGUIUtility.labelWidth = 70.0f;
		myInspector.autoclose = EditorGUILayout.Toggle("Autoclose?:", myInspector.autoclose);
		if(myInspector.autoclose){
			myInspector.closeAfter = EditorGUILayout.FloatField("Close after:", myInspector.closeAfter);
		}
		GUILayout.EndHorizontal();
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 65.0f;
		myInspector.doorType = EditorGUILayout.Popup("Door Type:", myInspector.doorType, myInspector.doorTypeArray);

		GUILayout.Space(10.0f); //Put some spece between different elements
		
		EditorGUIUtility.labelWidth = 85.0f;
		myInspector.secToOserve = EditorGUILayout.FloatField("Show text for: ", myInspector.secToOserve);
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 120.0f;

		myInspector.objectToAnimate = (GameObject) EditorGUILayout.ObjectField("Object To Animate: ", myInspector.objectToAnimate, typeof(GameObject), true);
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		GUILayout.BeginHorizontal();
		EditorGUIUtility.labelWidth = 75.0f;
		myInspector.openSound = (AudioClip) EditorGUILayout.ObjectField("Open Sound: ", myInspector.openSound, typeof(AudioClip), true);
		myInspector.closeSound = (AudioClip) EditorGUILayout.ObjectField("Close Sound: ", myInspector.closeSound, typeof(AudioClip), true);
		GUILayout.EndHorizontal();

		EditorGUIUtility.labelWidth = 110.0f;

		#region NormallyOpen
		if(myInspector.doorType == 0){
			GUILayout.Space(10.0f); //Put some spece between different elements

			EditorGUIUtility.labelWidth = 100.0f;
			myInspector.canBeObserved = EditorGUILayout.Toggle("Is observable?", myInspector.canBeObserved);

			GUILayout.Space(10.0f); //Put some spece between different elements

			if(myInspector.canBeObserved){
				EditorGUIUtility.labelWidth = 85.0f;
				myInspector.observeInt = EditorGUILayout.Popup("Observe Type:", myInspector.observeInt, myInspector.observeKind);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				if(myInspector.observeInt == 1){
					EditorGUIUtility.labelWidth = 92.0f;
					
					myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("InGame Camera: ", myInspector.inGameCamera, typeof(GameObject), true);
					myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Zoom Camera: ", myInspector.closeupCamera, typeof(GameObject), true);
					myInspector.interactingCollider = (GameObject) EditorGUILayout.ObjectField("Interact. Coll: ", myInspector.interactingCollider, typeof(GameObject), true);
					
					GUILayout.Space(10.0f); //Put some spece between different elements
				}
				
				EditorGUIUtility.labelWidth = 75.0f;

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
		
		#endregion

		#region Locked
		if(myInspector.doorType == 1){
			EditorGUIUtility.labelWidth = 85.0f;
			myInspector.lockedSound = (AudioClip) EditorGUILayout.ObjectField("Locked Sound: ", myInspector.lockedSound, typeof(AudioClip), true);

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

			GUILayout.Space(10.0f); //Put some spece between different elements

			if(language == "English"){
				EditorGUILayout.LabelField("Locked Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_English = EditorGUILayout.TextArea(myInspector.lockedMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Locked Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Italian = EditorGUILayout.TextArea(myInspector.lockedMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Locked Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Spanish = EditorGUILayout.TextArea(myInspector.lockedMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Locked Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_German = EditorGUILayout.TextArea(myInspector.lockedMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Locked Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_French = EditorGUILayout.TextArea(myInspector.lockedMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Locked Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Chinese = EditorGUILayout.TextArea(myInspector.lockedMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Locked Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Japanese = EditorGUILayout.TextArea(myInspector.lockedMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Locked Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Russian = EditorGUILayout.TextArea(myInspector.lockedMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
		}
		#endregion
		
		#region EquipObject
		if(myInspector.doorType == 2){
			EditorGUIUtility.labelWidth = 85.0f;
			myInspector.lockedSound = (AudioClip) EditorGUILayout.ObjectField("Locked Sound: ", myInspector.lockedSound, typeof(AudioClip), true);

			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 130.0f;
			myInspector.neededObject_Name = EditorGUILayout.TextField("Needed Object Name:", myInspector.neededObject_Name, GUILayout.MinWidth(100.0f), GUILayout.MinWidth(100.0f));
			myInspector.hasBeenUnlockedKey = EditorGUILayout.TextField("Key when unlocked:", myInspector.hasBeenUnlockedKey);
			myInspector.removeItemWhenUsed = EditorGUILayout.Toggle("Remove item after use:", myInspector.removeItemWhenUsed);
			EditorGUIUtility.labelWidth = 100.0f;
			
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

			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(language == "English"){
				EditorGUILayout.LabelField("Locked Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_English = EditorGUILayout.TextArea(myInspector.lockedMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Locked Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Italian = EditorGUILayout.TextArea(myInspector.lockedMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Locked Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Spanish = EditorGUILayout.TextArea(myInspector.lockedMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Locked Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_German = EditorGUILayout.TextArea(myInspector.lockedMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Locked Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_French = EditorGUILayout.TextArea(myInspector.lockedMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Locked Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Chinese = EditorGUILayout.TextArea(myInspector.lockedMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Locked Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Japanese = EditorGUILayout.TextArea(myInspector.lockedMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Locked Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Russian = EditorGUILayout.TextArea(myInspector.lockedMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(language == "English"){
				EditorGUILayout.LabelField("Wrong Item Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_English = EditorGUILayout.TextArea(myInspector.wrongItemMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Wrong Item Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Italian = EditorGUILayout.TextArea(myInspector.wrongItemMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Wrong Item Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Spanish = EditorGUILayout.TextArea(myInspector.wrongItemMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Wrong Item Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_German = EditorGUILayout.TextArea(myInspector.wrongItemMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Wrong Item Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_French = EditorGUILayout.TextArea(myInspector.wrongItemMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Wrong Item Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Chinese = EditorGUILayout.TextArea(myInspector.wrongItemMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Wrong Item Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Japanese = EditorGUILayout.TextArea(myInspector.wrongItemMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Wrong Item Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.wrongItemMessage_Russian = EditorGUILayout.TextArea(myInspector.wrongItemMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			
			myInspector.canBeObserved = EditorGUILayout.Toggle("Is observable?", myInspector.canBeObserved);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(myInspector.canBeObserved){
				EditorGUIUtility.labelWidth = 85.0f;
				myInspector.observeInt = EditorGUILayout.Popup("Observe Type:", myInspector.observeInt, myInspector.observeKind);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				if(myInspector.observeInt == 1){
					EditorGUIUtility.labelWidth = 92.0f;
					
					myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("InGame Camera: ", myInspector.inGameCamera, typeof(GameObject), true);
					myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Zoom Camera: ", myInspector.closeupCamera, typeof(GameObject), true);
					myInspector.interactingCollider = (GameObject) EditorGUILayout.ObjectField("Interact. Coll: ", myInspector.interactingCollider, typeof(GameObject), true);
					
					GUILayout.Space(10.0f); //Put some spece between different elements
				}
				
				EditorGUIUtility.labelWidth = 75.0f;

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
		#endregion
		
		#region NeedKey
		if(myInspector.doorType == 3){
			EditorGUIUtility.labelWidth = 85.0f;
			myInspector.lockedSound = (AudioClip) EditorGUILayout.ObjectField("Locked Sound: ", myInspector.lockedSound, typeof(AudioClip), true);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			EditorGUIUtility.labelWidth = 100.0f;
			myInspector.neededKey = EditorGUILayout.TextField("Needed Bool Key:", myInspector.neededKey, GUILayout.MinWidth(100.0f), GUILayout.MinWidth(100.0f));
			EditorGUIUtility.labelWidth = 100.0f;
			
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
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(language == "English"){
				EditorGUILayout.LabelField("Locked Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_English = EditorGUILayout.TextArea(myInspector.lockedMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Locked Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Italian = EditorGUILayout.TextArea(myInspector.lockedMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Locked Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Spanish = EditorGUILayout.TextArea(myInspector.lockedMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Locked Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_German = EditorGUILayout.TextArea(myInspector.lockedMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Locked Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_French = EditorGUILayout.TextArea(myInspector.lockedMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Locked Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Chinese = EditorGUILayout.TextArea(myInspector.lockedMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Locked Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Japanese = EditorGUILayout.TextArea(myInspector.lockedMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Locked Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.lockedMessage_Russian = EditorGUILayout.TextArea(myInspector.lockedMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}

			myInspector.canBeObserved = EditorGUILayout.Toggle("Is observable?", myInspector.canBeObserved);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(myInspector.canBeObserved){
				EditorGUIUtility.labelWidth = 85.0f;
				myInspector.observeInt = EditorGUILayout.Popup("Observe Type:", myInspector.observeInt, myInspector.observeKind);

				GUILayout.Space(10.0f); //Put some spece between different elements
				
				if(myInspector.observeInt == 1){
					EditorGUIUtility.labelWidth = 92.0f;
					
					myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("InGame Camera: ", myInspector.inGameCamera, typeof(GameObject), true);
					myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Zoom Camera: ", myInspector.closeupCamera, typeof(GameObject), true);
					myInspector.interactingCollider = (GameObject) EditorGUILayout.ObjectField("Interact. Coll: ", myInspector.interactingCollider, typeof(GameObject), true);
					
					GUILayout.Space(10.0f); //Put some spece between different elements
				}
				
				EditorGUIUtility.labelWidth = 75.0f;

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
		#endregion

		
		GUILayout.Space(10.0f); //Put some spece between different elements
	}
}