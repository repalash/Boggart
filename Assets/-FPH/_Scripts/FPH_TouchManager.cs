using UnityEngine;
using System.Collections;

public class FPH_TouchManager : MonoBehaviour {

	public Camera cameraObj;
	public float minSwipeMovement = 20.0f;
	public bool sendTouchSwipeMessage;
	public bool sendMouseSwipeMessage;
	public LayerMask rayLayerMask = -2049;
	
	private Vector2 touchSwipe_startPos;
	private int SwipeID = -1;
	private Vector3 startPos;
	private bool swiping = false;
	private Vector3 directionV;
	private float angle;

	public static GameObject swipeDetectObj;
	public static Camera staticCameraObj;


	// Use this for initialization
	void Start(){
		staticCameraObj = cameraObj;
	}
	
	// Update is called once per frame
	void Update(){
		TapDetect();
		MouseDetect();
		MouseSwipeDetect();
	}
	
	void TapDetect(){
		foreach(Touch touch in Input.touches){
			Vector2 touchPos = touch.position;
			if(touch.phase == TouchPhase.Began){
				Ray ray = cameraObj.ScreenPointToRay(touch.position);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit, Mathf.Infinity, rayLayerMask)){
					hit.transform.gameObject.SendMessage("OnTouchDown", SendMessageOptions.DontRequireReceiver);
				}
				//swipe control script
				if(SwipeID == -1){
					SwipeID = touch.fingerId;
					touchSwipe_startPos = touchPos;
				}
			}

			if(touch.phase == TouchPhase.Moved){
				Ray ray = cameraObj.ScreenPointToRay(touch.position);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit, Mathf.Infinity, rayLayerMask)){
					hit.transform.gameObject.SendMessage("OnTouchDrag", new Vector2(touch.position.x, touch.position.y), SendMessageOptions.DontRequireReceiver);
				}
			}
			
			if(touch.phase == TouchPhase.Ended){
				Ray ray = cameraObj.ScreenPointToRay(touch.position);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit, Mathf.Infinity, rayLayerMask)){
					hit.transform.gameObject.SendMessage("OnTouchUp", SendMessageOptions.DontRequireReceiver);
				}
			}
			
			//Swipe Handler
			if(touch.fingerId == SwipeID && sendTouchSwipeMessage && swipeDetectObj != null){
				var delta = touchPos - touchSwipe_startPos;
				if(touch.phase == TouchPhase.Moved && delta.magnitude > minSwipeMovement){
					SwipeID = -1;
					if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y)){
						if(delta.x > 0){
							swipeDetectObj.SendMessage("OnTouchSwipeRight", SendMessageOptions.DontRequireReceiver);
						}
						else if(delta.x < 0){
							swipeDetectObj.SendMessage("OnTouchSwipeLeft", SendMessageOptions.DontRequireReceiver);
						}
					}
					else{
						if(delta.y > 0){
							swipeDetectObj.SendMessage("OnTouchSwipeUp", SendMessageOptions.DontRequireReceiver);
						}
						else if(delta.y < 0){
							swipeDetectObj.SendMessage("OnTouchSwipeDown", SendMessageOptions.DontRequireReceiver);
						}
					}
				}
				
				else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended){
					SwipeID = -1;
				}
			}
		}
	}

	void MouseDetect(){
		if(Input.GetMouseButtonDown(0)){
			Ray ray = cameraObj.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast (ray, out hit, Mathf.Infinity, rayLayerMask)){
				hit.transform.gameObject.SendMessage("OnCustomMouseDown", SendMessageOptions.DontRequireReceiver);
			}
		}

		if(Input.GetMouseButtonUp(0)){
			Ray ray = cameraObj.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, Mathf.Infinity, rayLayerMask)){
				hit.transform.gameObject.SendMessage("OnCustomMouseUp", SendMessageOptions.DontRequireReceiver);
			}
		}

		if(Input.GetMouseButton(0)){
			Ray ray = cameraObj.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast (ray, out hit, Mathf.Infinity, rayLayerMask)){
				hit.transform.gameObject.SendMessage("OnCustomMouseDrag", Input.mousePosition, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void MouseSwipeDetect(){
		if(sendMouseSwipeMessage){
			if(Input.GetMouseButtonDown(0)){
				startPos = Input.mousePosition;
			}
			
			if(Input.GetMouseButton(0)){
				if(!swiping){
					Vector3 curPos = Input.mousePosition;
						
					if(Vector3.Distance(curPos, startPos) > 10){
						swiping = true;
					}
				}
			}
		
			if(swiping && Input.GetMouseButtonUp(0)){
				Vector3 curPos = Input.mousePosition;
				swiping = false;
					
				directionV = curPos-startPos;
				angle = VectorToAngle(new Vector2(directionV.x, directionV.y));
				
				if(angle > 45 && angle <= 135){
					if(swipeDetectObj != null){
						swipeDetectObj.SendMessage("OnMouseSwipeUp",  SendMessageOptions.DontRequireReceiver);
					}
					Debug.Log("Up");
				}
				else if(angle > 135 && angle <= 225){
					if(swipeDetectObj != null){
						swipeDetectObj.SendMessage("OnMouseSwipeLeft",  SendMessageOptions.DontRequireReceiver);
					}
					Debug.Log("Left");
				}
				else if(angle > 225 && angle <= 315){
					if(swipeDetectObj != null){
						swipeDetectObj.SendMessage("OnMouseSwipeDown",  SendMessageOptions.DontRequireReceiver);
					}
					Debug.Log("Down");
				}
				else{
					if(swipeDetectObj != null){
						swipeDetectObj.SendMessage("OnMouseSwipeRight",  SendMessageOptions.DontRequireReceiver);
					}
					Debug.Log("Right");
				}
			}
		}
	}

	float VectorToAngle(Vector2 dir){	
		if(dir.x == 0){
			if(dir.y > 0){
				return 90;
			}
			else if(dir.y < 0){
				return 270;
			}
			else{
				return 0;
			}
		}
		else if(dir.y == 0){
			if(dir.x > 0){
				return 0;
			}
			else if(dir.x < 0){
				return 180;
			}
			else{
				return 0;
			}
		}
		
		
		float h = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
		float angle = Mathf.Asin(dir.y/h) * Mathf.Rad2Deg;
		
		
		if(dir.y > 0){
			if(dir.x < 0){
				angle = 180 - angle;
			}
		}
		else{
			if(dir.x > 0){
				angle = 360 + angle;
			}
			if(dir.x < 0){
				angle = 180 - angle;
			}
		}
		
		return angle;
	}
}