using UnityEngine;
using System.Collections;

/*
 * This script simply change the level after N seconds, 
 * useful for splash screens.
 */
[RequireComponent (typeof (FPH_FadeCamera))]
public class FPH_SplashScreen : MonoBehaviour {

	public string levelToLoad;
	public float startChangeLevelAfter;

	private bool calledChange;


	// Use this for initialization
	void Start(){
		calledChange = false;
		StartCoroutine("ChangeLevelWithDelay", startChangeLevelAfter);
	}
	
	// Update is called once per frame
	void Update(){
		if(calledChange && gameObject.GetComponent<FPH_FadeCamera>().alpha >= 1.0f){
			Application.LoadLevel(levelToLoad);
		}
	}

	IEnumerator ChangeLevelWithDelay(float delay){
		yield return new WaitForSeconds(delay);

		gameObject.GetComponent<FPH_FadeCamera>().FadeOut();
		calledChange = true;
	}
}
