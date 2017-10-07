using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_ComputerButtons))] 
public class Editor_FPH_ComputerButtons : Editor {
	
	public override void OnInspectorGUI() {
		FPH_ComputerButtons myInspector = (FPH_ComputerButtons) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 85.0f;
		myInspector.buttonType = EditorGUILayout.Popup("Button Type:", myInspector.buttonType, myInspector.buttonTypeArray);
		
		if(myInspector.buttonType == 0){ // NextButton
			GUILayout.Space(10.0f); //Put some spece between different elements

			myInspector.planeObj = (GameObject) EditorGUILayout.ObjectField("Screen Object:", myInspector.planeObj, typeof(GameObject), true);

			SerializedObject serTarget = new SerializedObject(target);
			SerializedProperty charaList = serTarget.FindProperty("cameraMat");
			EditorGUILayout.PropertyField(charaList, new GUIContent("Camera Materials:"), true);
			serTarget.ApplyModifiedProperties();
		}
		if(myInspector.buttonType == 1){ // BackButton
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			myInspector.planeObj = (GameObject) EditorGUILayout.ObjectField("Screen Object:", myInspector.planeObj, typeof(GameObject), true);
			myInspector.nextButtonComp = (FPH_ComputerButtons) EditorGUILayout.ObjectField("Next Button:", myInspector.nextButtonComp, typeof(FPH_ComputerButtons), true);
			
			SerializedObject serTarget = new SerializedObject(target);
			SerializedProperty charaList = serTarget.FindProperty("cameraMat");
			EditorGUILayout.PropertyField(charaList, new GUIContent("Camera Materials:"), true);
			serTarget.ApplyModifiedProperties();
		}
		if(myInspector.buttonType == 2){ // ExitButton
			GUILayout.Space(10.0f); //Put some spece between different elements
			EditorGUIUtility.labelWidth = 110.0f;

			myInspector.buttonSprite = (SpriteRenderer) EditorGUILayout.ObjectField("Button Sprite:", myInspector.buttonSprite, typeof(SpriteRenderer), true);
			myInspector.pressedSprite = (Sprite) EditorGUILayout.ObjectField("Pressed Sprite:", myInspector.pressedSprite, typeof(Sprite), true);
			myInspector.releasedSprite = (Sprite) EditorGUILayout.ObjectField("Released Sprite:", myInspector.releasedSprite, typeof(Sprite), true);

			GUILayout.Space(10.0f); //Put some spece between different elements

			myInspector.inGameCamera = (GameObject) EditorGUILayout.ObjectField("InGame Camera:", myInspector.inGameCamera, typeof(GameObject), true);
			myInspector.closeupCamera = (GameObject) EditorGUILayout.ObjectField("Closeup Camera:", myInspector.closeupCamera, typeof(GameObject), true);
			myInspector.interactingCollider = (GameObject) EditorGUILayout.ObjectField("Interacting Collider:", myInspector.interactingCollider, typeof(GameObject), true);
		}
	}
}