using UnityEngine;
using System.Collections;

public class FPH_ShowTextFile_Sprite_Buttons : MonoBehaviour {
	
	public enum ButtonEnum {Back, Next, Exit}
	public ButtonEnum buttonType = ButtonEnum.Back;

	// public SpriteRenderer buttonSprite;
	// public Sprite spriteReleased;
	// public Sprite spritePressed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){

	}
	/*
	public void OnCustomMouseUp(){
		HandleButtonUp();
	}
	public void OnTouchUp(){
		HandleButtonUp();
	}
	
	public void OnCustomMouseDown(){
		HandleButtonDown();
	}
	public void OnTouchDown(){
		HandleButtonDown();
	}
	*/
	
	public void HandleButtonUp(){
		// buttonSprite.sprite = spriteReleased;

		if(buttonType == ButtonEnum.Back){
			FPH_LanguageManager.showTextObj_Sprite.GetComponent<FPH_ShowTextFile_Sprite>().MoveBackID();
		}
		if(buttonType == ButtonEnum.Next){
			FPH_LanguageManager.showTextObj_Sprite.GetComponent<FPH_ShowTextFile_Sprite>().MoveNextID();
		}
		if(buttonType == ButtonEnum.Exit){
			FPH_LanguageManager.showTextObj_Sprite.GetComponent<FPH_ShowTextFile_Sprite>().ExitShowText();
		}
	}
	/*
	void HandleButtonDown(){
		buttonSprite.sprite = spritePressed;
	}
	*/
}
