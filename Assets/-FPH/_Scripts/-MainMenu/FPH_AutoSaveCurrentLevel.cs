using UnityEngine;
using System.Collections;

public class FPH_AutoSaveCurrentLevel : MonoBehaviour {

	public bool savePlayerPosOnQuit;
	public GameObject playerObj;
	public string currentLevelName;

	// Use this for initialization
	void Awake(){
		if(PlayerPrefs.HasKey("keyOldPlayerPos_X") && PlayerPrefs.HasKey("keyOldPlayerPos_Y") && PlayerPrefs.HasKey("keyOldPlayerPos_Z")){
			float oldPos_x = PlayerPrefs.GetFloat("keyOldPlayerPos_X");
			float oldPos_y = PlayerPrefs.GetFloat("keyOldPlayerPos_Y");
			float oldPos_z = PlayerPrefs.GetFloat("keyOldPlayerPos_Z");
			playerObj.transform.localPosition = new Vector3(oldPos_x, oldPos_y, oldPos_z);
		}
	}

	void Start(){
		PlayerPrefs.SetString("keyOldLevelToLoad", currentLevelName);
	}
	
	// Update is called once per frame
	void Update(){
	
	}

	void OnApplicationQuit(){
		if(savePlayerPosOnQuit){
			Vector3 playerPos = playerObj.GetComponent<Transform>().localPosition;
			Vector3 posToSave = new Vector3(playerPos.x, playerPos.y + 0.11f, playerPos.z);
			PlayerPrefs.SetFloat("keyOldPlayerPos_X", posToSave.x);
			PlayerPrefs.SetFloat("keyOldPlayerPos_Y", posToSave.y);
			PlayerPrefs.SetFloat("keyOldPlayerPos_Z", posToSave.z);
		}
	}
}