using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_PlayerController))] 
public class Editor_FPH_PlayerController : Editor {
	public override void OnInspectorGUI() {
		FPH_PlayerController myInspector = (FPH_PlayerController) target;

		EditorGUIUtility.labelWidth = 80.0f;
		myInspector.playerType = EditorGUILayout.Popup("Player Type:", myInspector.playerType, myInspector.playerTypeArray);
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		if(myInspector.playerType == 0){
			EditorGUIUtility.labelWidth = 120.0f;
			myInspector.runByDefault = EditorGUILayout.Toggle("Run by default?", myInspector.runByDefault);
			
			GUILayout.BeginHorizontal();
			myInspector.walkSpeed = EditorGUILayout.FloatField("Walk Speed:", myInspector.walkSpeed);
			myInspector.runSpeed = EditorGUILayout.FloatField("Run Speed:", myInspector.runSpeed);
			GUILayout.EndHorizontal();

			myInspector.gravityMultiplier = EditorGUILayout.FloatField("Gravity Multiplier:", myInspector.gravityMultiplier);
			myInspector.groundStickyEffect = EditorGUILayout.FloatField("Ground Sticky Effect:", myInspector.groundStickyEffect);
			myInspector.handObj = (GameObject) EditorGUILayout.ObjectField("Player Hand Object:", myInspector.handObj, typeof(GameObject), true);
		}
		if(myInspector.playerType == 1){
			EditorGUIUtility.labelWidth = 150.0f;
			myInspector.camerasObj = (GameObject) EditorGUILayout.ObjectField("Cameras Holder Object:", myInspector.camerasObj, typeof(GameObject), true);
			myInspector.charaObj = (Animation) EditorGUILayout.ObjectField("Character Object:", myInspector.charaObj, typeof(Animation), true);
			
			EditorGUILayout.LabelField("Animations:");
			GUILayout.BeginHorizontal();
			EditorGUI.indentLevel = 1;
			EditorGUIUtility.labelWidth = 50.0f;
			myInspector.idleAnimation = (AnimationClip) EditorGUILayout.ObjectField("Idle:", myInspector.idleAnimation, typeof(AnimationClip), true);
			myInspector.walkAnimation = (AnimationClip) EditorGUILayout.ObjectField("Walk:", myInspector.walkAnimation, typeof(AnimationClip), true);
			EditorGUI.indentLevel = 0;
			GUILayout.EndHorizontal();
			
			GUILayout.Space(5.0f); //Put some spece between different elements
			EditorGUIUtility.labelWidth = 150.0f;
			myInspector.walkMaxAnimationSpeed = EditorGUILayout.FloatField("Max Walk Animation Speed:", myInspector.walkMaxAnimationSpeed);
			myInspector.thirdWalkSpeed = EditorGUILayout.FloatField("Walk Speed:", myInspector.thirdWalkSpeed);
			myInspector.gravity = EditorGUILayout.FloatField("Gravity Multiplier:", myInspector.gravity);
			myInspector.speedSmoothing = EditorGUILayout.FloatField("Speed Smothing:", myInspector.speedSmoothing);
			myInspector.rotateSpeed = EditorGUILayout.FloatField("Rotate Speed:", myInspector.rotateSpeed);
		}

		GUILayout.Space(10.0f); //Put some spece between different elements
	}
}