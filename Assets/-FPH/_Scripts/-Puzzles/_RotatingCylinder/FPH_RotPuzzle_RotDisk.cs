using UnityEngine;
using System.Collections;

public class FPH_RotPuzzle_RotDisk : MonoBehaviour {

	public float sensitivity = 5.0f;
	public enum RotAxisEnum {X, Y, Z}
	public RotAxisEnum rotAxis = RotAxisEnum.X;


	void OnMouseDrag() {
		if(rotAxis == RotAxisEnum.X){
			transform.Rotate(new Vector3(sensitivity * -Input.GetAxis("Mouse Y"), 0.0f, 0.0f), Space.Self); //Rotate letter cylinder 
		}
		if(rotAxis == RotAxisEnum.Y){
			transform.Rotate(new Vector3(0.0f, sensitivity * -Input.GetAxis("Mouse Y"), 0.0f), Space.Self); //Rotate letter cylinder
		}
		if(rotAxis == RotAxisEnum.Z){
			transform.Rotate(new Vector3(0.0f, 0.0f, sensitivity * -Input.GetAxis("Mouse Y")), Space.Self); //Rotate letter cylinder
		}
	}
}
