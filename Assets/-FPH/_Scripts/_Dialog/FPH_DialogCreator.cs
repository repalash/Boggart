using UnityEngine;
using System.Collections;

public class FPH_DialogCreator : MonoBehaviour {
	//The dialog ID is used to switch dialog screen
	public int dialogID;
	
	//The name of the character
	public string characterName = "Name";
	
	public GameObject dialogObj;
	public Color textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
	public bool colorReset;
	public Color resetColor = new Color(0.0f, 0.0f, 0.0f, 1.0f); // When the dialog will end you'll probably want to reset

	public bool useDialogCameras;
	public GameObject cameraToDeactivate;
	public GameObject cameraToActivate;
	
	//The text which will be shown
	public string dialogText = "Dialog text goes here";
	public string dialogTextItalian = "Dialog text goes here (Italian)";
	public string dialogText_Spanish = "Dialog text goes here (Spanish)";
	public string dialogText_German = "Dialog text goes here (German)";
	public string dialogText_French = "Dialog text goes here (French)";
	public string dialogText_Japanese = "Dialog text goes here (Japanese)";
	public string dialogText_Chinese = "Dialog text goes here (Chinese)";
	public string dialogText_Russian = "Dialog text goes here (Russian)";
	
	//Change character sprite
	public bool changeCharaSprite;
	public SpriteRenderer[] characters;
	public Sprite[] charaSprite;
	
	//Move sprite
	public bool moveChara;
	public GameObject[] charactersToMove;
	public Vector3[] charactersNewPosition;
	public float[] timesToMove;
	
	//Fade sprite
	public bool fadeSprite;
	public SpriteRenderer[] spriteToFade;
	public float[] fadeToVal;
	public float[] timesToFade;
		
	//Flip character
	public bool flipChara;
	public GameObject[] charaToFlip;
	public Vector3[] rotateCharaTo;
	public float[] rotateInTime;
	
	//move to ID
	public int moveToID;
	
	//Audios
	public AudioClip charaVoiceClip;
	public AudioClip gameplayFxClip;
	
	//You can create two kind of dialog Standard (Next button) dialog
	//And mutiple dialog (up to four chooices)
	public string[] dialogTypeArray = new string[] {"Standard", "MultipleChoice"};
	public int dialogType;
	
	//The string for the three question you can ask
	public string questionOne;
	public string questionTwo;
	public string questionThree;
	public string questionFour;
	public string questionOne_Italian;
	public string questionTwo_Italian;
	public string questionThree_Italian;
	public string questionFour_Italian;
	public string questionOne_Spanish;
	public string questionTwo_Spanish;
	public string questionThree_Spanish;
	public string questionFour_Spanish;
	public string questionOne_German;
	public string questionTwo_German;
	public string questionThree_German;
	public string questionFour_German;
	public string questionOne_French;
	public string questionTwo_French;
	public string questionThree_French;
	public string questionFour_French;
	public string questionOne_Japanese;
	public string questionTwo_Japanese;
	public string questionThree_Japanese;
	public string questionFour_Japanese;
	public string questionOne_Chinese;
	public string questionTwo_Chinese;
	public string questionThree_Chinese;
	public string questionFour_Chinese;
	public string questionOne_Russian;
	public string questionTwo_Russian;
	public string questionThree_Russian;
	public string questionFour_Russian;
	
	// The ID we will brought to if we choose an answer
	public int questionOneToID;
	public int questionTwoToID;
	public int questionThreeToID;
	public int questionFourToID;
	
	//Is that the last dialog screen? Should I destroy it on dialog end?
	public bool isLastOne;
	public bool destroyOnEnd;
	public bool switchDialog;
	public GameObject newDialog;
	
	//Want to destroy object
	public bool wantToDestroyObj;
	public GameObject objToDestroy;
	
	//Want to send message to object
	public bool wantToSendMessageToObj;
	public GameObject objToSendMessage;
	public string messageToSend;
	
	private bool isPlayingThisDialog;
	private string internalDialogText;
	private string internalQuestionOne;
	private string internalQuestionTwo;
	private string internalQuestionThree;
	private string internalQuestionFour;
	private string buttonText;
	
	public static bool canGoOnNextScreen;
	
	public static bool canGoToQuestion01;
	public static bool canGoToQuestion02;
	public static bool canGoToQuestion03;
	public static bool canGoToQuestion04;

	private bool isShowingDialog = false;

	private bool playedCharaVoiceClip = false;
	private bool playedGameplayFxClip = false;
	
	// private Transform nextButtonTrans;
	// private Transform questionTrans;
	
	void Start(){
		// nextButtonTrans = FPH_DialogManager.staticNextButton.GetComponent<Transform>();
		// questionTrans = FPH_DialogManager.staticQuestionUI.GetComponent<Transform>();
	}
	
	void Update(){
		ShowCurrentDialog();
		HandleNextSentenceStuff();
	}
	
	public void AssignScript(){
		gameObject.AddComponent<FPH_DialogCreator>();
	}
	
	public void Play(){
		FPH_DialogManager.isEnabled = true;
		isPlayingThisDialog = true;
	}
	
	public void Stop(){
		if(dialogObj != null){
			if(dialogObj.activeSelf){
				dialogObj.SetActive(false);
			}
		}
		FPH_DialogManager.isEnabled = false;
		isPlayingThisDialog = false;
		FPH_DialogManager.privateID = 0;
		FPH_DialogManager.currentDialog = null;
		FPH_ControlManager.canBeControlled = true;
		FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = false;
	}
	
	void ShowCurrentDialog(){
		if(FPH_DialogManager.isEnabled && dialogID == FPH_DialogManager.privateID && isPlayingThisDialog && FPH_DialogManager.currentDialog == this.gameObject){	
			FPH_ControlManager.canBeControlled = false;

			if(changeCharaSprite){
				for(int i = 0; i < characters.Length; i++){
					characters[i].sprite = charaSprite[i];
				}
			}
			if(moveChara){
				for(int i = 0; i < charactersToMove.Length; i++){
					iTween.MoveTo(charactersToMove[i], iTween.Hash("position", charactersNewPosition[i], "islocal", true, "time", timesToMove[i]));
				}
			}
			if(fadeSprite){
				for(int i = 0; i < spriteToFade.Length; i++){
					iTween.ColorTo(spriteToFade[i].gameObject, new Color(spriteToFade[i].color.r, spriteToFade[i].color.g, spriteToFade[i].color.b, fadeToVal[i]), timesToFade[i]);
				}
			}
			if(flipChara){
				for(int i = 0; i < charaToFlip.Length; i++){
					iTween.RotateTo(charaToFlip[i], rotateCharaTo[i], rotateInTime[i]);
				}
			}

			if(charaVoiceClip != null && !playedCharaVoiceClip){
				playedCharaVoiceClip = true;
				FPH_DialogManager.staticCharaVoice.PlayOneShot(charaVoiceClip);
			}
			if(gameplayFxClip != null && !playedGameplayFxClip){
				playedGameplayFxClip = true;
				FPH_DialogManager.staticGameplayFX.PlayOneShot(gameplayFxClip);
			}

			if(useDialogCameras){
				cameraToDeactivate.SetActive(false);
				cameraToActivate.SetActive(true);
			}
			
			#region StandardDialog
			//if it's a standard dialog
			if(dialogType == 0){
				//Show Dialog hide question
				FPH_DialogManager.staticNextButton.SetActive(true);
				FPH_DialogManager.staticQuestionUI.SetActive(false);

				// nextButtonTrans.localPosition = new Vector3(7.8f, -4.487991f, 0.543027f);
				// questionTrans.localPosition = new Vector3(7.0f, 0.0f, 0.0f);
				
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
					internalDialogText = dialogText;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
					internalDialogText = dialogTextItalian;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
					internalDialogText = dialogText_Spanish;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
					internalDialogText = dialogText_German;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
					internalDialogText = dialogText_French;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
					internalDialogText = dialogText_Japanese;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
					internalDialogText = dialogText_Chinese;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
					internalDialogText = dialogText_Russian;
				}
				
				FPH_DialogManager.staticDialogText.color = textColor;

				if(FPH_DialogManager.staticTypewriterStyleShow){
					//show dialog and character name label
					if(FPH_DialogManager.staticNameText != null){
						if(characterName.Length >= 1){
							FPH_DialogManager.staticNameText.text = characterName;
						}
						else{
							FPH_DialogManager.staticNameText.text = "";
						}
					}
					if(!isShowingDialog){
						if(FPH_DialogManager.staticNameText == null){
							if(characterName.Length >= 1){
								StartCoroutine("ShowDialog", characterName + ": " + internalDialogText);
							}
							else{
								StartCoroutine("ShowDialog", internalDialogText);
							}
						}
						else{
							StartCoroutine("ShowDialog", internalDialogText);
						}
					}
				}
				else{
					if(FPH_DialogManager.staticNameText != null){
						if(characterName.Length >= 1){
							FPH_DialogManager.staticNameText.text = characterName;
							FPH_DialogManager.staticDialogText.text = internalDialogText;
						}
						else{
							FPH_DialogManager.staticNameText.text = "";
							FPH_DialogManager.staticDialogText.text = internalDialogText;
						}
					}
					if(FPH_DialogManager.staticNameText == null){
						if(characterName.Length >= 1){
							FPH_DialogManager.staticDialogText.text = characterName + ": " + internalDialogText;
						}
						else{
							FPH_DialogManager.staticDialogText.text = internalDialogText;
						}
					}
				}

				// FPH_DialogManager.staticDialogText.text = internalDialogText;
			}
			#endregion
			
			#region MultipleQuestion
			//It's a multiple choice dialog
			if(dialogType == 1){
				//Show question hide dialog
				FPH_DialogManager.staticNextButton.SetActive(false);
				FPH_DialogManager.staticQuestionUI.SetActive(true);

				// nextButtonTrans.localPosition = new Vector3(11.0f, -4.487991f, 0.543027f);
				// questionTrans.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
				FPH_DialogManager.staticDialogText.text = "";
				
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
					internalQuestionOne = questionOne;
					internalQuestionTwo = questionTwo;
					internalQuestionThree = questionThree;
					internalQuestionFour = questionFour;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
					internalQuestionOne = questionOne_Italian;
					internalQuestionTwo = questionTwo_Italian;
					internalQuestionThree = questionThree_Italian;
					internalQuestionFour = questionFour_Italian;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
					internalQuestionOne = questionOne_Spanish;
					internalQuestionTwo = questionTwo_Spanish;
					internalQuestionThree = questionThree_Spanish;
					internalQuestionFour = questionFour_Spanish;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
					internalQuestionOne = questionOne_German;
					internalQuestionTwo = questionTwo_German;
					internalQuestionThree = questionThree_German;
					internalQuestionFour = questionFour_German;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
					internalQuestionOne = questionOne_French;
					internalQuestionTwo = questionTwo_French;
					internalQuestionThree = questionThree_French;
					internalQuestionFour = questionFour_French;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
					internalQuestionOne = questionOne_Japanese;
					internalQuestionTwo = questionTwo_Japanese;
					internalQuestionThree = questionThree_Japanese;
					internalQuestionFour = questionFour_Japanese;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
					internalQuestionOne = questionOne_Chinese;
					internalQuestionTwo = questionTwo_Chinese;
					internalQuestionThree = questionThree_Chinese;
					internalQuestionFour = questionFour_Chinese;
				}
				if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
					internalQuestionOne = questionOne_Russian;
					internalQuestionTwo = questionTwo_Russian;
					internalQuestionThree = questionThree_Russian;
					internalQuestionFour = questionFour_Russian;
				}
				
				// Is the question text is different than "" or " " we can display the button and give to the button labe the question text
				if(internalQuestionOne == "" || internalQuestionOne == " "){
					FPH_DialogManager.staticQuestion01Obj.SetActive(false);
				}
				if(internalQuestionOne != "" || internalQuestionOne == " "){
					FPH_DialogManager.staticQuestion01Obj.SetActive(true);
					FPH_DialogManager.staticQuestion01Text.text = internalQuestionOne;
				}
				
				if(internalQuestionTwo == "" || internalQuestionTwo == " "){
					FPH_DialogManager.staticQuestion02Obj.SetActive(false);
				}
				if(internalQuestionTwo != "" || internalQuestionTwo == " "){
					FPH_DialogManager.staticQuestion02Obj.SetActive(true);
					FPH_DialogManager.staticQuestion02Text.text = internalQuestionTwo;
				}
				
				if(internalQuestionThree == "" || internalQuestionThree == " "){
					FPH_DialogManager.staticQuestion03Obj.SetActive(false);
				}
				if(internalQuestionThree != "" || internalQuestionThree == " "){
					FPH_DialogManager.staticQuestion03Obj.SetActive(true);
					FPH_DialogManager.staticQuestion03Text.text = internalQuestionThree;
				}
				
				if(internalQuestionFour == "" || internalQuestionFour == " "){
					FPH_DialogManager.staticQuestion04Obj.SetActive(false);
				}
				if(internalQuestionFour != "" || internalQuestionFour == " "){
					FPH_DialogManager.staticQuestion04Obj.SetActive(true);
					FPH_DialogManager.staticQuestion04Text.text = internalQuestionFour;
				}
			}	
			#endregion
		}
	}

	IEnumerator ShowDialog(string dialogText){
		isShowingDialog = true;

		for(int i = 0; i <= dialogText.Length; i ++){
			FPH_DialogManager.staticDialogText.text = dialogText.Substring(0, i);
			//PlaySoundHere
			yield return new WaitForSeconds(FPH_DialogManager.dialogSpeed);
		}
	}

	void HandleNextSentenceStuff(){
		if(canGoOnNextScreen == true && FPH_DialogManager.isEnabled && dialogID == FPH_DialogManager.privateID && isPlayingThisDialog && FPH_DialogManager.currentDialog == this.gameObject){
			GoToNextScreen();
		}
		
		if(canGoToQuestion01 == true && FPH_DialogManager.isEnabled && dialogID == FPH_DialogManager.privateID && isPlayingThisDialog && FPH_DialogManager.currentDialog == this.gameObject){
			canGoToQuestion01 = false;
			FPH_DialogManager.privateID = questionOneToID;
		}
		if(canGoToQuestion02 == true && FPH_DialogManager.isEnabled && dialogID == FPH_DialogManager.privateID && isPlayingThisDialog && FPH_DialogManager.currentDialog == this.gameObject){
			canGoToQuestion02 = false;
			FPH_DialogManager.privateID = questionTwoToID;
		}
		if(canGoToQuestion03 == true && FPH_DialogManager.isEnabled && dialogID == FPH_DialogManager.privateID && isPlayingThisDialog && FPH_DialogManager.currentDialog == this.gameObject){
			canGoToQuestion03 = false;
			FPH_DialogManager.privateID = questionThreeToID;
		}
		if(canGoToQuestion04 == true && FPH_DialogManager.isEnabled && dialogID == FPH_DialogManager.privateID && isPlayingThisDialog && FPH_DialogManager.currentDialog == this.gameObject){
			canGoToQuestion04 = false;
			FPH_DialogManager.privateID = questionFourToID;
		}
	}
	
	// This is called when we move to another dialog
	void GoToNextScreen(){
		//StopCoroutine("ShowDialog");
		isShowingDialog = false;
		canGoOnNextScreen = false;
		playedCharaVoiceClip = false;
		playedGameplayFxClip = false;

		FPH_DialogManager.staticCharaVoice.Stop();
		FPH_DialogManager.staticGameplayFX.Stop();

		if(!isLastOne){
			if(wantToDestroyObj){
				Destroy(objToDestroy);
			}
			if(wantToSendMessageToObj){
				objToSendMessage.SendMessage(messageToSend);
			}
			FPH_DialogManager.privateID = moveToID;
		}
		if(isLastOne){
			FPH_DialogManager.staticDialogText.text = "";
			
			if(colorReset){
				FPH_DialogManager.staticDialogText.color = resetColor;
			}
			if(wantToDestroyObj){
				Destroy(objToDestroy);
			}
			if(wantToSendMessageToObj){
				objToSendMessage.SendMessage(messageToSend);
			}
			
			if(switchDialog){
				if(destroyOnEnd){
					this.gameObject.GetComponent<FPH_DialogCreator>().Stop();
					newDialog.SetActive(true);
					FPH_DialogManager.currentDialog = newDialog;
					newDialog.GetComponent<FPH_DialogCreator>().Play();
					Destroy(gameObject);
				}
				if(!destroyOnEnd){
					this.gameObject.GetComponent<FPH_DialogCreator>().Stop();
					newDialog.SetActive(true);
					FPH_DialogManager.currentDialog = newDialog;
					newDialog.GetComponent<FPH_DialogCreator>().Play();
					this.gameObject.SetActive(false);
				}
			}
			if(!switchDialog){
				if(destroyOnEnd){
					Stop();
					Destroy(gameObject);
				}
				if(!destroyOnEnd){
					Stop();
				}
			}
		}
	}
}