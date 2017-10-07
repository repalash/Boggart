using UnityEngine;
using System.Collections;

public class FPH_ShowTextFile_Sprite : MonoBehaviour {

	public int neededInt;
	//public int moveToID;
	public bool existNextPage;

	public string englishTextFile;
	public string italianTextFile;
	public string spanishTextFile;
	public string germanTextFile;
	public string frenchTextFile;
	public string chineseTextFile;
	public string japaneseTextFile;
	public string russianTextFile;

	private bool showTextFile;


	public void ShowText(){
		FPH_LanguageManager.showTextObj_Sprite = this.gameObject;
		FPH_ControlManager.canBeControlled = false;
		showTextFile = true;
		FPH_ControlManager.isScreenLocked = false; // Screen.lockCursor = false;
	}

	void Update(){
		if(showTextFile && FPH_LanguageManager.showTextObj_Sprite == this.gameObject && FPH_LanguageManager.showTextID == neededInt){
			FPH_ControlManager.canBeControlled = false;

			// We show a page depending on game language
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
				FPH_ShowTextFile_Sprite_Manager.static_showTextSprite_TextMesh.text = englishTextFile;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
				FPH_ShowTextFile_Sprite_Manager.static_showTextSprite_TextMesh.text = italianTextFile;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
				FPH_ShowTextFile_Sprite_Manager.static_showTextSprite_TextMesh.text = spanishTextFile;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
				FPH_ShowTextFile_Sprite_Manager.static_showTextSprite_TextMesh.text = germanTextFile;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
				FPH_ShowTextFile_Sprite_Manager.static_showTextSprite_TextMesh.text = frenchTextFile;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
				FPH_ShowTextFile_Sprite_Manager.static_showTextSprite_TextMesh.text = chineseTextFile;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
				FPH_ShowTextFile_Sprite_Manager.static_showTextSprite_TextMesh.text = japaneseTextFile;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
				FPH_ShowTextFile_Sprite_Manager.static_showTextSprite_TextMesh.text = russianTextFile;
			}

			/*
			 * Next and back button aren't always on screen.
			 * Back button is shown only if we aren't on the first page.
			 * Next button is show only when a next page actually exist.
			 */
			if(FPH_LanguageManager.showTextID > 0){
				FPH_ShowTextFile_Sprite_Manager.static_showText_BackButton.SetActive(true);
			}
			if(FPH_LanguageManager.showTextID <= 0){
				FPH_ShowTextFile_Sprite_Manager.static_showText_BackButton.SetActive(false);
			}
			
			if(existNextPage){
				FPH_ShowTextFile_Sprite_Manager.static_showText_NextButton.SetActive(true);
			}
			if(!existNextPage){
				FPH_ShowTextFile_Sprite_Manager.static_showText_NextButton.SetActive(false);
			}
		}
	}

	public void ExitShowText(){
		FPH_LanguageManager.showTextObj_Sprite = null;
		FPH_ControlManager.canBeControlled = true;
		showTextFile = false;
		FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		FPH_LanguageManager.showTextID = 0;
		FPH_ShowTextFile_Sprite_Manager.static_showTextSprite_TextMesh.text = "";
	}
	
	public void MoveNextID(){
		if(showTextFile && FPH_LanguageManager.showTextObj_Sprite == this.gameObject && existNextPage){
			FPH_LanguageManager.showTextID++;
		}
	}
	
	public void MoveBackID(){
		if(FPH_LanguageManager.showTextID > 0){
			FPH_LanguageManager.showTextID = FPH_LanguageManager.showTextID - 1;
		}
	}

	public void AssignScript(){
		gameObject.AddComponent<FPH_ShowTextFile_Sprite>();
	}
}