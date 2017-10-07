using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_PlayerRay))] 
public class Editor_FPH_PlayerRay : Editor {

	private bool showMousePointer;
	private string language = "English";


	public override void OnInspectorGUI() {
		FPH_PlayerRay myInspector = (FPH_PlayerRay) target;
		SerializedObject serTarget = new SerializedObject(target);

		GUILayout.Space(10.0f); //Put some spece between different elements
		
		myInspector.playerType = EditorGUILayout.Popup("Player Type:", myInspector.playerType, myInspector.playerTypeArray);
		myInspector.rayDistance = EditorGUILayout.Slider("Ray Distance:", myInspector.rayDistance, 0.0f, 20.0f);
		EditorGUILayout.PropertyField(serTarget.FindProperty("pointerText"), new GUIContent("Base Pointer:"), true);

		if(myInspector.isOnMobile){
			GUILayout.Space(10.0f); //Put some spece between different elements
		}

		myInspector.isOnMobile = EditorGUILayout.Toggle("Is on Mobile?", myInspector.isOnMobile);
		if(myInspector.isOnMobile){
			EditorGUI.indentLevel = 1;

			myInspector.mobileSkin = (GUISkin) EditorGUILayout.ObjectField("Buttons GUISkyn:", myInspector.mobileSkin, typeof(GUISkin), true);
			myInspector.showOnlyStandardPointer = EditorGUILayout.Toggle("Show only BasePointer?", myInspector.showOnlyStandardPointer);

			EditorGUILayout.PropertyField(serTarget.FindProperty("mobileButton_Observe"), new GUIContent("MobileButton Observe:"), true);
			EditorGUILayout.PropertyField(serTarget.FindProperty("mobileButton_Dialog"), new GUIContent("MobileButton Inventory:"), true);
			EditorGUILayout.PropertyField(serTarget.FindProperty("mobileButton_Door"), new GUIContent("MobileButton Door:"), true);
			EditorGUILayout.PropertyField(serTarget.FindProperty("mobileButton_Interact"), new GUIContent("MobileButton Interact:"), true);
			EditorGUILayout.PropertyField(serTarget.FindProperty("mobileButton_Inventory"), new GUIContent("MobileButton Inventory:"), true);
			EditorGUILayout.PropertyField(serTarget.FindProperty("mobileButton_ChangeLevel"), new GUIContent("MobileButton ChangeLevel:"), true);

			EditorGUI.indentLevel = 0;

			GUILayout.Space(10.0f); //Put some spece between different elements
		}

		if(!myInspector.isOnMobile){
			myInspector.showInteractionIcon = EditorGUILayout.Toggle("Show Interaction Icons?", myInspector.showInteractionIcon);
			
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			if(myInspector.showInteractionIcon){
				EditorGUILayout.LabelField("Mouse Pointers");
				EditorGUI.indentLevel = 1;
				
				EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_Inventory"), new GUIContent("Inventory:"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_Inventory_Observe"), new GUIContent("Inventory (Observe):"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_Observe"), new GUIContent("Observe:"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_Interact"), new GUIContent("Interact:"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_Interact_Observe"), new GUIContent("Interact (Observe):"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_ChangeLevel"), new GUIContent("Change Level:"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_ChangeLevel_Observe"), new GUIContent("Change Level (Observe):"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_Dialog"), new GUIContent("Dialog:"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_ShowText"), new GUIContent("Show Text:"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_Door"), new GUIContent("Door:"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_Door_Observe"), new GUIContent("Door (Observe):"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
				EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag_Observe"), new GUIContent("Drag Door (Observe):"), true);
				
				EditorGUI.indentLevel = 0;
			}
			if(!myInspector.showInteractionIcon){
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
				
				EditorGUILayout.LabelField("Language: " + language);
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				EditorGUIUtility.labelWidth = 205.0f;
				if(language == "English"){
					myInspector.english_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.english_inventoryObjMessage);
					myInspector.english_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.english_inventoryObjMessage_Observe);
					
					myInspector.english_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.english_observeObjMessage);
					
					myInspector.english_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.english_interactObjMessage);
					myInspector.english_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.english_interactObjMessage_Observe);
					
					myInspector.english_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.english_changeLvlObjMessage);
					myInspector.english_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.english_changeLvlObjMessage_Observe);
					
					myInspector.english_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.english_dialogObjMessage);
					
					myInspector.english_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.english_showTextMessage);
					
					myInspector.english_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.english_batteryObjMessage);
					myInspector.english_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.english_batteryObjMessage_Observe);
					
					myInspector.english_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.english_doorObjMessage);
					myInspector.english_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.english_doorObjMessage_Observe);
					
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
					myInspector.english_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.english_dragDoorObjMessage_Observe);
				}
				if(language == "Italian"){
					myInspector.italian_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.italian_inventoryObjMessage);
					myInspector.italian_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.italian_inventoryObjMessage_Observe);
					
					myInspector.italian_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.italian_observeObjMessage);
					
					myInspector.italian_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.italian_interactObjMessage);
					myInspector.italian_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.italian_interactObjMessage_Observe);
					
					myInspector.italian_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.italian_changeLvlObjMessage);
					myInspector.italian_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.italian_changeLvlObjMessage_Observe);
					
					myInspector.italian_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.italian_dialogObjMessage);
					
					myInspector.italian_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.italian_showTextMessage);
					
					myInspector.italian_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.italian_batteryObjMessage);
					myInspector.italian_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.italian_batteryObjMessage_Observe);
					
					myInspector.italian_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.italian_doorObjMessage);
					myInspector.italian_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.italian_doorObjMessage_Observe);
					
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
					myInspector.italian_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.italian_dragDoorObjMessage_Observe);
				}
				if(language == "Spanish"){
					myInspector.spanish_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.spanish_inventoryObjMessage);
					myInspector.spanish_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.spanish_inventoryObjMessage_Observe);
					
					myInspector.spanish_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.spanish_observeObjMessage);
					
					myInspector.spanish_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.spanish_interactObjMessage);
					myInspector.spanish_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.spanish_interactObjMessage_Observe);
					
					myInspector.spanish_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.spanish_changeLvlObjMessage);
					myInspector.spanish_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.spanish_changeLvlObjMessage_Observe);
					
					myInspector.spanish_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.spanish_dialogObjMessage);
					
					myInspector.spanish_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.spanish_showTextMessage);
					
					myInspector.spanish_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.spanish_batteryObjMessage);
					myInspector.spanish_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.spanish_batteryObjMessage_Observe);
					
					myInspector.spanish_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.spanish_doorObjMessage);
					myInspector.spanish_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.spanish_doorObjMessage_Observe);
					
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
					myInspector.spanish_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.spanish_dragDoorObjMessage_Observe);
				}
				if(language == "German"){
					myInspector.german_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.german_inventoryObjMessage);
					myInspector.german_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.german_inventoryObjMessage_Observe);
					
					myInspector.german_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.german_observeObjMessage);
					
					myInspector.german_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.german_interactObjMessage);
					myInspector.german_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.german_interactObjMessage_Observe);
					
					myInspector.german_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.german_changeLvlObjMessage);
					myInspector.german_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.german_changeLvlObjMessage_Observe);
					
					myInspector.german_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.german_dialogObjMessage);
					
					myInspector.german_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.german_showTextMessage);
					
					myInspector.german_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.german_batteryObjMessage);
					myInspector.german_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.german_batteryObjMessage_Observe);
					
					myInspector.german_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.german_doorObjMessage);
					myInspector.german_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.german_doorObjMessage_Observe);
					
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
					myInspector.german_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.german_dragDoorObjMessage_Observe);
				}
				if(language == "French"){
					myInspector.french_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.french_inventoryObjMessage);
					myInspector.french_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.french_inventoryObjMessage_Observe);
					
					myInspector.french_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.french_observeObjMessage);
					
					myInspector.french_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.french_interactObjMessage);
					myInspector.french_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.french_interactObjMessage_Observe);
					
					myInspector.french_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.french_changeLvlObjMessage);
					myInspector.french_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.french_changeLvlObjMessage_Observe);
					
					myInspector.french_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.french_dialogObjMessage);
					
					myInspector.french_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.french_showTextMessage);
					
					myInspector.french_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.french_batteryObjMessage);
					myInspector.french_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.french_batteryObjMessage_Observe);
					
					myInspector.french_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.french_doorObjMessage);
					myInspector.french_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.french_doorObjMessage_Observe);
					
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
					myInspector.french_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.french_dragDoorObjMessage_Observe);
				}
				if(language == "Japanese"){
					myInspector.japanese_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.japanese_inventoryObjMessage);
					myInspector.japanese_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.japanese_inventoryObjMessage_Observe);
					
					myInspector.japanese_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.japanese_observeObjMessage);
					
					myInspector.japanese_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.japanese_interactObjMessage);
					myInspector.japanese_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.japanese_interactObjMessage_Observe);
					
					myInspector.japanese_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.japanese_changeLvlObjMessage);
					myInspector.japanese_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.japanese_changeLvlObjMessage_Observe);
					
					myInspector.japanese_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.japanese_dialogObjMessage);
					
					myInspector.japanese_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.japanese_showTextMessage);
					
					myInspector.japanese_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.japanese_batteryObjMessage);
					myInspector.japanese_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.japanese_batteryObjMessage_Observe);
					
					myInspector.japanese_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.japanese_doorObjMessage);
					myInspector.japanese_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.japanese_doorObjMessage_Observe);
					
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
					myInspector.japanese_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.french_dragDoorObjMessage_Observe);
				}
				if(language == "Chinese"){
					myInspector.chinese_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.chinese_inventoryObjMessage);
					myInspector.chinese_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.chinese_inventoryObjMessage_Observe);
					
					myInspector.chinese_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.chinese_observeObjMessage);
					
					myInspector.chinese_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.chinese_interactObjMessage);
					myInspector.chinese_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.chinese_interactObjMessage_Observe);
					
					myInspector.chinese_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.chinese_changeLvlObjMessage);
					myInspector.chinese_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.chinese_changeLvlObjMessage_Observe);
					
					myInspector.chinese_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.chinese_dialogObjMessage);
					
					myInspector.chinese_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.chinese_showTextMessage);
					
					myInspector.chinese_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.chinese_batteryObjMessage);
					myInspector.chinese_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.chinese_batteryObjMessage_Observe);
					
					myInspector.chinese_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.chinese_doorObjMessage);
					myInspector.chinese_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.chinese_doorObjMessage_Observe);
					
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
					myInspector.chinese_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.french_dragDoorObjMessage_Observe);
				}
				if(language == "Russian"){
					myInspector.russian_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.russian_inventoryObjMessage);
					myInspector.russian_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.russian_inventoryObjMessage_Observe);
					
					myInspector.russian_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.russian_observeObjMessage);
					
					myInspector.russian_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.russian_interactObjMessage);
					myInspector.russian_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.russian_interactObjMessage_Observe);
					
					myInspector.russian_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.russian_changeLvlObjMessage);
					myInspector.russian_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.russian_changeLvlObjMessage_Observe);
					
					myInspector.russian_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.russian_dialogObjMessage);
					
					myInspector.russian_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.russian_showTextMessage);
					
					myInspector.russian_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.russian_batteryObjMessage);
					myInspector.russian_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.russian_batteryObjMessage_Observe);
					
					myInspector.russian_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.russian_doorObjMessage);
					myInspector.russian_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.russian_doorObjMessage_Observe);
					
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
					myInspector.russian_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.french_dragDoorObjMessage_Observe);
				}
			}
			
			serTarget.ApplyModifiedProperties();
			
			GUILayout.Space(10.0f); //Put some spece between different elements
		}

		if(myInspector.isOnMobile){
			if(!myInspector.showOnlyStandardPointer){myInspector.showInteractionIcon = EditorGUILayout.Toggle("Show Interaction Icons?", myInspector.showInteractionIcon);
				
				GUILayout.Space(10.0f); //Put some spece between different elements
				
				if(myInspector.showInteractionIcon){
					EditorGUILayout.LabelField("Mouse Pointers");
					EditorGUI.indentLevel = 1;
					
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_Inventory"), new GUIContent("Inventory:"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_Inventory_Observe"), new GUIContent("Inventory (Observe):"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_Observe"), new GUIContent("Observe:"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_Interact"), new GUIContent("Interact:"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_Interact_Observe"), new GUIContent("Interact (Observe):"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_ChangeLevel"), new GUIContent("Change Level:"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_ChangeLevel_Observe"), new GUIContent("Change Level (Observe):"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_Dialog"), new GUIContent("Dialog:"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("pointer_ShowText"), new GUIContent("Show Text:"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_Door"), new GUIContent("Door:"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_Door_Observe"), new GUIContent("Door (Observe):"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
					EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag_Observe"), new GUIContent("Drag Door (Observe):"), true);
					
					EditorGUI.indentLevel = 0;
				}
				if(!myInspector.showInteractionIcon){
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
					
					EditorGUILayout.LabelField("Language: " + language);
					GUILayout.Space(10.0f); //Put some spece between different elements
					
					EditorGUIUtility.labelWidth = 205.0f;
					if(language == "English"){
						myInspector.english_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.english_inventoryObjMessage);
						myInspector.english_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.english_inventoryObjMessage_Observe);
						
						myInspector.english_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.english_observeObjMessage);
						
						myInspector.english_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.english_interactObjMessage);
						myInspector.english_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.english_interactObjMessage_Observe);
						
						myInspector.english_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.english_changeLvlObjMessage);
						myInspector.english_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.english_changeLvlObjMessage_Observe);
						
						myInspector.english_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.english_dialogObjMessage);
						
						myInspector.english_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.english_showTextMessage);
						
						myInspector.english_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.english_batteryObjMessage);
						myInspector.english_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.english_batteryObjMessage_Observe);
						
						myInspector.english_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.english_doorObjMessage);
						myInspector.english_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.english_doorObjMessage_Observe);
						
						EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
						myInspector.english_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.english_dragDoorObjMessage_Observe);
					}
					if(language == "Italian"){
						myInspector.italian_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.italian_inventoryObjMessage);
						myInspector.italian_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.italian_inventoryObjMessage_Observe);
						
						myInspector.italian_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.italian_observeObjMessage);
						
						myInspector.italian_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.italian_interactObjMessage);
						myInspector.italian_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.italian_interactObjMessage_Observe);
						
						myInspector.italian_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.italian_changeLvlObjMessage);
						myInspector.italian_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.italian_changeLvlObjMessage_Observe);
						
						myInspector.italian_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.italian_dialogObjMessage);
						
						myInspector.italian_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.italian_showTextMessage);
						
						myInspector.italian_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.italian_batteryObjMessage);
						myInspector.italian_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.italian_batteryObjMessage_Observe);
						
						myInspector.italian_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.italian_doorObjMessage);
						myInspector.italian_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.italian_doorObjMessage_Observe);
						
						EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
						myInspector.italian_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.italian_dragDoorObjMessage_Observe);
					}
					if(language == "Spanish"){
						myInspector.spanish_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.spanish_inventoryObjMessage);
						myInspector.spanish_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.spanish_inventoryObjMessage_Observe);
						
						myInspector.spanish_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.spanish_observeObjMessage);
						
						myInspector.spanish_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.spanish_interactObjMessage);
						myInspector.spanish_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.spanish_interactObjMessage_Observe);
						
						myInspector.spanish_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.spanish_changeLvlObjMessage);
						myInspector.spanish_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.spanish_changeLvlObjMessage_Observe);
						
						myInspector.spanish_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.spanish_dialogObjMessage);
						
						myInspector.spanish_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.spanish_showTextMessage);
						
						myInspector.spanish_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.spanish_batteryObjMessage);
						myInspector.spanish_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.spanish_batteryObjMessage_Observe);
						
						myInspector.spanish_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.spanish_doorObjMessage);
						myInspector.spanish_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.spanish_doorObjMessage_Observe);
						
						EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
						myInspector.spanish_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.spanish_dragDoorObjMessage_Observe);
					}
					if(language == "German"){
						myInspector.german_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.german_inventoryObjMessage);
						myInspector.german_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.german_inventoryObjMessage_Observe);
						
						myInspector.german_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.german_observeObjMessage);
						
						myInspector.german_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.german_interactObjMessage);
						myInspector.german_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.german_interactObjMessage_Observe);
						
						myInspector.german_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.german_changeLvlObjMessage);
						myInspector.german_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.german_changeLvlObjMessage_Observe);
						
						myInspector.german_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.german_dialogObjMessage);
						
						myInspector.german_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.german_showTextMessage);
						
						myInspector.german_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.german_batteryObjMessage);
						myInspector.german_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.german_batteryObjMessage_Observe);
						
						myInspector.german_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.german_doorObjMessage);
						myInspector.german_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.german_doorObjMessage_Observe);
						
						EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
						myInspector.german_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.german_dragDoorObjMessage_Observe);
					}
					if(language == "French"){
						myInspector.french_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.french_inventoryObjMessage);
						myInspector.french_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.french_inventoryObjMessage_Observe);
						
						myInspector.french_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.french_observeObjMessage);
						
						myInspector.french_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.french_interactObjMessage);
						myInspector.french_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.french_interactObjMessage_Observe);
						
						myInspector.french_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.french_changeLvlObjMessage);
						myInspector.french_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.french_changeLvlObjMessage_Observe);
						
						myInspector.french_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.french_dialogObjMessage);
						
						myInspector.french_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.french_showTextMessage);
						
						myInspector.french_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.french_batteryObjMessage);
						myInspector.french_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.french_batteryObjMessage_Observe);
						
						myInspector.french_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.french_doorObjMessage);
						myInspector.french_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.french_doorObjMessage_Observe);
						
						EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
						myInspector.french_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.french_dragDoorObjMessage_Observe);
					}
					if(language == "Japanese"){
						myInspector.japanese_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.japanese_inventoryObjMessage);
						myInspector.japanese_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.japanese_inventoryObjMessage_Observe);
						
						myInspector.japanese_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.japanese_observeObjMessage);
						
						myInspector.japanese_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.japanese_interactObjMessage);
						myInspector.japanese_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.japanese_interactObjMessage_Observe);
						
						myInspector.japanese_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.japanese_changeLvlObjMessage);
						myInspector.japanese_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.japanese_changeLvlObjMessage_Observe);
						
						myInspector.japanese_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.japanese_dialogObjMessage);
						
						myInspector.japanese_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.japanese_showTextMessage);
						
						myInspector.japanese_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.japanese_batteryObjMessage);
						myInspector.japanese_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.japanese_batteryObjMessage_Observe);
						
						myInspector.japanese_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.japanese_doorObjMessage);
						myInspector.japanese_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.japanese_doorObjMessage_Observe);
						
						EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
						myInspector.japanese_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.french_dragDoorObjMessage_Observe);
					}
					if(language == "Chinese"){
						myInspector.chinese_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.chinese_inventoryObjMessage);
						myInspector.chinese_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.chinese_inventoryObjMessage_Observe);
						
						myInspector.chinese_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.chinese_observeObjMessage);
						
						myInspector.chinese_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.chinese_interactObjMessage);
						myInspector.chinese_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.chinese_interactObjMessage_Observe);
						
						myInspector.chinese_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.chinese_changeLvlObjMessage);
						myInspector.chinese_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.chinese_changeLvlObjMessage_Observe);
						
						myInspector.chinese_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.chinese_dialogObjMessage);
						
						myInspector.chinese_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.chinese_showTextMessage);
						
						myInspector.chinese_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.chinese_batteryObjMessage);
						myInspector.chinese_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.chinese_batteryObjMessage_Observe);
						
						myInspector.chinese_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.chinese_doorObjMessage);
						myInspector.chinese_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.chinese_doorObjMessage_Observe);
						
						EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
						myInspector.chinese_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.french_dragDoorObjMessage_Observe);
					}
					if(language == "Russian"){
						myInspector.russian_inventoryObjMessage = EditorGUILayout.TextField("Inventory Obj Message", myInspector.russian_inventoryObjMessage);
						myInspector.russian_inventoryObjMessage_Observe = EditorGUILayout.TextField("Inventory Obj Message (Observe)", myInspector.russian_inventoryObjMessage_Observe);
						
						myInspector.russian_observeObjMessage = EditorGUILayout.TextField("Observe Obj Message", myInspector.russian_observeObjMessage);
						
						myInspector.russian_interactObjMessage= EditorGUILayout.TextField("Interact Obj Message", myInspector.russian_interactObjMessage);
						myInspector.russian_interactObjMessage_Observe = EditorGUILayout.TextField("Interact Obj Message (Observe)", myInspector.russian_interactObjMessage_Observe);
						
						myInspector.russian_changeLvlObjMessage = EditorGUILayout.TextField("Change Level Obj Message", myInspector.russian_changeLvlObjMessage);
						myInspector.russian_changeLvlObjMessage_Observe = EditorGUILayout.TextField("Change Level Obj Message (Observe)", myInspector.russian_changeLvlObjMessage_Observe);
						
						myInspector.russian_dialogObjMessage = EditorGUILayout.TextField("Dialog Obj Message", myInspector.russian_dialogObjMessage);
						
						myInspector.russian_showTextMessage = EditorGUILayout.TextField("Show Text Obj Message", myInspector.russian_showTextMessage);
						
						myInspector.russian_batteryObjMessage = EditorGUILayout.TextField("Battery Obj Message", myInspector.russian_batteryObjMessage);
						myInspector.russian_batteryObjMessage_Observe = EditorGUILayout.TextField("Battery Obj Message (Observe)", myInspector.russian_batteryObjMessage_Observe);
						
						myInspector.russian_doorObjMessage = EditorGUILayout.TextField("Door Obj Message", myInspector.russian_doorObjMessage);
						myInspector.russian_doorObjMessage_Observe = EditorGUILayout.TextField("Door Obj Message (Observe)", myInspector.russian_doorObjMessage_Observe);
						
						EditorGUILayout.PropertyField(serTarget.FindProperty("ponter_DoorDrag"), new GUIContent("Drag Door:"), true);
						myInspector.russian_dragDoorObjMessage_Observe = EditorGUILayout.TextField("Drag Door Obj Message (Observe)", myInspector.french_dragDoorObjMessage_Observe);
					}
				}
				
				serTarget.ApplyModifiedProperties();
				
				GUILayout.Space(10.0f); //Put some spece between different elements
			}
		}
	}
}