using UnityEngine;
using System.Collections;

public class FPH_ChangeLevelOrPos : MonoBehaviour {
	
	public string[] observeKind = new string[] {"Normal", "Closeup"};
	public int observeInt = 0; // this variable is used inside of the Editor script
	
	public string[] interactionKind = new string[] {"Change Level", "Change Position"};
	public int interactionInt = 0; // this variable is used inside of the Editor script
	
	public string[] interactionType = new string[] {"Interaction", "OnTrigger"};
	public int interactionTypeInt = 0; // this variable is used inside of the Editor script

	public Vector3 newPos;
	public float canMoveAfter;
	
	public GameObject inGameCamera; // In case we observe with a closeup the gameplay camera will be toggled
	public GameObject closeupCamera; // In case we observe with a closeup the closeupCamera will be toggled
	public GameObject interactingCollider; // When we interact with this object and do a closeup we toggle its collider
	
	public float secToOserve = 1.3f; // After this amount of seconds the text will reset

	/*
	 * I decided to just toggle the UI but if you want to move it you can use a Tween engine
	 * and move and show/hide the UI where you see " changeLevelUI.SetActive(false); " or " changeLevelUI.SetActive(true); "
	 */
	public GameObject changeLevelUI; 

	public string levelToLoad; // The name of the level we want to load
	public string messageToShow_English;
	public string messageToShow_Italian;
	public string messageToShow_Spanish;
	public string messageToShow_German;
	public string messageToShow_French;
	public string messageToShow_Japanese;
	public string messageToShow_Chinese;
	public string messageToShow_Russian;
	
	public bool canBeObserved;
	public bool showChangeLevelText = true;
	public string observMessage_English;
	public string observMessage_Italian;
	public string observMessage_Spanish;
	public string observMessage_German;
	public string observMessage_French;
	public string observMessage_Japanese;
	public string observMessage_Chinese;
	public string observMessage_Russian;


	private FPH_FadeCamera fadeComp;
	private bool calledInteract;

	
	public static bool calledYes;
	public static bool calledNo;


	// Use this for initialization
	void Start(){
		if(GameObject.Find("-GameManager").GetComponent<FPH_FadeCamera>() && fadeComp == null){
			fadeComp = GameObject.Find("-GameManager").GetComponent<FPH_FadeCamera>();
		}

		calledInteract = false;
		calledNo = false;
		calledYes = false;
		if(changeLevelUI != null){
			changeLevelUI.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update(){
		// If the screen is black and we interacted with this change level object we can change level
		if(fadeComp.alpha == 1 && calledInteract){
			if(interactionInt == 0){
				Application.LoadLevel(levelToLoad);
			}
			if(interactionInt == 1){
				GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().localPosition = newPos;
				StartCoroutine("FadeBack");
			}
		}
	}

	
	public void Observe(){
		if(observeInt == 0){
			StartCoroutine("PrivateObserve_Normal");
		}
		if(observeInt == 1){
			StartCoroutine("PrivateObserve_Closeup");
		}
	}

	public void NoButton(){
		// If we press the " NO " button we hide this UI, reset some var and hide the mouse again
		changeLevelUI.SetActive(false);
		FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		calledNo = false;
		FPH_ControlManager.canBeControlled = true;
		calledInteract = false;
		FPH_ChangeLevel_ButtonUI.interactObj = null;
		if(showChangeLevelText){
			FPH_LanguageManager.static_observeTextMesh.text = "";
		}
	}

	public void YesButton(){
		// If we press the " YES " button we hide this UI, fade the screen and hide the mouse again
		changeLevelUI.SetActive(false);
		FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
		if(showChangeLevelText){
			FPH_LanguageManager.static_observeTextMesh.text = "";
		}
		calledYes = false;
		calledInteract = true;
		FPH_ChangeLevel_ButtonUI.interactObj = null;
		fadeComp.FadeOut();
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(interactionTypeInt == 1){
				changeLevelUI.SetActive(false);
				FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
				if(showChangeLevelText){
					FPH_LanguageManager.static_observeTextMesh.text = "";
				}
				calledYes = false;
				calledInteract = true;
				FPH_ChangeLevel_ButtonUI.interactObj = null;
				fadeComp.FadeOut();
			}
		}
	}

	IEnumerator FadeBack(){
		calledInteract = false;
		fadeComp.FadeIn();

		yield return new WaitForSeconds(1.0f);

		FPH_ControlManager.canBeControlled = true;
	}
	
	IEnumerator PrivateObserve_Normal(){
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){ // If language is ....
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_English; // Set this thext
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Italian;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Spanish;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_German;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_French;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Japanese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Chinese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Russian;
		}
		
		yield return new WaitForSeconds(secToOserve); // After " secToOserve " ...
		
		FPH_LanguageManager.static_observeTextMesh.text = ""; // Reset the text
	}

	/*
	 * We toggle the cameras and  show a text, everything will be reset
	 * after " secToOserve "
	 */
	IEnumerator PrivateObserve_Closeup(){
		inGameCamera.SetActive(false);
		closeupCamera.SetActive(true);
		interactingCollider.GetComponent<Collider>().enabled = false;
		FPH_ControlManager.canBeControlled = false;
		
		yield return new WaitForSeconds(0.1f);
		
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_English;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Italian;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Spanish;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_German;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_French;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Japanese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Chinese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Russian;
		}
		
		yield return new WaitForSeconds(secToOserve);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
		
		yield return new WaitForSeconds(0.3f);
		
		inGameCamera.SetActive(true);
		FPH_ControlManager.canBeControlled = true;
		interactingCollider.GetComponent<Collider>().enabled = true;
		closeupCamera.SetActive(false);
	}

	/*
	 * This is called when we interact with the change level object
	 * The player is not controllable anymore, we show the mouse,
	 * The UI and show a text to let the player know what's happening
	 */
	void ShowChangeLevel(){
		changeLevelUI.SetActive(true);
		FPH_ControlManager.isScreenLocked = false; // Screen.lockCursor = false;
		FPH_ControlManager.canBeControlled = false;
		FPH_ChangeLevel_ButtonUI.interactObj = this.gameObject;
		
		if(showChangeLevelText){
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
				FPH_LanguageManager.static_observeTextMesh.text = messageToShow_English;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
				FPH_LanguageManager.static_observeTextMesh.text = messageToShow_Italian;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
				FPH_LanguageManager.static_observeTextMesh.text = messageToShow_Spanish;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
				FPH_LanguageManager.static_observeTextMesh.text = messageToShow_German;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
				FPH_LanguageManager.static_observeTextMesh.text = messageToShow_French;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
				FPH_LanguageManager.static_observeTextMesh.text = messageToShow_Japanese;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
				FPH_LanguageManager.static_observeTextMesh.text = messageToShow_Chinese;
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
				FPH_LanguageManager.static_observeTextMesh.text = messageToShow_Russian;
			}
		}
	}
}
