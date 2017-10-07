using UnityEngine;
using System.Collections;

public class FPH_RotPuzzle_ControlTrigger : MonoBehaviour {

	public FPH_RotPuzzle_Interactor puzzleInteractor;


	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){
	
	}

	void OnTriggerStay(Collider col){
		if(!puzzleInteractor.ingameCamera.activeSelf && puzzleInteractor.rotPuzzleCamera.activeSelf){
			if(!Input.GetMouseButton(0)){
				if(col.gameObject.name == "RotDisk01_Pos01_Collider"){
					puzzleInteractor.disk01Pos = 1;
				}
				if(col.gameObject.name == "RotDisk01_Pos02_Collider"){
					puzzleInteractor.disk01Pos = 2;
				}
				if(col.gameObject.name == "RotDisk01_Pos03_Collider"){
					puzzleInteractor.disk01Pos = 3;
				}
				if(col.gameObject.name == "RotDisk01_Pos04_Collider"){
					puzzleInteractor.disk01Pos = 4;
				}
				if(col.gameObject.name == "RotDisk01_Pos05_Collider"){
					puzzleInteractor.disk01Pos = 5;
				}
				
				if(col.gameObject.name == "RotDisk02_Pos01_Collider"){
					puzzleInteractor.disk02Pos = 1;
				}
				if(col.gameObject.name == "RotDisk02_Pos02_Collider"){
					puzzleInteractor.disk02Pos = 2;
				}
				if(col.gameObject.name == "RotDisk02_Pos03_Collider"){
					puzzleInteractor.disk02Pos = 3;
				}
				if(col.gameObject.name == "RotDisk02_Pos04_Collider"){
					puzzleInteractor.disk02Pos = 4;
				}
				if(col.gameObject.name == "RotDisk02_Pos05_Collider"){
					puzzleInteractor.disk02Pos = 5;
				}
				
				if(col.gameObject.name == "RotDisk03_Pos01_Collider"){
					puzzleInteractor.disk03Pos = 1;
				}
				if(col.gameObject.name == "RotDisk03_Pos02_Collider"){
					puzzleInteractor.disk03Pos = 2;
				}
				if(col.gameObject.name == "RotDisk03_Pos03_Collider"){
					puzzleInteractor.disk03Pos = 3;
				}
				if(col.gameObject.name == "RotDisk03_Pos04_Collider"){
					puzzleInteractor.disk03Pos = 4;
				}
				if(col.gameObject.name == "RotDisk03_Pos05_Collider"){
					puzzleInteractor.disk03Pos = 5;
				}
				
				if(col.gameObject.name == "RotDisk04_Pos01_Collider"){
					puzzleInteractor.disk04Pos = 1;
				}
				if(col.gameObject.name == "RotDisk04_Pos02_Collider"){
					puzzleInteractor.disk04Pos = 2;
				}
				if(col.gameObject.name == "RotDisk04_Pos03_Collider"){
					puzzleInteractor.disk04Pos = 3;
				}
				if(col.gameObject.name == "RotDisk04_Pos04_Collider"){
					puzzleInteractor.disk04Pos = 4;
				}
				if(col.gameObject.name == "RotDisk04_Pos05_Collider"){
					puzzleInteractor.disk04Pos = 5;
				}
			}
		}
	}
}