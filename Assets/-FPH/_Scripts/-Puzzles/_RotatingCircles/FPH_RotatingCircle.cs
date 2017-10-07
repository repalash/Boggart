using UnityEngine;
using System.Collections;

public class FPH_RotatingCircle : MonoBehaviour {

	Vector3 mouse_pos;
	Vector3 object_pos;
	float angle;
	
	
	// Use this for initialization
	void Start(){

	}
	
	// Update is called once per frame
	void Update(){

	}
	
	void OnMouseDrag(){
		Vector3 mouse = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		transform.localRotation = Quaternion.Euler(-angle, 90.0f, 0.0f);
		// Debug.Log(transform.eulerAngles.x);
	}
}
