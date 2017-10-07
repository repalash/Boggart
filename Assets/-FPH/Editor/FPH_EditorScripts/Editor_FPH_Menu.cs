using UnityEngine;
using UnityEditor;

public static class Editor_FPH_Menu {
	[MenuItem("Tools/FPH Menu/Setup Inventory Object")]
	static void SetupInventoryObj(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_InventoryInteractObject>();
			Selection.activeTransform.gameObject.tag = "InventoryObject";
		}
		else{
			GameObject inventoryObj = new GameObject();
			inventoryObj.AddComponent<BoxCollider>();
			inventoryObj.AddComponent<FPH_InventoryInteractObject>();
			inventoryObj.gameObject.tag = "InventoryObject";
			inventoryObj.gameObject.name = "_NewEmpyInventoryObject";
		}
	}
	
	[MenuItem("Tools/FPH Menu/Setup Observable Object")]
	static void SetupObservLevelObj(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_ObserveObject>();
			Selection.activeTransform.gameObject.tag = "ObserveObject";
			FPH_ObserveObject obsObj = Selection.activeTransform.gameObject.GetComponent<FPH_ObserveObject>();
			obsObj.interactingCollider = Selection.activeTransform.gameObject;
		}
		else{
			GameObject observObj = new GameObject();
			observObj.AddComponent<BoxCollider>();
			observObj.AddComponent<FPH_ObserveObject>();
			observObj.gameObject.tag = "ObserveObject";
			observObj.gameObject.name = "_NewObserveObject";
			FPH_ObserveObject obsObj = observObj.GetComponent<FPH_ObserveObject>();
			obsObj.interactingCollider = observObj;
		}
	}
	
	[MenuItem("Tools/FPH Menu/Setup CatchEvent Object/Setup CatchEvent Object (VarChange)")]
	static void ToggleObjectOnEvent_VarChange(){
		GameObject toogleObj = new GameObject();
		toogleObj.name = "_NewCatchEventObject (VarChange)";
		toogleObj.AddComponent<FPH_CatchEventScript>();
		
		FPH_CatchEventScript toogleObjComp = toogleObj.GetComponent<FPH_CatchEventScript>();
		toogleObjComp.eventType = 0;
	}
	
	[MenuItem("Tools/FPH Menu/Setup CatchEvent Object/Setup CatchEvent Object (OnTrigger)")]
	static void ToggleObjectOnEvent_Trigger(){
		GameObject toogleObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		toogleObj.name = "_NewCatchEventObject (OnTrigger)";
		toogleObj.AddComponent<FPH_CatchEventScript>();
		toogleObj.GetComponent<MeshRenderer>().enabled = false;
		toogleObj.GetComponent<BoxCollider>().isTrigger = true;
		
		FPH_CatchEventScript toogleObjComp = toogleObj.GetComponent<FPH_CatchEventScript>();
		toogleObjComp.eventType = 1;
	}
	
	[MenuItem("Tools/FPH Menu/Setup CatchEvent Object/Setup CatchEvent Object (OnCollision)")]
	static void ToggleObjectOnEvent_Collision(){
		GameObject toogleObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		toogleObj.name = "_NewCatchEventObject (OnCollision)";
		toogleObj.AddComponent<FPH_CatchEventScript>();
		toogleObj.GetComponent<MeshRenderer>().enabled = false;
		toogleObj.GetComponent<BoxCollider>().isTrigger = false;
		
		FPH_CatchEventScript toogleObjComp = toogleObj.GetComponent<FPH_CatchEventScript>();
		toogleObjComp.eventType = 2;
	}
	
	[MenuItem("Tools/FPH Menu/Setup Change Level/Chanage Level On Interaction")]
	static void SetupChangeLevelObj_Interaction(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_ChangeLevelOrPos>();
			FPH_ChangeLevelOrPos changeLevelComp = Selection.activeTransform.gameObject.GetComponent<FPH_ChangeLevelOrPos>();
			Selection.activeTransform.gameObject.tag = "ChangeLevelObject";
			changeLevelComp.changeLevelUI = GameObject.Find("ChangeLevelUI");
		}
		else{
			GameObject inventoryObj = new GameObject();
			inventoryObj.AddComponent<BoxCollider>();
			inventoryObj.AddComponent<FPH_ChangeLevelOrPos>();
			inventoryObj.gameObject.tag = "ChangeLevelObject";
			inventoryObj.gameObject.name = "_NewChangeLevelObject";
			inventoryObj.GetComponent<FPH_ChangeLevelOrPos>().changeLevelUI = GameObject.Find("ChangeLevelUI");
			inventoryObj.GetComponent<FPH_ChangeLevelOrPos>().interactionTypeInt = 0;
		}
	}
	
	[MenuItem("Tools/FPH Menu/Setup Change Level/Chanage Level On Trigger")]
	static void SetupChangeLevelObj_Trigger(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.GetComponent<Collider>().isTrigger = true;
			Selection.activeTransform.gameObject.AddComponent<FPH_ChangeLevelOrPos>();
			FPH_ChangeLevelOrPos changeLevelComp = Selection.activeTransform.gameObject.GetComponent<FPH_ChangeLevelOrPos>();
			changeLevelComp.interactionTypeInt = 1;
			changeLevelComp.changeLevelUI = GameObject.Find("ChangeLevelUI");
		}
		else{
			GameObject inventoryObj = new GameObject();
			inventoryObj.AddComponent<BoxCollider>();
			inventoryObj.AddComponent<FPH_ChangeLevelOrPos>();
			inventoryObj.gameObject.name = "_NewChangeLevelObject";
			inventoryObj.GetComponent<FPH_ChangeLevelOrPos>().interactionTypeInt = 1;
			inventoryObj.GetComponent<FPH_ChangeLevelOrPos>().changeLevelUI = GameObject.Find("ChangeLevelUI");
			inventoryObj.GetComponent<BoxCollider>().isTrigger = true;
		}
	}
	
	[MenuItem("Tools/FPH Menu/Create Dialog/New Empty Dialog")]
	static void CreateEmptyDialog(){
		GameObject dialog = new GameObject();
		dialog.name = "_Dialog Empty";
		dialog.AddComponent<FPH_DialogCreator>();
	}
	
	[MenuItem("Tools/FPH Menu/Create Dialog/New Dialog (Play On Start)")]
	static void CreateStartDialog(){
		GameObject dialog = new GameObject();
		dialog.name = "_Dialog On Start";
		dialog.AddComponent<FPH_PlayDialogOnStart>();
		dialog.AddComponent<FPH_DialogCreator>();
		dialog.GetComponent<FPH_PlayDialogOnStart>().dialog = dialog.GetComponent<FPH_DialogCreator>();
	}
	
	[MenuItem("Tools/FPH Menu/Create Dialog/New Dialog (Play OnTrigger)")]
	static void CreateDialogTrigger(){
		GameObject dialog = new GameObject();
		dialog.name = "_Dialog Trigger";
		dialog.AddComponent<FPH_PlayDialogTrigger>();
		dialog.AddComponent<BoxCollider>();
		dialog.AddComponent<FPH_DialogCreator>();
		dialog.GetComponent<FPH_PlayDialogTrigger>().dialog = dialog.GetComponent<FPH_DialogCreator>();
		BoxCollider boxCollider = dialog.GetComponent<BoxCollider>();
		boxCollider.isTrigger = false;
		boxCollider.center = new Vector3(0.0f, 0.0f, 0.0f);
		boxCollider.size = new Vector3(15.0f, 16.0f, 11.0f);
	}
	
	[MenuItem("Tools/FPH Menu/Create Dialog/New Dialog (Play On Interact)")]
	static void CreateDialogInteract(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_PlayDialogOnInteract>();
			Selection.activeTransform.gameObject.AddComponent<FPH_DialogCreator>();
			Selection.activeTransform.gameObject.tag = "DialogObject";
			Selection.activeTransform.gameObject.GetComponent<FPH_PlayDialogOnInteract>().dialog = Selection.activeTransform.gameObject.GetComponent<FPH_DialogCreator>();
		}
		else{
			GameObject dialog = new GameObject();
			dialog.name = "_Dialog Interact";
			dialog.tag = "DialogObject";
			dialog.AddComponent<FPH_PlayDialogOnInteract>();
			dialog.AddComponent<BoxCollider>();
			dialog.AddComponent<FPH_DialogCreator>();
			dialog.GetComponent<FPH_PlayDialogOnInteract>().dialog = dialog.GetComponent<FPH_DialogCreator>();
			BoxCollider boxCollider = dialog.GetComponent<BoxCollider>();
			boxCollider.isTrigger = false;
			boxCollider.center = new Vector3(0.0f, 0.0f, 0.0f);
			boxCollider.size = new Vector3(15.0f, 16.0f, 11.0f);
		}
	}
	
	[MenuItem("Tools/FPH Menu/Create Show Text/Show Text Object (GUI)")]
	static void CreateShowTextObj_Gui(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_ShowTextFile_GUI>();
			Selection.activeTransform.gameObject.tag = "ShowTextObject";
		}
		else{
			GameObject showTextObj = new GameObject();
			showTextObj.gameObject.tag = "ShowTextObject";
			showTextObj.AddComponent<BoxCollider>();
			showTextObj.name = "_NewShowTextObject (GUI)";
			showTextObj.AddComponent<FPH_ShowTextFile_GUI>();
		}
	}
	
	[MenuItem("Tools/FPH Menu/Create Show Text/Show Text Object (Sprite)")]
	static void CreateShowTextObj_Sprite(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_ShowTextFile_Sprite>();
			Selection.activeTransform.gameObject.tag = "ShowTextObject";
		}
		else{
			GameObject showTextObj = new GameObject();
			showTextObj.gameObject.tag = "ShowTextObject";
			showTextObj.AddComponent<BoxCollider>();
			showTextObj.name = "_NewShowTextObject (Sprite)";
			showTextObj.AddComponent<FPH_ShowTextFile_Sprite>();
		}
	}
	
	[MenuItem("Tools/FPH Menu/Setup Door/Setup Drag Door")]
	static void SetupDoor_Drag(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_DoorObject_Drag>();
			Selection.activeTransform.gameObject.tag = "DoorObject";
		}
		else{
			Debug.LogError("No Object has been selected.");
		}
	}
	[MenuItem("Tools/FPH Menu/Setup Door/Setup Drag Door Trigger")]
	static void SetupDoor_DragTrigger(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			if(Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.GetComponent<Collider>().isTrigger = true;
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_DoorDrag_DirTrigger>();
		}
		else{
			Debug.LogError("No Object has been selected.");
		}
	}
	
	[MenuItem("Tools/FPH Menu/Setup Door/Setup Interaction Door")]
	static void SetupDoor_Interact(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_DoorObject>();
			Selection.activeTransform.gameObject.tag = "DoorObject";
		}
		else{
			Debug.LogError("No Object has been selected.");
		}
	}
	
	[MenuItem("Tools/FPH Menu/Setup Battery/Setup Battery (Trigger)")]
	static void SetupBattery_Trigger(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_BatteryTrigger>();
			Selection.activeTransform.gameObject.GetComponent<BoxCollider>().isTrigger = true;
			Selection.activeTransform.gameObject.tag = "Untagged";
		}
		else{
			Debug.LogError("No Object has been selected.");
		}
	}
	
	[MenuItem("Tools/FPH Menu/Setup Battery/Setup Battery (Interact)")]
	static void SetupBattery_Interact(){
		if(Selection.activeTransform){
			if(!Selection.activeTransform.gameObject.GetComponent<Collider>()){
				Selection.activeTransform.gameObject.AddComponent<BoxCollider>();
			}
			Selection.activeTransform.gameObject.AddComponent<FPH_BatteryInteract>();
			Selection.activeTransform.gameObject.tag = "BatteryObject";
		}
		else{
			Debug.LogError("No Object has been selected.");
		}
	}
	
	[MenuItem("Tools/FPH Menu/Setup Other/Create 2D JumpScare Trigger")]
	static void SetupJumpScare_2D(){
		GameObject jumpScare = GameObject.CreatePrimitive(PrimitiveType.Quad);
		jumpScare.name = "_NewJumpScare";
		jumpScare.AddComponent<FPH_2DJumpsScare>();
		jumpScare.GetComponent<MeshCollider>().convex = true;
		jumpScare.GetComponent<MeshCollider>().isTrigger = true;
		jumpScare.GetComponent<MeshRenderer>().enabled = false;
		jumpScare.GetComponent<Transform>().eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
		jumpScare.GetComponent<Transform>().localScale = new Vector3(3.0f, 3.0f, 3.0f);
	}
	
	[MenuItem("Tools/FPH Menu/Reset PlayerPrefs")]
	static void Menu_ResetPlayerPrefs(){
		PlayerPrefs.DeleteAll();
		Debug.Log("PlayerPrefs Has Been Deleted.");
	}
}