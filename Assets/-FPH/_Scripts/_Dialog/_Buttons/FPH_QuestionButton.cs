using UnityEngine;
using System.Collections;

public class FPH_QuestionButton : MonoBehaviour {
	
	public enum QuestionsEnum {Question01, Question02, Question03, Question04}
	public QuestionsEnum questionType = QuestionsEnum.Question01;
	// public SpriteRenderer buttonSprite;
	// public Sprite spriteReleased;
	// public Sprite spritePressed;

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
	
	public void OnCustomMouseDown(){
		HandleButtonDown();
	}
	public void OnTouchDown(){
		HandleButtonDown();
	}
	*/

	public void HandleButtonUp(){
		// buttonSprite.sprite = spriteReleased;

		if(questionType == QuestionsEnum.Question01){
			FPH_DialogCreator.canGoToQuestion01 = true;
		}
		if(questionType == QuestionsEnum.Question02){
			FPH_DialogCreator.canGoToQuestion02 = true;
		}
		if(questionType == QuestionsEnum.Question03){
			FPH_DialogCreator.canGoToQuestion03 = true;
		}
		if(questionType == QuestionsEnum.Question04){
			FPH_DialogCreator.canGoToQuestion04 = true;
		}
	}
	/*
	void HandleButtonDown(){
		buttonSprite.sprite = spritePressed;
	}
	*/
}