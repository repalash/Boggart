using UnityEngine;
using System.Collections;

public class FPH_ComputerButtons : MonoBehaviour {
	
	public string[] buttonTypeArray = new string[] {"NextButton", "BackButton", "ExitButton"};
	public int buttonType;

	public GameObject planeObj;
	public Material[] cameraMat = new Material[]{};
	public int nextButtonInt;
	public FPH_ComputerButtons nextButtonComp;

	public SpriteRenderer buttonSprite;
	public Sprite pressedSprite;
	public Sprite releasedSprite;
	public GameObject inGameCamera;
	public GameObject closeupCamera;
	public GameObject interactingCollider;
	
	
	// Use this for initialization
	void Start () {
		if(buttonType == 0){
			nextButtonInt = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
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


	void HandleButtonUp(){
		if(buttonType == 0){
			if(nextButtonInt < cameraMat.Length){
				nextButtonInt++;
			}
			if(nextButtonInt == cameraMat.Length){
				nextButtonInt = 0;
			}

			planeObj.GetComponent<Renderer>().material = cameraMat[nextButtonInt];
		}
		if(buttonType == 1){
			if(nextButtonComp.nextButtonInt >= 0){
				nextButtonComp.nextButtonInt--;
			}
			if(nextButtonComp.nextButtonInt < 0){
				nextButtonComp.nextButtonInt = 0;
			}

			planeObj.GetComponent<Renderer>().material = cameraMat[nextButtonComp.nextButtonInt];
		}
		if(buttonType == 2){
			if(buttonSprite != null){
				buttonSprite.sprite = releasedSprite;
			}

			ExitButton();
		}
	}

	void HandleButtonDown(){
		if(buttonType == 2){
			if(buttonSprite != null){
				buttonSprite.sprite = pressedSprite;
			}
		}
	}

	void ExitButton(){
		FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = false;
		inGameCamera.SetActive(true);
		FPH_ControlManager.canBeControlled = true;
		interactingCollider.GetComponent<Collider>().enabled = true;
		closeupCamera.SetActive(false);
	}
}