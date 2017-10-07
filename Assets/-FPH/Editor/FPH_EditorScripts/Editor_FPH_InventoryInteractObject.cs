using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_InventoryInteractObject))] 
public class Editor_FPH_InventoryInteractObject : Editor {
	
	private string language = "English";
	
	public override void OnInspectorGUI(){
		FPH_InventoryInteractObject myInspector = (FPH_InventoryInteractObject) target;

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

		EditorGUIUtility.labelWidth = 190.0f;

		if(language == "English"){
			myInspector.objName_English = EditorGUILayout.TextField("Inventory Object Name (English):", myInspector.objName_English);
		}
		if(language == "Italian"){
			myInspector.objName_Italian = EditorGUILayout.TextField("Inventory Object Name (Italian):", myInspector.objName_Italian);
		}
		if(language == "Spanish"){
			myInspector.objName_Spanish = EditorGUILayout.TextField("Inventory Object Name (Spanish):", myInspector.objName_Spanish);
		}
		if(language == "German"){
			myInspector.objName_German = EditorGUILayout.TextField("Inventory Object Name (German):", myInspector.objName_German);
		}
		if(language == "French"){
			myInspector.objName_French = EditorGUILayout.TextField("Inventory Object Name (French):", myInspector.objName_French);
		}
		if(language == "Chinese"){
			myInspector.objName_Chinese = EditorGUILayout.TextField("Inventory Object Name (Chinese):", myInspector.objName_Chinese);
		}
		if(language == "Japanese"){
			myInspector.objName_Japanese = EditorGUILayout.TextField("Inventory Object Name (Japanese):", myInspector.objName_Japanese);
		}
		if(language == "Russian"){
			myInspector.objName_Russian = EditorGUILayout.TextField("Inventory Object Name (Russian):", myInspector.objName_Russian);
		}
		
		SerializedObject serTarget = new SerializedObject(target);
		EditorGUILayout.PropertyField(serTarget.FindProperty("obj_Texture"), new GUIContent("Obj to obtain Texture:"), true);
		serTarget.ApplyModifiedProperties();
		//myInspector.obj_Texture = (Texture2D) EditorGUILayout.ObjectField("Obj to obtain Texture: ", myInspector.obj_Texture, typeof(Texture2D), true);

		myInspector.deleteIfKey = EditorGUILayout.Toggle("Delete if key is true:", myInspector.deleteIfKey);
		if(myInspector.deleteIfKey){
			EditorGUI.indentLevel = 1;
			myInspector.neededKey = EditorGUILayout.TextField("NeededKey:", myInspector.neededKey);
			EditorGUI.indentLevel = 0;
		}
		
		EditorGUIUtility.labelWidth = 210.0f;
		myInspector.removeOtherObject = EditorGUILayout.Toggle("Remove Other Object from Inventory: ", myInspector.removeOtherObject);
		if(myInspector.removeOtherObject){
			EditorGUI.indentLevel = 1;
			if(language == "English"){
				myInspector.otherObjName_English = EditorGUILayout.TextField("Other Object Name (English):", myInspector.otherObjName_English);
			}
			if(language == "Italian"){
				myInspector.otherObjName_Italian = EditorGUILayout.TextField("Other Object Name (Italian):", myInspector.otherObjName_Italian);
			}
			if(language == "Spanish"){
				myInspector.otherObjName_Spanish = EditorGUILayout.TextField("Other Object Name (Spanish):", myInspector.otherObjName_Spanish);
			}
			if(language == "German"){
				myInspector.otherObjName_German = EditorGUILayout.TextField("Other Object Name (German):", myInspector.otherObjName_German);
			}
			if(language == "French"){
				myInspector.otherObjName_French = EditorGUILayout.TextField("Other Object Name (French):", myInspector.otherObjName_French);
			}
			if(language == "Chinese"){
				myInspector.otherObjName_Chinese = EditorGUILayout.TextField("Other Object Name (Chinese):", myInspector.otherObjName_Chinese);
			}
			if(language == "Japanese"){
				myInspector.otherObjName_Japanese = EditorGUILayout.TextField("Other Object Name (Japanese):", myInspector.otherObjName_Japanese);
			}
			if(language == "Russian"){
				myInspector.otherObjName_Russian = EditorGUILayout.TextField("Other Object Name (Russian):", myInspector.otherObjName_Russian);
			}
			myInspector.otherObjectHasKey = EditorGUILayout.Toggle("Remove other Object saved Key?", myInspector.otherObjectHasKey);
			if(myInspector.otherObjectHasKey){
				EditorGUI.indentLevel = 2;
				myInspector.otherObjKey = EditorGUILayout.TextField("Other object key:", myInspector.otherObjKey);
				EditorGUI.indentLevel = 1;
			}
			myInspector.restoreOtherObjectToObtain = EditorGUILayout.Toggle("Restore other inGame object?", myInspector.restoreOtherObjectToObtain);
			if(myInspector.restoreOtherObjectToObtain){
				EditorGUI.indentLevel = 2;
				myInspector.otherObject = (GameObject) EditorGUILayout.ObjectField("Other Object: ", myInspector.otherObject, typeof(GameObject), true);
				EditorGUI.indentLevel = 1;
			}
			EditorGUI.indentLevel = 0;
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elementsGUILayout.Space(10.0f); //Put some spece between different elements
		
		EditorGUIUtility.labelWidth = 70.0f;

		if(language == "English"){
			EditorGUILayout.LabelField("Obtain Text (English):");
			EditorGUI.indentLevel = 5;
			myInspector.obtainMessage_English = EditorGUILayout.TextArea(myInspector.obtainMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
			
			EditorGUILayout.LabelField("Description Text (English):");
			EditorGUI.indentLevel = 5;
			myInspector.description_English = EditorGUILayout.TextArea(myInspector.description_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Italian"){
			EditorGUILayout.LabelField("Obtain Text (Italian):");
			EditorGUI.indentLevel = 5;
			myInspector.obtainMessage_Italian = EditorGUILayout.TextArea(myInspector.obtainMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
			
			EditorGUILayout.LabelField("Description Text (Italian):");
			EditorGUI.indentLevel = 5;
			myInspector.description_Italian = EditorGUILayout.TextArea(myInspector.description_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Spanish"){
			EditorGUILayout.LabelField("Obtain Text (Spanish):");
			EditorGUI.indentLevel = 5;
			myInspector.obtainMessage_Spanish = EditorGUILayout.TextArea(myInspector.obtainMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
			
			EditorGUILayout.LabelField("Description Text (Spanish):");
			EditorGUI.indentLevel = 5;
			myInspector.description_Spanish = EditorGUILayout.TextArea(myInspector.description_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "German"){
			EditorGUILayout.LabelField("Obtain Text (German):");
			EditorGUI.indentLevel = 5;
			myInspector.obtainMessage_German = EditorGUILayout.TextArea(myInspector.obtainMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
			
			EditorGUILayout.LabelField("Description Text (German):");
			EditorGUI.indentLevel = 5;
			myInspector.description_German = EditorGUILayout.TextArea(myInspector.description_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "French"){
			EditorGUILayout.LabelField("Obtain Text (French):");
			EditorGUI.indentLevel = 5;
			myInspector.obtainMessage_French = EditorGUILayout.TextArea(myInspector.obtainMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
			
			EditorGUILayout.LabelField("Description Text (French):");
			EditorGUI.indentLevel = 5;
			myInspector.description_French = EditorGUILayout.TextArea(myInspector.description_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Chinese"){
			EditorGUILayout.LabelField("Obtain Text (Chinese):");
			EditorGUI.indentLevel = 5;
			myInspector.obtainMessage_Chinese = EditorGUILayout.TextArea(myInspector.obtainMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
			
			EditorGUILayout.LabelField("Description Text (Chinese):");
			EditorGUI.indentLevel = 5;
			myInspector.description_Chinese = EditorGUILayout.TextArea(myInspector.description_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Japanese"){
			EditorGUILayout.LabelField("Obtain Text (Japanese):");
			EditorGUI.indentLevel = 5;
			myInspector.obtainMessage_Japanese = EditorGUILayout.TextArea(myInspector.obtainMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
			
			EditorGUILayout.LabelField("Description Text (Japanese):");
			EditorGUI.indentLevel = 5;
			myInspector.description_Japanese = EditorGUILayout.TextArea(myInspector.description_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		if(language == "Russian"){
			EditorGUILayout.LabelField("Obtain Text (Russian):");
			EditorGUI.indentLevel = 5;
			myInspector.obtainMessage_Russian = EditorGUILayout.TextArea(myInspector.obtainMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
			
			EditorGUILayout.LabelField("Description Text (Russian):");
			EditorGUI.indentLevel = 5;
			myInspector.description_Russian = EditorGUILayout.TextArea(myInspector.description_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
			EditorGUI.indentLevel = 0;
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 167.0f;
		myInspector.canBeObserved = EditorGUILayout.Toggle("Can be Observed:", myInspector.canBeObserved);
		
		EditorGUIUtility.labelWidth = 70.0f;

		if(myInspector.canBeObserved){
			EditorGUIUtility.labelWidth = 85.0f;
			myInspector.observeInt = EditorGUILayout.Popup("Observe Type:", myInspector.observeInt, myInspector.observeMode);

			if(myInspector.observeInt == 1){
				EditorGUIUtility.labelWidth = 92.0f;
				
				myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("Ingame Camera: ", myInspector.inGameCamera, typeof(GameObject), true);
				myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Closeup: ", myInspector.closeupCamera, typeof(GameObject), true);
				myInspector.interactingCollider = (GameObject) EditorGUILayout.ObjectField("Interact. Coll: ", myInspector.interactingCollider, typeof(GameObject), true);

				GUILayout.Space(10.0f); //Put some spece between different elements
			}
			
			EditorGUIUtility.labelWidth = 75.0f;

			if(language == "English"){
				EditorGUILayout.LabelField("Observe Text (English):");
				EditorGUI.indentLevel = 5;
				myInspector.observMessage_English = EditorGUILayout.TextArea(myInspector.observMessage_English, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Italian"){
				EditorGUILayout.LabelField("Observe Text (Italian):");
				EditorGUI.indentLevel = 5;
				myInspector.observMessage_Italian = EditorGUILayout.TextArea(myInspector.observMessage_Italian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Spanish"){
				EditorGUILayout.LabelField("Observe Text (Spanish):");
				EditorGUI.indentLevel = 5;
				myInspector.observMessage_Spanish = EditorGUILayout.TextArea(myInspector.observMessage_Spanish, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "German"){
				EditorGUILayout.LabelField("Observe Text (German):");
				EditorGUI.indentLevel = 5;
				myInspector.observMessage_German = EditorGUILayout.TextArea(myInspector.observMessage_German, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "French"){
				EditorGUILayout.LabelField("Observe Text (French):");
				EditorGUI.indentLevel = 5;
				myInspector.observMessage_French = EditorGUILayout.TextArea(myInspector.observMessage_French, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Chinese"){
				EditorGUILayout.LabelField("Observe Text (Chinese):");
				EditorGUI.indentLevel = 5;
				myInspector.observMessage_Chinese = EditorGUILayout.TextArea(myInspector.observMessage_Chinese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Japanese"){
				EditorGUILayout.LabelField("Observe Text (Japanese):");
				EditorGUI.indentLevel = 5;
				myInspector.observMessage_Japanese = EditorGUILayout.TextArea(myInspector.observMessage_Japanese, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			if(language == "Russian"){
				EditorGUILayout.LabelField("Observe Text (Russian):");
				EditorGUI.indentLevel = 5;
				myInspector.observMessage_Russian = EditorGUILayout.TextArea(myInspector.observMessage_Russian, GUILayout.Height(50.0f), GUILayout.MinWidth(60.0f));
				EditorGUI.indentLevel = 0;
			}
			
			EditorGUIUtility.labelWidth = 75.0f;
			myInspector.secToOserve = EditorGUILayout.FloatField("Observe for: ", myInspector.secToOserve);
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements
	}
}
