using UnityEngine;
using System.Collections;

public class FPH_DoorDrag_DirTrigger : MonoBehaviour {

	public enum dirEnum {In, Out}
	public dirEnum openCloseDir = dirEnum.In;
	public FPH_DoorObject_Drag doorObj;


	// Use this for initialization
	void Start(){

	}
	
	// Update is called once per frame
	void Update(){
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(openCloseDir == dirEnum.In){
				doorObj.openDirection = 1.0f;
			}
			if(openCloseDir == dirEnum.Out){
				doorObj.openDirection = -1.0f;
			}
		}
	}
	
	void OnTriggerStay(Collider col){
		if(col.gameObject.tag == "Player"){
			if(openCloseDir == dirEnum.In){
				doorObj.openDirection = 1.0f;
			}
			if(openCloseDir == dirEnum.Out){
				doorObj.openDirection = -1.0f;
			}
		}
	}
}