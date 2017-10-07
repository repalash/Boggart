using UnityEngine;
using System.Collections;

public class FPH_PlayerController : MonoBehaviour{

	public string[] playerTypeArray = new string[] {"First Person", "Third Person"};
	public int playerType;

	#region FirstPerson
	public bool runByDefault = false; //controls how the walk/run modifier key behaves.
	public float runSpeed = 8f; //The speed at which we want the character to move
	public float walkSpeed = 3f; //The speed at which we want the character to move
	public float gravityMultiplier = 1f; //Changes the way gravity effect the player ( realistic gravity can look bad for jumping in game )
	public float groundStickyEffect = 5f; //power of 'stick to ground' effect - prevents bumping down slopes.
	public GameObject handObj;

	public bool grounded;
	public float speed;

	private const float jumpRayLength = 0.7f; //The length of the ray used for testing against the ground when jumping

	private CapsuleCollider capsule; //The capsule collider for the first person character
	private IComparer rayHitComparer;
	private Animation handAniComp;
	private bool canCallGoUp = true;
	#endregion


	#region ThirdPerson
	enum CharacterState{ Idle = 0, Walking = 1 }
	public GameObject camerasObj;
	public Animation charaObj;
	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public float walkMaxAnimationSpeed = 1.2f;
	public float thirdWalkSpeed = 3.0f; //The speed when walking
	public float gravity = 20.0f; //The gravity for the character
	public float speedSmoothing = 10.0f; //The gravity in controlled descent mode
	public float rotateSpeed = 500.0f;

	private CharacterState _characterState;
	private Vector3 moveDirection = Vector3.zero; //The current move direction in x-z
	private float verticalSpeed = 0.0f; //The current vertical speed
	private float moveSpeed = 0.0f; //The current x-z move speed
	private CollisionFlags collisionFlags; //The last collision flags returned from controller.Move
	private CharacterController controller;
	private Transform cameraTransform;
	private Vector3 forward;
	private Transform thisTrans;
	private Vector3 right;
	#endregion


	void Awake(){
		if(playerType == 0){
			//Set up a reference to the capsule collider.
			capsule = GetComponent<Collider>() as CapsuleCollider;
			grounded = true;
			rayHitComparer = new RayHitComparer();
			handAniComp = handObj.GetComponent<Animation>();
		}
		else if(playerType == 1){
			moveDirection = transform.TransformDirection(Vector3.forward);
			thisTrans = gameObject.GetComponent<Transform>();
		}
	}

	void Start(){
	}

	public void FixedUpdate(){
		if(playerType == 0){
			if(FPH_ControlManager.canBeControlled){
				speed = runSpeed;
				
				if(runByDefault){
					if(Input.GetKey(KeyCode.LeftShift)){
						speed = walkSpeed;
					}
					else{
						speed = runSpeed;
					}
				}
				else{
					if(Input.GetKey(KeyCode.LeftShift)){
						if(!canCallGoUp && FPH_BatteryManager.isLightOn){
							canCallGoUp = true;
							handAniComp.CrossFade("Down");
						}
						speed = runSpeed;
					}
					else{
						if(canCallGoUp && FPH_BatteryManager.isLightOn){
							canCallGoUp = false;
							handAniComp.CrossFade("Up");
							StartCoroutine("RestoreIdle");
						}
						speed = walkSpeed;
					}
				}

				Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				
				//Normalize input if it exceeds 1 in combined length:
				if(input.sqrMagnitude > 1){
					input.Normalize();
				}
				
				Vector3 desiredMove = transform.forward * input.y * speed + transform.right * input.x; //Get a vector which is desired move as a world-relative direction, including speeds
				float yv = GetComponent<Rigidbody>().velocity.y; //preserving current y velocity (for falling, gravity)
				GetComponent<Rigidbody>().velocity = desiredMove + Vector3.up * yv; //Set the rigidbody's velocity according to the ground angle and desired move
				
				#region	GroundCheck
				Ray ray = new Ray(transform.position, -transform.up); //Create a ray that points down from the centre of the character.
				//Raycast slightly further than the capsule (as determined by jumpRayLength)
				RaycastHit[] hits = Physics.RaycastAll(ray, capsule.height * jumpRayLength);
				System.Array.Sort(hits, rayHitComparer);
				
				if(grounded || GetComponent<Rigidbody>().velocity.y < 2.5f){
					grounded = false; //Default value if nothing is detected:
					for(int i = 0; i < hits.Length; i++){ //Check every collider hit by the ray
						if (!hits[i].collider.isTrigger){ //Check it's not a trigger
							//The character is grounded, and we store the ground angle (calculated from the normal)
							grounded = true;
							//Stick to surface - helps character stick to ground - specially when running down slopes
							GetComponent<Rigidbody>().position = Vector3.MoveTowards (GetComponent<Rigidbody>().position, hits[i].point + Vector3.up * capsule.height*0.5f, Time.deltaTime * groundStickyEffect);
							GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0.0f, GetComponent<Rigidbody>().velocity.z);
							break;
						}
					}
				}
				
				GetComponent<Rigidbody>().AddForce(Physics.gravity * (gravityMultiplier - 1)); //Add extra gravity
				Debug.DrawRay(ray.origin, ray.direction * capsule.height * jumpRayLength, grounded ? Color.green : Color.red);
				#endregion
			}
		}

		
		if(playerType == 1){
			if(FPH_ControlManager.canBeControlled){
				UpdateSmoothedMovementDirection();
				
				ApplyGravity();
				
				//Calculate actual motion
				Vector3 movement= moveDirection * moveSpeed + new Vector3 (0, verticalSpeed, 0);
				movement *= Time.deltaTime;
				
				//Move the controller
				controller = GetComponent<CharacterController>();
				collisionFlags = controller.Move(movement);
			}
			else{
				_characterState = CharacterState.Idle;
				charaObj.CrossFade(idleAnimation.name);
			}
			//ANIMATION sector
			if(charaObj){
				if(controller.velocity.sqrMagnitude < 0.1f){
					_characterState = CharacterState.Idle;
					charaObj.CrossFade(idleAnimation.name);
				}
				else{
					if(_characterState == CharacterState.Walking){
						charaObj[walkAnimation.name].speed = Mathf.Clamp(controller.velocity.magnitude, 0.0f, walkMaxAnimationSpeed);
						charaObj.CrossFade(walkAnimation.name);  
					}
				}
			}
			
			//Set rotation to the move direction
			if(IsGrounded()){
				thisTrans.rotation = Quaternion.LookRotation(moveDirection);	
			} 
		}
	}
	
	//Used for comparing distances
	class RayHitComparer: IComparer{
		public int Compare(object x, object y){
			return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
		}
	}

	IEnumerator RestoreIdle(){
		yield return new WaitForSeconds(0.625f);
		
		handAniComp.CrossFade("Idle");
	}

	
	
	void UpdateSmoothedMovementDirection(){
		if(playerType == 1){ // Third person
			bool grounded = IsGrounded(); 

			float v= Input.GetAxisRaw("Vertical"); // CrossPlatformInputManager.GetAxisRaw("Vertical")
			float h= Input.GetAxisRaw("Horizontal"); // CrossPlatformInputManager.GetAxisRaw("Horizontal")
		//	/*
			if(Input.GetAxisRaw("Horizontal") < 0.1f && Input.GetAxisRaw("Vertical") < 0.1f){ // CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0.1f && CrossPlatformInputManager.GetAxisRaw("Vertical") < 0.1f
				Transform cameraTransform = Camera.main.transform;
			
				forward= cameraTransform.TransformDirection(Vector3.forward); //Forward vector relative to the camera along the x-z plane 
				forward.y = 0;
				forward = forward.normalized;
				
				right= new Vector3(forward.z, 0, -forward.x); //Right vector relative to the camera - Always orthogonal to the forward vector
			}
		// */
			if(camerasObj.activeSelf){ //!DialogManager.isEnabled
				/*Transform*/ cameraTransform = Camera.main.transform;
				
				forward = cameraTransform.TransformDirection(Vector3.forward); //Forward vector relative to the camera along the x-z plane 
				forward.y = 0;
				forward = forward.normalized;
			}
			
			// Vector3 right= new Vector3(forward.z, 0, -forward.x); //Right vector relative to the camera - Always orthogonal to the forward vector
			
			Vector3 targetDirection= h * right + v * forward; //Target direction relative to the camera
			
			if(grounded){ //Grounded controls
				//We store speed and direction seperately,
				//so that when the character stands still we still have a valid forward direction
				//moveDirection is always normalized, and we only update it if there is user input.
				if(targetDirection != Vector3.zero){
					//If we are really slow, just snap to the target direction
					if(moveSpeed < thirdWalkSpeed * 0.9f && grounded){
						moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);
					}
					//Otherwise smoothly turn towards it
					else{
						moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);
						moveDirection = moveDirection.normalized;
					}
				}
				
				float curSmooth= speedSmoothing * Time.deltaTime; //Smooth the speed based on the current target direction
				
				float targetSpeed= Mathf.Min(targetDirection.magnitude, 1.0f); //Choose target speed - We want to support analog input but make sure you cant walk faster diagonally than just forward or sideways
				
				targetSpeed *= thirdWalkSpeed;
				_characterState = CharacterState.Walking;
				
				moveSpeed = Mathf.Lerp(moveSpeed, targetSpeed, curSmooth);
			}
		}
	}
	
	void ApplyGravity(){
		if(playerType == 1){
			//don't move player at all if not controllable.
			if(FPH_ControlManager.canBeControlled){
				if(IsGrounded()){
					verticalSpeed = 0.0f;
				}
				else{
					verticalSpeed -= gravity * Time.deltaTime;
				}
			}
		}
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit){
		if(playerType == 1){
			if(hit.moveDirection.y > 0.01f){
				return;
			}
		}
	}  
	
	bool IsGrounded(){
		if(playerType == 1){
			return (collisionFlags & CollisionFlags.CollidedBelow) != 0;
		}
		return false;
	}
}