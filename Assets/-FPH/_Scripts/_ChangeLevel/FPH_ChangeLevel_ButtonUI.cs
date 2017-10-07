using UnityEngine;
using System.Collections;

public class FPH_ChangeLevel_ButtonUI : MonoBehaviour {

	/*
	 * This script is for both " YES " and " NO " change level button
	 * the player can also call" YES " or " NO " with buttons.
	 */

	public enum ChangeLevelButtonEnum {Yes, No}

	public ChangeLevelButtonEnum buttonType = ChangeLevelButtonEnum.Yes;
	// public SpriteRenderer buttonSprite;
	// public Sprite releasedSprite;
	// public Sprite pressedSprite;

	public static GameObject interactObj;


	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){
		if(interactObj != null){
			if(buttonType == ChangeLevelButtonEnum.Yes){
				if(Input.GetKeyUp(FPH_ControlManager.static_changeLevelYes_Button)){
					interactObj.GetComponent<FPH_ChangeLevelOrPos>().YesButton();
				}
			}
			if(buttonType == ChangeLevelButtonEnum.No){
				if(Input.GetKeyUp(FPH_ControlManager.static_changeLevelNo_Button)){
					interactObj.GetComponent<FPH_ChangeLevelOrPos>().NoButton();
				}
			}
		}
	}

	/*
	public void OnTouchUp(){
		HandleButtonUp();
	}
	public void OnCustomMouseUp(){
		HandleButtonUp();
	}

	public void OnTouchDown(){
		HandleButtonDown();
	}
	public void OnCustomMouseDown(){
		HandleButtonDown();
	}
	*/

	public void HandleButtonUp(){
		// buttonSprite.sprite = releasedSprite;

		if(interactObj != null){
			if(buttonType == ChangeLevelButtonEnum.Yes){
				interactObj.GetComponent<FPH_ChangeLevelOrPos>().YesButton();
			}
			if(buttonType == ChangeLevelButtonEnum.No){
				interactObj.GetComponent<FPH_ChangeLevelOrPos>().NoButton();
			}
		}
	}
	/*
	void HandleButtonDown(){
		buttonSprite.sprite = pressedSprite;
	}
	*/
}