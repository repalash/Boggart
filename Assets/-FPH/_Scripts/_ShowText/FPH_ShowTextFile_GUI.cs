using UnityEngine;
using System.Collections;

public class FPH_ShowTextFile_GUI : MonoBehaviour {

	public string englishTextFile;
	public string italianTextFile;
	public string spanishTextFile;
	public string germanTextFile;
	public string frenchTextFile;
	public string chineseTextFile;
	public string japaneseTextFile;
	public string russianTextFile;

	public GUISkin showTextGuiSkin;

	private bool showTextFile; //public static

	private Vector2 scrollPosition;
	

	public void ShowText(){
		FPH_LanguageManager.showTextObj = this.gameObject;
		showTextFile = true;
		FPH_ControlManager.isScreenLocked = false; // Screen.lockCursor = false;
	}

	void OnGUI(){
		if(showTextFile && FPH_LanguageManager.showTextObj == this.gameObject){
			FPH_ControlManager.canBeControlled = false;

			foreach(Touch touch in Input.touches){
				if (touch.phase == TouchPhase.Moved){
					scrollPosition.y += touch.deltaPosition.y;
				}
			}
			GUI.skin = showTextGuiSkin;
			GUI.BeginGroup(new Rect((Screen.width/2.0f) - (Screen.width * 0.29296875f), (Screen.height/2.0f) - (Screen.height * 0.381944444f), (Screen.width * 0.5859375f), (Screen.height * 0.763888888f)));


			GUI.Box(new Rect(0, 0, (Screen.width * 0.5859375f), (Screen.height * 0.763888888f)), "");

			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight((Screen.height * 0.763888888f)), GUILayout.ExpandHeight (false), GUILayout.Width((Screen.width * 0.5859375f)));
			
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
				GUILayout.Label(englishTextFile, GUILayout.ExpandHeight(true));
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
				GUILayout.Label(italianTextFile, GUILayout.ExpandHeight(true));
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
				GUILayout.Label(spanishTextFile, GUILayout.ExpandHeight(true));
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
				GUILayout.Label(germanTextFile, GUILayout.ExpandHeight(true));
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
				GUILayout.Label(frenchTextFile, GUILayout.ExpandHeight(true));
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
				GUILayout.Label(chineseTextFile, GUILayout.ExpandHeight(true));
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
				GUILayout.Label(japaneseTextFile, GUILayout.ExpandHeight(true));
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
				GUILayout.Label(russianTextFile, GUILayout.ExpandHeight(true));
			}

			GUILayout.EndScrollView();


			GUI.EndGroup();

			if(GUI.Button(new Rect((Screen.width * 0.796875f), (Screen.height * 0.902777777f), (Screen.width * 0.09375f), (Screen.height * 0.083333333f)), "Back")){
				FPH_LanguageManager.showTextObj = null;
				FPH_ControlManager.canBeControlled = true;
				showTextFile = false;
				FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
			}
		}
	}
}

