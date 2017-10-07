using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPH_BatteryManager : MonoBehaviour {

	/*
	 * This script store the current battery value, deactivate the light if
	 * thre's no charge and can also switch on/off the flashlight pressing
	 * a button defined in " FPH_ControlManager "
	 */

	public GameObject batteryUI;
	public Text batteryLifeTextMesh;
	public float drainLifeEvery = 2.0f; // Drain battery life on " 1 " every " n " seconds
	public GameObject flashlight_LightObj;

	public bool animateHand = true;
	public Animation handObj;
	public string showHand_Ani = "Up";
	public string hideHand_Ani = "Down";
	public string idleHand_Ani = "Idle";
	public string switchLight_Ani = "SwitchLight";

	public Image batterySprite;
	public Sprite sprite_Empty;
	public Sprite sprite_One;
	public Sprite sprite_Two;
	public Sprite sprite_Three;
	public Sprite sprite_Four;

	public bool storeBatteries;
	public GameObject batteriesInventoryIcon;
	public Text batteriesInventoryIcon_Lablel;

	public static int batteryLife = 100;
	public static bool isLightOn;
	public static int batteriesNum;

	private float batteryTimer;
	private bool canSwitch;


	// Use this for initialization
	void Start(){
		isLightOn = true;
		canSwitch = true;
		if(storeBatteries){
			if(PlayerPrefs.HasKey("keyBatteriesNum")){
				batteriesInventoryIcon.SetActive(true);
				batteriesNum = PlayerPrefs.GetInt("keyBatteriesNum");
			}
			else{
				batteriesNum = 0;
			}
		}
		else{
			batteriesInventoryIcon.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update(){
		batteryUI.SetActive(FPH_ControlManager.canBeControlled);

		if(batteryLife > 100){ // batteryLife CAN'T be bigger than 100 so be sure to avoid any problem related to a bigger batteryLife
			batteryLife = 100;
		}
		if(isLightOn){ // Battery life is drained only if the light is currently on, no reason to drain it if we switched on the light
			if(FPH_ControlManager.canBeControlled && batteryLife > 0){ // No battery drain if batteryLife is <= 0 and if we're not controlling the player
				batteryTimer += Time.deltaTime;
				
				if(batteryTimer >= drainLifeEvery){ // As soon as the timer reach the desired value we drain the battery of " 1 " then set the timer to 0 and it can start to count again
					batteryTimer = 0.0f;
					DrainBatteryLife();
				}
			}
			
			if(batteryLife > 80){
				batterySprite.sprite = sprite_Four;
			}
			else if(batteryLife > 60 && batteryLife <= 80){
				batterySprite.sprite = sprite_Three;
			}
			else if(batteryLife > 40 && batteryLife <= 60){
				batterySprite.sprite = sprite_Two;
			}
			else if(batteryLife > 20 && batteryLife <= 40){
				batterySprite.sprite = sprite_One;
			}
			else if(batteryLife <= 20){
				batterySprite.sprite = sprite_Empty;
			}
		}
		if(FPH_ControlManager.canBeControlled){
			if(batteryLife > 0){ // If batteryLife is bigger than 0 we can switch on/off the flashlight to save some batteryLife
				if(Input.GetKeyUp(FPH_ControlManager.static_switchFlashlight) && canSwitch){
					canSwitch = false;
					StartCoroutine("SwitchLightAni");
				}
			}
			if(batteryLife <= 0){ // Swithc off flashlight if battery life is <= 0
				flashlight_LightObj.SetActive(false);
			}

			
			if(storeBatteries){
				batteriesInventoryIcon_Lablel.text = batteriesNum.ToString();
				
				if(Input.GetKeyUp(FPH_ControlManager.static_useBatteries)){
					if(batteriesNum == 0){
						StartCoroutine("NoBatteriesMessage");
					}
					if(batteriesNum > 0){
						batteryLife += 21;
						batteriesNum--;
						PlayerPrefs.SetInt("keyBatteriesNum", batteriesNum);
						batteryLifeTextMesh.text = batteryLife.ToString() + "%";
					}
				}

			}
		}
	}

	/*
	 * Drain battery life and print the value on UI (Sprite)
	 */
	void DrainBatteryLife(){
		batteryLife--;
		batteryLifeTextMesh.text = batteryLife.ToString() + "%";
	}


	IEnumerator SwitchLightAni(){
		if(!isLightOn){
			if(animateHand){
				handObj.CrossFade(showHand_Ani);
				
				yield return new WaitForSeconds(handObj[showHand_Ani].length); // 0.625f
			}
			
			if(animateHand){
				handObj.CrossFade(switchLight_Ani);
				
				yield return new WaitForSeconds(handObj[switchLight_Ani].length); // 0.542f
			}
			
			flashlight_LightObj.SetActive(true);

			if(animateHand){
				handObj.CrossFade(idleHand_Ani);
			}

			isLightOn =  !isLightOn;
			canSwitch = true;
		}
		else if(isLightOn){
			if(animateHand){
				handObj.CrossFade(switchLight_Ani);
				
				yield return new WaitForSeconds(handObj[switchLight_Ani].length); // 0.542f
			}
			
			flashlight_LightObj.SetActive(false);
			
			yield return new WaitForSeconds(0.1f);
			
			if(animateHand){
				handObj.CrossFade(hideHand_Ani);
				
				yield return new WaitForSeconds(handObj[hideHand_Ani].length); // 0.792f
			}
			
			isLightOn =  !isLightOn;
			canSwitch = true;
		}
	}

	IEnumerator NoBatteriesMessage(){
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_LanguageManager.static_observeTextMesh.text = "I've got no batteries.";
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = "Non ho nessuna bateria.";
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = "No tengo bateria.";
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = "Ich habe keine Batterien bekam.";
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = "Je ne bateria.";
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = "";
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = "";
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = "";
		}
		
		yield return new WaitForSeconds(2.5f);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
	}
}