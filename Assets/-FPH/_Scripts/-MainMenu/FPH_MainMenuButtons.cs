using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
public class FPH_MainMenuButtons : MonoBehaviour {

	public SpriteRenderer buttonSprite;
	public Sprite pressedSprite;
	public Sprite releasedSprite;
	public Sprite overSprite;
	public AudioClip buttonSound;
	public enum ButtonTypeEnum {NewGame, LoadGame, Settings}
	public ButtonTypeEnum buttonType = ButtonTypeEnum.NewGame;
	public string levelToLoad;
	public TextMesh loadLevelButtonLabel;
	
	private AudioSource audioSourceComp = null;
	private bool pressing;
	private bool calledChange;
	private bool calledLoad;
	private Collider thisCol;
	
	
	// Use this for initialization
	void Start(){
		calledChange = false;
		pressing = false;

		if(gameObject.GetComponent<AudioSource>()){
			audioSourceComp = gameObject.GetComponent<AudioSource>();
		}
		if(buttonType == ButtonTypeEnum.LoadGame){
			thisCol = gameObject.GetComponent<Collider>();
		}
	}
	
	// Update is called once per frame
	void Update(){
		if(calledChange && Camera.main.gameObject.GetComponent<FPH_FadeCamera>().alpha >= 1.0f){
			Application.LoadLevel(levelToLoad);
		}

		if(buttonType == ButtonTypeEnum.LoadGame){
			if(PlayerPrefs.HasKey("keyOldLevelToLoad")){
				thisCol.enabled = true;
				buttonSprite.color = new Color(buttonSprite.color.r, buttonSprite.color.g, buttonSprite.color.b, 1.0f);
				loadLevelButtonLabel.color = new Color(loadLevelButtonLabel.color.r, loadLevelButtonLabel.color.g, loadLevelButtonLabel.color.b, 1.0f);
				if(calledLoad && Camera.main.gameObject.GetComponent<FPH_FadeCamera>().alpha >= 1.0f){
					string oldLevel = PlayerPrefs.GetString("keyOldLevelToLoad");
					Application.LoadLevel(oldLevel);
				}
			}
			else{
				thisCol.enabled = false;
				buttonSprite.color = new Color(buttonSprite.color.r, buttonSprite.color.g, buttonSprite.color.b, 0.5f);
				loadLevelButtonLabel.color = new Color(loadLevelButtonLabel.color.r, loadLevelButtonLabel.color.g, loadLevelButtonLabel.color.b, 0.5f);
			}
		}
	}

	
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


	void OnMouseOver(){
		if(!pressing){
			buttonSprite.sprite = overSprite;
		}
	}
	void OnMouseExit(){
		pressing = false;
		buttonSprite.sprite = releasedSprite;
	}


	void HandleButtonDown(){
		pressing = true;
		buttonSprite.sprite = pressedSprite;
	}
	void HandleButtonUp(){
		pressing = false;
		if(buttonSound){
			audioSourceComp.PlayOneShot(buttonSound);
		}
		buttonSprite.sprite = releasedSprite;
		
		if(buttonType == ButtonTypeEnum.NewGame && !calledChange){
			calledChange = true;
			PlayerPrefs.DeleteAll();
			/*
			if(ES2.Exists("es2_keyInventoryName") && ES2.Exists("es2_keyInventoryTexture") && ES2.Exists("es2_keyInventoryDesc")){
				ES2.Delete("es2_keyInventoryName");
				ES2.Delete("es2_keyInventoryTexture");
				ES2.Delete("es2_keyInventoryDesc");
			}
			*/
			Camera.main.gameObject.GetComponent<FPH_FadeCamera>().FadeOut();
		}
		if(buttonType == ButtonTypeEnum.LoadGame && !calledLoad){
			calledLoad = true;
			Camera.main.gameObject.GetComponent<FPH_FadeCamera>().FadeOut();
		}
	}
}