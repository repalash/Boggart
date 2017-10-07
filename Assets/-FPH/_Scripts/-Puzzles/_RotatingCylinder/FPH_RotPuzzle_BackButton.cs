using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class FPH_RotPuzzle_BackButton : MonoBehaviour {
	
	public FPH_RotPuzzle_Interactor puzzleInteractor;
	public SpriteRenderer buttonSprite;
	public Sprite pressedSprite;
	public Sprite releasedSprite;
	public AudioClip buttonSound;

	private AudioSource audioSourceComp = null;


	// Use this for initialization
	void Start () {
		if(gameObject.GetComponent<AudioSource>()){
			audioSourceComp = gameObject.GetComponent<AudioSource>();
		}
	}
	
	// Update is called once per frame
	void Update(){
		
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


	void HandleButtonDown(){
		buttonSprite.sprite = pressedSprite;
	}
	
	void HandleButtonUp(){
		buttonSprite.sprite = releasedSprite;
		if(buttonSound){
			audioSourceComp.PlayOneShot(buttonSound);
		}

		puzzleInteractor.ExitRotPuzzle();
	}
}
