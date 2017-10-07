using UnityEngine;
using System.Collections;

public class FPH_ObserveObject : MonoBehaviour {

	public string[] observeKind = new string[] {"Normal", "Closeup"};
	public int observeInt = 0;

	public GameObject inGameCamera;
	public GameObject closeupCamera;
	public GameObject interactingCollider;
	
	public float secToOserve = 2.3f;

	public string observMessage_English;
	public string observMessage_Italian;
	public string observMessage_Spanish;
	public string observMessage_German;
	public string observMessage_French;
	public string observMessage_Japanese;
	public string observMessage_Chinese;
	public string observMessage_Russian;


	// Use this for initialization
	void Start(){

	}
	
	// Update is called once per frame
	void Update(){

	}
	
	public void Observe(){
		if(observeInt == 0){
			StartCoroutine("PrivateObserve_Normal");
		}
		if(observeInt == 1){
			StartCoroutine("PrivateObserve_Closeup");
		}
	}
	
	IEnumerator PrivateObserve_Normal(){
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_English;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Italian;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Spanish;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_German;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_French;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Japanese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Chinese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Russian;
		}
		
		yield return new WaitForSeconds(secToOserve);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
	}
	
	IEnumerator PrivateObserve_Closeup(){
		inGameCamera.SetActive(false);
		closeupCamera.SetActive(true);
		interactingCollider.GetComponent<Collider>().enabled = false;
		FPH_ControlManager.canBeControlled = false;

		yield return new WaitForSeconds(0.1f);
		
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_English;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Italian;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Spanish;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_German;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_French;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Japanese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Chinese;
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			FPH_LanguageManager.static_observeTextMesh.text = observMessage_Russian;
		}
		
		yield return new WaitForSeconds(secToOserve);
		
		FPH_LanguageManager.static_observeTextMesh.text = "";
		
		yield return new WaitForSeconds(0.3f);

		inGameCamera.SetActive(true);
		FPH_ControlManager.canBeControlled = true;
		interactingCollider.GetComponent<Collider>().enabled = true;
		closeupCamera.SetActive(false);
	}
}