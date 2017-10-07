using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class FPH_ThirdPersonFootstepSounds : MonoBehaviour {
	public AudioClip[] footstepSounds;

	private bool isMoving;
	private float nextStepTime = 0.5f;
	private float footstepCycle = 0;
	private float headBobFrequency = 2.0f;//2.5f;
	private float bobStrideSpeedLengthen = 0.3f;
	private CharacterController playerController; 
	private AudioSource thisAudioComp;
	
	void Start(){
		playerController = gameObject.GetComponent<CharacterController>();
		thisAudioComp = gameObject.GetComponent<AudioSource>();
	}

	void FixedUpdate(){
		float inputX = Input.GetAxis("Horizontal"); //Keyboard input to determine if player is moving
		float inputY = Input.GetAxis("Vertical");
		
		if(inputX  != 0 || inputY != 0){
			isMoving = true;	
		}
		else if(inputX == 0 && inputY == 0){
			isMoving = false;	
		}

		float flatVelocity = new Vector3(playerController.velocity.x, 0, playerController.velocity.z).magnitude;
		float strideLengthen = 1 + (flatVelocity * bobStrideSpeedLengthen);
		footstepCycle += (flatVelocity / strideLengthen) * (Time.deltaTime / headBobFrequency);

		if(isMoving){
			if (footstepCycle > nextStepTime){
			nextStepTime = footstepCycle + 0.5f;

			int n = Random.Range(1, footstepSounds.Length);
			thisAudioComp.clip = footstepSounds[n];
			thisAudioComp.Play();

			footstepSounds[n] = footstepSounds[0];
			footstepSounds[0] = GetComponent<AudioSource>().clip;
			}
		}
	}
}