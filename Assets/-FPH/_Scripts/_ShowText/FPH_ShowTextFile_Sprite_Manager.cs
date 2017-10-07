using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPH_ShowTextFile_Sprite_Manager : MonoBehaviour {
	
	public GameObject showTextSpriteUI;
	public GameObject showText_NextButton;
	public GameObject showText_BackButton;
	public Text showTextSprite_TextMesh;
	
	public static Text static_showTextSprite_TextMesh;
	public static GameObject static_showText_NextButton;
	public static GameObject static_showText_BackButton;


	// Use this for initialization
	void Start(){
		static_showTextSprite_TextMesh = showTextSprite_TextMesh;
		static_showText_NextButton = showText_NextButton;
		static_showText_BackButton = showText_BackButton;
	}
	
	// Update is called once per frame
	void Update(){
		if(FPH_LanguageManager.showTextObj_Sprite != null){
			showTextSpriteUI.SetActive(true);
		}
		if(FPH_LanguageManager.showTextObj_Sprite == null){
			showTextSpriteUI.SetActive(false);
		}
	}
}
