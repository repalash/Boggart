using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
public class FPH_BatteryInteract : MonoBehaviour {

	/*
	 * This script must be assigned to an object with " BatteryObject " tag
	 * it will increase the battery level of five different amount if the player
	 * actually interact with the battery.
	 * You can choose the increasing amount in the editor.
	 * You can also auto-config an object to eb a battery using the FPH Menu.
	 */

	public enum IncreaseEnum {One, Two, Three, Four, Full}
	public IncreaseEnum increaseOf = IncreaseEnum.One;

	/* If you want to Destroy this battery when the game start
	 * (if the player previously picked up it) set " saveState " to true.
	 * Also remember that " personalBatteryKey " CAN'T be the same value
	 * on two different batteries. If you set the same key on two different
	 * batteries these will be both destroyed in game start.
	 */
	public bool saveState;
	public string personalBatteryKey;
	public AudioClip soundWhenInteract;
	
	// If you want to store this battery instead of using it
	public bool storeThisBattery;
	
	private AudioSource audioSourceComp = null;
	
	
	// Use this for initialization
	void Start(){
		if(gameObject.GetComponent<AudioSource>()){
			audioSourceComp = gameObject.GetComponent<AudioSource>();
		}
		
		int destroyed = PlayerPrefs.GetInt(personalBatteryKey); // You can use PlayerPrefsX and bool value if you prefere
		if(destroyed == 1){
			this.gameObject.SetActive(false);
		}
	}

	public void ObtainObj(){
		if(soundWhenInteract){
			audioSourceComp.PlayOneShot(soundWhenInteract);
		}

		if(!storeThisBattery){
			if(increaseOf == IncreaseEnum.One){
				FPH_BatteryManager.batteryLife += 21;
			}
			if(increaseOf == IncreaseEnum.Two){
				FPH_BatteryManager.batteryLife += 41;
			}
			if(increaseOf == IncreaseEnum.Three){
				FPH_BatteryManager.batteryLife += 61;
			}
			if(increaseOf == IncreaseEnum.Four){
				FPH_BatteryManager.batteryLife += 81;
			}
			if(increaseOf == IncreaseEnum.Full){
				FPH_BatteryManager.batteryLife = 100;
			}

			if(saveState){
				PlayerPrefs.SetInt(personalBatteryKey, 1);
			}
			this.gameObject.SetActive(false);
		}
		if(storeThisBattery){
			FPH_BatteryManager.batteriesNum++;
			PlayerPrefs.SetInt("keyBatteriesNum", FPH_BatteryManager.batteriesNum);
			
			if(saveState){
				PlayerPrefs.SetInt(personalBatteryKey, 1);
			}
			this.gameObject.SetActive(false);
		}
	}
}