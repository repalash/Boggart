using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPH_DialogManager : MonoBehaviour {
	
	// GUI
	public GameObject dialogUI;
	public GameObject questionUI;
	public GameObject nextButton;
	public Text dialogText;
	public Text nameText;
	public Text question01Text;
	public Text question02Text;
	public Text question03Text;
	public Text question04Text;
	public GameObject question01Obj;
	public GameObject question02Obj;
	public GameObject question03Obj;
	public GameObject question04Obj;
	public AudioSource charaVoice;
	public AudioSource gameplayFX;
	public bool typewriterStyleShow = false;
	public float baseDialogSpeed = 0.05f;
	public float maxDialogSpeed = 0.1f; //Lower is faster
	
	// These var determinate if a dialog is playing
	public static bool isEnabled;
	public static int privateID;
	public static GameObject currentDialog;
	
	// static GUI
	public static GameObject staticDialogUI;
	public static GameObject staticQuestionUI;
	public static Text staticDialogText;
	public static Text staticNameText;
	public static Text staticQuestion01Text;
	public static Text staticQuestion02Text;
	public static Text staticQuestion03Text;
	public static Text staticQuestion04Text;
	public static GameObject staticQuestion01Obj;
	public static GameObject staticQuestion02Obj;
	public static GameObject staticQuestion03Obj;
	public static GameObject staticQuestion04Obj;
	public static GameObject staticNextButton;
	public static GameObject staticDialogTextObj;
	public static AudioSource staticCharaVoice;
	public static AudioSource staticGameplayFX;
	public static GameObject thisObj;
	public static float dialogSpeed;
	public static bool isFullscreen;
	public static float staticMaxDialogSpeed;
	public static bool showSettingMenu;
	public static bool staticTypewriterStyleShow;
	public static float staticMinAutoDialogSpeed;
	public static float staticMaxAutoDialogSpeed;
	public static float currentAutoDialogSpeed;
	
	
	// Use this for initialization
	void Awake(){
		thisObj = gameObject;
		
		if(PlayerPrefs.HasKey("keyDialogSpeed")){
			dialogSpeed = PlayerPrefs.GetFloat("keyDialogSpeed");
		}
		else{
			dialogSpeed = baseDialogSpeed;
		}
		
		//GUI
		staticDialogUI = dialogUI;
		staticQuestionUI = questionUI;
		
		staticDialogText = dialogText;
		staticNameText = nameText;
		
		staticQuestion01Text = question01Text;
		staticQuestion02Text = question02Text;
		staticQuestion03Text = question03Text;
		staticQuestion04Text = question04Text;
		
		staticQuestion01Obj = question01Obj;
		staticQuestion02Obj = question02Obj;
		staticQuestion03Obj = question03Obj;
		staticQuestion04Obj = question04Obj;
		
		staticNextButton = nextButton;

		staticCharaVoice = charaVoice;
		staticGameplayFX = gameplayFX;

		staticTypewriterStyleShow = typewriterStyleShow;

		staticMaxDialogSpeed = maxDialogSpeed;
	}
	
	void Update(){
		if(isEnabled){
			dialogUI.SetActive(true);
			FPH_ControlManager.isScreenLocked = false; // Screen.lockCursor = false;
		}
		if(!isEnabled){
			dialogUI.SetActive(false);
		}

		if(PlayerPrefs.HasKey("keyCharaVoiceVolume")){
			staticCharaVoice.volume = PlayerPrefs.GetFloat("keyCharaVoiceVolume");
		}
		if(PlayerPrefs.HasKey("keyGameplayFXVolume")){
			staticGameplayFX.volume = PlayerPrefs.GetFloat("keyGameplayFXVolume");
		}
	}
}