using UnityEngine;
using System.Collections;

public class FPH_LightSwitch : MonoBehaviour {

	public string[] interactionKind = new string[] {"Switch Light", "Toggle Light", "SendMessage"};
	public int interactionInt = 0;

	public Animation objToAnimate;
	public string switchAnim;

	public GameObject[] lightsToSwitch;
	public float switchLightAfter;
	public string[] switchKind = new string[] {"On", "Off"};
	public int switchInt = 0;

	public bool sendMessOnEnd;

	public float sendMessageAfter;
	public string messageToSend;
	public GameObject sendMessageTo;

	public bool saveState;
	public string keyToSave;


	// Use this for initialization
	void Start(){
		if(interactionInt == 0){ // SwitchLight
			if(FPH_ControlManager.LoadBool(keyToSave)){
				for(int i = 0; i < lightsToSwitch.Length; i++){
					lightsToSwitch[i].SetActive(true);
				}

				this.GetComponent<Collider>().enabled = false;
			}
		}
		if(interactionInt == 2){ // Send Message
			if(FPH_ControlManager.LoadBool(keyToSave)){
				this.GetComponent<Collider>().enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update(){
	
	}

	public void Interact(){
		if(interactionInt == 0){ // SwitchLight
			StartCoroutine("SwitchLight");
		}
		if(interactionInt == 1){ // ToggleLight
			StartCoroutine("ToggleLight");
		}
		if(interactionInt == 2){ // Send Message
			StartCoroutine("SendMess");
		}
	}
	
	IEnumerator SwitchLight(){
		objToAnimate.CrossFade(switchAnim);
		
		yield return new WaitForSeconds(switchLightAfter);

		if(switchInt == 0){ // On
			for(int i = 0; i < lightsToSwitch.Length; i++){
				lightsToSwitch[i].SetActive(true);
			}
		}
		if(switchInt == 1){ // Off
			for(int i = 0; i < lightsToSwitch.Length; i++){
				lightsToSwitch[i].SetActive(false);
			}
		}
		
		if(sendMessOnEnd){
			yield return new WaitForSeconds(sendMessageAfter);
			
			sendMessageTo.SendMessage(messageToSend);
		}
		
		FPH_ControlManager.SaveBool(keyToSave, true);
	}
	
	IEnumerator ToggleLight(){
		objToAnimate.CrossFade(switchAnim);
		
		yield return new WaitForSeconds(switchLightAfter);

		if(lightsToSwitch[0].activeSelf){
			for(int i = 0; i < lightsToSwitch.Length; i++){
				lightsToSwitch[i].SetActive(false);
			}

			yield break;
		}

		if(!lightsToSwitch[0].activeSelf){
			for(int i = 0; i < lightsToSwitch.Length; i++){
				lightsToSwitch[i].SetActive(true);
			}

			yield break;
		}
	}
	
	IEnumerator SendMess(){
		objToAnimate.CrossFade(switchAnim);
		
		yield return new WaitForSeconds(switchLightAfter + sendMessageAfter);
		
		sendMessageTo.SendMessage(messageToSend);

		FPH_ControlManager.SaveBool(keyToSave, true);
	}

	
	public void SetSwitchAfter(){
		switchLightAfter = objToAnimate[switchAnim].clip.length;
	}
}