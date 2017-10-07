using UnityEngine;
using System.Collections;

public class FPH_ThirdPersonCameraTrigger : MonoBehaviour {

	public GameObject toActive;
	public GameObject[] camerasToDeActive;
	public bool changeFootsteps;
	public AudioClip[] newFootstepSounds;

	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player" && !FPH_DialogManager.isEnabled){
			toActive.SetActive(true);
			if(changeFootsteps){
				GameObject.FindGameObjectWithTag("Player").GetComponent<FPH_ThirdPersonFootstepSounds>().footstepSounds = newFootstepSounds;
			}
			for(int i = 0; i < camerasToDeActive.Length; i++){
				camerasToDeActive[i].SetActive(false);
			}
		}
	}
	
	void OnTriggerStay(Collider col){
		if(!toActive.activeSelf){
			if(col.gameObject.tag == "Player" && !FPH_DialogManager.isEnabled){
				toActive.SetActive(true);
				if(changeFootsteps){
					GameObject.FindGameObjectWithTag("Player").GetComponent<FPH_ThirdPersonFootstepSounds>().footstepSounds = newFootstepSounds;
				}
				for(int i = 0; i < camerasToDeActive.Length; i++){
					camerasToDeActive[i].SetActive(false);
				}
			}
		}
	}

}
