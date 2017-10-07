using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class FPH_NumPad_Buttons : MonoBehaviour {
	
	public string[] buttonTypeArray = new string[] {"Numeric", "Backspace", "Confirm", "Exit"};
	public int buttonType;
	
	public GameObject numPadInteractObj;

	public string aniToPlay = "FPH_NumPad_Press0";
	public TextMesh numPadTextMesh;

	public string[] buttonValueArray = new string[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
	public int buttonValue;
	public int maxLenghtCode = 4;
	
	public AudioClip pressNumButtonSound;
	public AudioClip rightCodeSound;
	public AudioClip wrongCodeSound;

	public SpriteRenderer buttonSprite;
	public Sprite pressedSprite;
	public Sprite releasedSprite;

	private AudioSource audioSourceComp = null;
	private bool canPress = true;
	private FPH_NumPad_Interactor numPadInteractComp;
	private Animation animationComp;

	
	// Use this for initialization
	void Start () {
		canPress = true;

		numPadInteractComp = numPadInteractObj.GetComponent<FPH_NumPad_Interactor>();
		animationComp = numPadInteractObj.GetComponent<Animation>();

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
		if(buttonType == 3){
			buttonSprite.sprite = pressedSprite;
		}
	}
	
	void HandleButtonUp(){
		if(canPress && buttonType != 3){
			canPress = false;
			animationComp.CrossFade(aniToPlay);
			if(pressNumButtonSound != null){
				audioSourceComp.PlayOneShot(pressNumButtonSound);
			}

			StartCoroutine("WaitForAni", 0.5f);
		}
		else if(buttonType == 3){
			buttonSprite.sprite = releasedSprite;
			
			numPadInteractComp.ExitNumpad();
		}
	}

	IEnumerator WaitForAni(float waitFor){
		yield return new WaitForSeconds(waitFor);

		if(buttonType == 0){
			if(numPadTextMesh.text.Length < maxLenghtCode){
				numPadTextMesh.text += buttonValueArray[buttonValue];

				yield return new WaitForSeconds(0.1f);

				canPress = true;
			}
		}
		else if(buttonType == 1){
			if(numPadTextMesh.text.Length > 0){
				numPadTextMesh.text = numPadTextMesh.text.Remove(numPadTextMesh.text.Length - 1);
			}
			
			yield return new WaitForSeconds(0.1f);
			
			canPress = true;
		}
		else if(buttonType == 2){
			if(numPadTextMesh.text == numPadInteractComp.codeToCheck){
				if(rightCodeSound != null){
					audioSourceComp.PlayOneShot(rightCodeSound);
					
					yield return new WaitForSeconds(wrongCodeSound.length);
				}

				canPress = true;
				numPadInteractComp.DoneCode();
			}
			if(numPadTextMesh.text != numPadInteractComp.codeToCheck){	
				if(wrongCodeSound != null){
					audioSourceComp.PlayOneShot(wrongCodeSound);
				
					yield return new WaitForSeconds(wrongCodeSound.length);
				}

				canPress = true;
				numPadTextMesh.text = "";
			}
		}
	}
}
