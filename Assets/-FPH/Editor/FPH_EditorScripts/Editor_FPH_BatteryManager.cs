using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(FPH_BatteryManager))] 
public class Editor_FPH_BatteryManager : Editor {
	
	private bool showAni;
	private bool showBatterySprite;
	
	public override void OnInspectorGUI() {
		FPH_BatteryManager myInspector = (FPH_BatteryManager) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		EditorGUIUtility.labelWidth = 140.0f;

		myInspector.batteryUI = (GameObject) EditorGUILayout.ObjectField("BatteryUI:", myInspector.batteryUI, typeof(GameObject), true);
		myInspector.flashlight_LightObj = (GameObject) EditorGUILayout.ObjectField("Flashlight Light:", myInspector.flashlight_LightObj, typeof(GameObject), true);
		myInspector.drainLifeEvery = EditorGUILayout.FloatField("Drain Battery Life Every:", myInspector.drainLifeEvery);
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		myInspector.batteryLifeTextMesh = (Text) EditorGUILayout.ObjectField("BatteryLife (TextMesh):", myInspector.batteryLifeTextMesh, typeof(Text), true);
		myInspector.batterySprite = (Image) EditorGUILayout.ObjectField("Battery % Sprite:", myInspector.batterySprite, typeof(Image), true);
		if(myInspector.batterySprite != null){
			showBatterySprite = EditorGUILayout.Foldout(showBatterySprite, "Battery Sprites:");
			if(showBatterySprite){
				EditorGUI.indentLevel = 1;
				myInspector.sprite_Empty = (Sprite) EditorGUILayout.ObjectField("Battery Empty:", myInspector.sprite_Empty, typeof(Sprite), true);
				myInspector.sprite_One = (Sprite) EditorGUILayout.ObjectField("Battery One:", myInspector.sprite_One, typeof(Sprite), true);
				myInspector.sprite_Two = (Sprite) EditorGUILayout.ObjectField("Battery Two:", myInspector.sprite_Two, typeof(Sprite), true);
				myInspector.sprite_Three = (Sprite) EditorGUILayout.ObjectField("Battery Three:", myInspector.sprite_Three, typeof(Sprite), true);
				myInspector.sprite_Four = (Sprite) EditorGUILayout.ObjectField("Battery Four:", myInspector.sprite_Four, typeof(Sprite), true);
				EditorGUI.indentLevel = 0;
			}
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements
		
		// EditorGUIUtility.labelWidth = 85.0f;
		myInspector.animateHand = EditorGUILayout.Toggle("Animate Hand?", myInspector.animateHand);
		if(myInspector.animateHand){
			myInspector.handObj = (Animation) EditorGUILayout.ObjectField("Hand Object:", myInspector.handObj, typeof(Animation), true);
			showAni = EditorGUILayout.Foldout(showAni, "Hand Animations:");
			if(showAni){
				EditorGUI.indentLevel = 1;
				myInspector.showHand_Ani = EditorGUILayout.TextField("Show Hand", myInspector.showHand_Ani);
				myInspector.hideHand_Ani = EditorGUILayout.TextField("Hide Hand", myInspector.hideHand_Ani);
				myInspector.idleHand_Ani = EditorGUILayout.TextField("Idle Hand", myInspector.idleHand_Ani);
				myInspector.switchLight_Ani = EditorGUILayout.TextField("Switch Liht", myInspector.switchLight_Ani);
				EditorGUI.indentLevel = 0;
			}
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		myInspector.storeBatteries = EditorGUILayout.Toggle("Store Batteries?", myInspector.storeBatteries);
		if(myInspector.storeBatteries){
			myInspector.batteriesInventoryIcon = (GameObject) EditorGUILayout.ObjectField("Battery Inventory Icon:", myInspector.batteriesInventoryIcon, typeof(GameObject), true);
			myInspector.batteriesInventoryIcon_Lablel = (Text) EditorGUILayout.ObjectField("Battery Num (UI Text):", myInspector.batteriesInventoryIcon_Lablel, typeof(Text), true);
		}
		
		GUILayout.Space(10.0f); //Put some spece between different elements
	}
}