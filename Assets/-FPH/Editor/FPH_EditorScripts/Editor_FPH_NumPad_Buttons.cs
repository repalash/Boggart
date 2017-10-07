using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FPH_NumPad_Buttons))] 
public class Editor_FPH_NumPad_Buttons : Editor {
	
	public override void OnInspectorGUI() {
		FPH_NumPad_Buttons myInspector = (FPH_NumPad_Buttons) target;
		
		GUILayout.Space(10.0f); //Put some spece between different elements

		EditorGUIUtility.labelWidth = 77.0f;
		myInspector.buttonType = EditorGUILayout.Popup("Button Type:", myInspector.buttonType, myInspector.buttonTypeArray);
	
		EditorGUIUtility.labelWidth = 130.0f;
		myInspector.numPadInteractObj = (GameObject) EditorGUILayout.ObjectField("Numpad Object: ", myInspector.numPadInteractObj, typeof(GameObject), true);
		
		if(myInspector.buttonType == 0){ // Numeric
			GUILayout.Space(10.0f); //Put some spece between different elements

			myInspector.numPadTextMesh = (TextMesh) EditorGUILayout.ObjectField("Numpad TextMesh: ", myInspector.numPadTextMesh, typeof(TextMesh), true);
			myInspector.aniToPlay = EditorGUILayout.TextField("Animation to play:", myInspector.aniToPlay);
			myInspector.buttonValue = EditorGUILayout.Popup("Button Value:", myInspector.buttonValue, myInspector.buttonValueArray);
			myInspector.maxLenghtCode = EditorGUILayout.IntField("Code Max Lenght:", myInspector.maxLenghtCode);
			myInspector.pressNumButtonSound = (AudioClip) EditorGUILayout.ObjectField("Numpad Button Sound: ", myInspector.pressNumButtonSound, typeof(AudioClip), true);
		}
		if(myInspector.buttonType == 1){ // Backspace
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			myInspector.numPadTextMesh = (TextMesh) EditorGUILayout.ObjectField("Numpad TextMesh: ", myInspector.numPadTextMesh, typeof(TextMesh), true);
			myInspector.aniToPlay = EditorGUILayout.TextField("Animation to play:", myInspector.aniToPlay);
			myInspector.pressNumButtonSound = (AudioClip) EditorGUILayout.ObjectField("Numpad Button Sound: ", myInspector.pressNumButtonSound, typeof(AudioClip), true);
		}
		if(myInspector.buttonType == 2){ // Confirm
			GUILayout.Space(10.0f); //Put some spece between different elements
			
			myInspector.numPadTextMesh = (TextMesh) EditorGUILayout.ObjectField("Numpad TextMesh: ", myInspector.numPadTextMesh, typeof(TextMesh), true);
			myInspector.aniToPlay = EditorGUILayout.TextField("Animation to play:", myInspector.aniToPlay);
			myInspector.rightCodeSound = (AudioClip) EditorGUILayout.ObjectField("Right Code Sound: ", myInspector.rightCodeSound, typeof(AudioClip), true);
			myInspector.wrongCodeSound = (AudioClip) EditorGUILayout.ObjectField("Wrong Code Sound: ", myInspector.wrongCodeSound, typeof(AudioClip), true);
			myInspector.pressNumButtonSound = (AudioClip) EditorGUILayout.ObjectField("Numpad Button Sound: ", myInspector.pressNumButtonSound, typeof(AudioClip), true);
		}
		if(myInspector.buttonType == 3){
			myInspector.buttonSprite = (SpriteRenderer) EditorGUILayout.ObjectField("Button Sprite Obj: ", myInspector.buttonSprite, typeof(SpriteRenderer), true);
			myInspector.pressedSprite = (Sprite) EditorGUILayout.ObjectField("Pressed Sprite: ", myInspector.pressedSprite, typeof(Sprite), true);
			myInspector.releasedSprite = (Sprite) EditorGUILayout.ObjectField("Released Sprite: ", myInspector.releasedSprite, typeof(Sprite), true);
		}
	}
}