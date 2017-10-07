using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class FPH_2DJumpsScare : MonoBehaviour {
	
	public Sprite jumpScareSprite;
	public Sprite nullSprite;
	public Vector2 spritePosition;
	public Vector2 spriteScale = new Vector3(1.0f, 1.0f);
	public Color spriteColor = Color.white;
	public AudioClip jumpScareAudio;
	public bool deactivateColliderAfterCollision;
	public float showFor;
	public bool saveDeleteState;
	public string deleteStateKey;
	
	private GameObject jumpScareObj;
	private Image jumpScareSpriteRenderer;


	// Use this for initialization
	void Start () {
		if(FPH_ControlManager.LoadBool(deleteStateKey)){
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(deactivateColliderAfterCollision){
				gameObject.GetComponent<Collider>().enabled = false;
			}

			jumpScareObj = GameObject.Find("JumpScareUI");
			jumpScareSpriteRenderer = jumpScareObj.GetComponent<Image>();
			jumpScareObj.GetComponent<Transform>().localPosition = new Vector3(spritePosition.x, spritePosition.y, 0.3f);
			jumpScareObj.GetComponent<Transform>().localScale = new Vector3(spriteScale.x, spriteScale.y, 1.0f);
			jumpScareSpriteRenderer.sprite = jumpScareSprite;
			jumpScareSpriteRenderer.color = spriteColor;
			
			if(jumpScareAudio != null){
				gameObject.GetComponent<AudioSource>().PlayOneShot(jumpScareAudio);
			}
			if(saveDeleteState){
				FPH_ControlManager.SaveBool(deleteStateKey, true);
			}

			StartCoroutine("HideSprite");
		}
	}

	IEnumerator HideSprite(){
		yield return new WaitForSeconds(showFor);

		jumpScareSpriteRenderer.sprite = nullSprite;
	}
}