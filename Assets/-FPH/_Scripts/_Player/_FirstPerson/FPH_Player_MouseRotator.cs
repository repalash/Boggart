using UnityEngine;
using System.Collections;

public class FPH_Player_MouseRotator : MonoBehaviour {

	public enum RotationAxes {MouseX, MouseY}
	public RotationAxes axes = RotationAxes.MouseX;

	public float dampingTime = 0.2f;
	public float sensitivity = 3.0f;
	public Vector2 minMaxY = new Vector2(-60.0f, 60.0f);

	private float roty = 0F;
	private Vector3 smoothSpeed;
	private Vector3 smoothedAngle;
	private Transform transComp;


	void Start(){
		if(gameObject.GetComponent<Transform>()){
			transComp = gameObject.GetComponent<Transform>();
		}
		if(gameObject.GetComponent<Rigidbody>()){
			gameObject.GetComponent<Rigidbody>().freezeRotation = true;
		}
	}

	void Update(){
		if(FPH_ControlManager.canBeControlled){
			if(axes == RotationAxes.MouseX){
				smoothedAngle = Vector3.SmoothDamp(smoothedAngle, new Vector3(0, Input.GetAxis("Mouse X") * sensitivity, 0), ref smoothSpeed, dampingTime);
				transComp.Rotate(smoothedAngle);
			}
			if(axes == RotationAxes.MouseY){
				roty += Input.GetAxis("Mouse Y") * sensitivity;
				roty = Mathf.Clamp (roty, minMaxY.x, minMaxY.y);
				
				smoothedAngle = Vector3.SmoothDamp(smoothedAngle, new Vector3(-roty, transComp.localEulerAngles.y, 0), ref smoothSpeed, dampingTime);
				transComp.localEulerAngles = new Vector3(smoothedAngle.x, smoothedAngle.y, 0);
			}
		}
	}
}