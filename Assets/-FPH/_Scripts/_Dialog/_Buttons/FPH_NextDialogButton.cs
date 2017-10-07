using UnityEngine;
using System.Collections;

public class FPH_NextDialogButton : MonoBehaviour {
	/*
	public SpriteRenderer buttonSprite;
	public Sprite spriteReleased;
	public Sprite spritePressed;
	*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	public void OnCustomMouseUp(){
		HandleButtonUp();
	}
	public void OnTouchUp(){
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
		FPH_DialogCreator.canGoOnNextScreen = true;
		// buttonSprite.sprite = spriteReleased;
	}
	/*
	void HandleButtonDown(){
		buttonSprite.sprite = spritePressed;
	}
	*/
}