using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPH_InventorySprite_ItemButton : MonoBehaviour {

	public int neededInt;
	public Sprite nullSprite;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		// Here we display the item sprite in case item sprite array is bigger than needed int
		if(FPH_InventoryManager.inventoryName.Count > neededInt){
			Texture2D spriteText = (Texture2D) Resources.Load("ItemTexture/" + FPH_InventoryManager.inventoryTexture[neededInt]) as Texture2D;
			Sprite textSprite = Sprite.Create(spriteText, new Rect(0, 0, 128.0f, 128.0f), new Vector2(0.5f, 0.5f), 100);
			gameObject.GetComponent<Image>().sprite = textSprite;
		}
		else{
			gameObject.GetComponent<Image>().sprite = nullSprite;
		}
	}
	
	public void OnCustomMouseUp(){
		HandleButtonUp();
	}
	public void OnTouchUp(){
		HandleButtonUp();
	}
	
	// To select an item you only have to set the selected index var
	public void HandleButtonUp(){
		if(FPH_InventoryManager.inventoryName.Count >= neededInt){
			FPH_InventoryManager.selectedIndex = neededInt;
		}
	}
}