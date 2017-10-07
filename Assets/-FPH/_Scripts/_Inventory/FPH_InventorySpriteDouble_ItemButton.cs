using UnityEngine;
using System.Collections;

public class FPH_InventorySpriteDouble_ItemButton : MonoBehaviour {
	
	public string obj01Name_English;
	public string obj01Name_Italian;
	public string obj01Name_Spanish;
	public string obj01Name_German;
	public string obj01Name_French;
	public string obj01Name_Japanese;
	public string obj01Name_Chinese;
	public string obj01Name_Russian;

	public string obj02Name_English;
	public string obj02Name_Italian;
	public string obj02Name_Spanish;
	public string obj02Name_German;
	public string obj02Name_French;
	public string obj02Name_Japanese;
	public string obj02Name_Chinese;
	public string obj02Name_Russian;


	private bool hasObject01;
	private bool hasObject02;
	private int privateObjIndex = -1;

	
	// Use this for initialization
	void Start(){
		privateObjIndex = -1;
	}
	
	// Update is called once per frame
	void Update(){
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
			hasObject01 = FPH_InventoryManager.HasObject(obj01Name_English);
			hasObject02 = FPH_InventoryManager.HasObject(obj02Name_English);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
			hasObject01 = FPH_InventoryManager.HasObject(obj01Name_Italian);
			hasObject02 = FPH_InventoryManager.HasObject(obj02Name_Italian);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
			hasObject01 = FPH_InventoryManager.HasObject(obj01Name_Spanish);
			hasObject02 = FPH_InventoryManager.HasObject(obj02Name_Spanish);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
			hasObject01 = FPH_InventoryManager.HasObject(obj01Name_German);
			hasObject02 = FPH_InventoryManager.HasObject(obj02Name_German);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
			hasObject01 = FPH_InventoryManager.HasObject(obj01Name_French);
			hasObject02 = FPH_InventoryManager.HasObject(obj02Name_French);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
			hasObject01 = FPH_InventoryManager.HasObject(obj01Name_Japanese);
			hasObject02 = FPH_InventoryManager.HasObject(obj02Name_Japanese);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
			hasObject01 = FPH_InventoryManager.HasObject(obj01Name_Chinese);
			hasObject02 = FPH_InventoryManager.HasObject(obj02Name_Chinese);
		}
		if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
			hasObject01 = FPH_InventoryManager.HasObject(obj01Name_Russian);
			hasObject02 = FPH_InventoryManager.HasObject(obj02Name_Russian);
		}
		
		if(hasObject01 && !hasObject02){
			int objIndex = -1;
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj01Name_English);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj01Name_Italian);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj01Name_Spanish);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj01Name_German);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj01Name_French);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj01Name_Japanese);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj01Name_Chinese);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj01Name_Russian);
			}

			if(objIndex != -1){
				Texture2D spriteText = (Texture2D) Resources.Load("ItemTexture/" + FPH_InventoryManager.inventoryTexture[objIndex]) as Texture2D;
				Sprite textSprite = Sprite.Create(spriteText, new Rect(0, 0, 128.0f, 128.0f), new Vector2(0.5f, 0.5f), 100);
				gameObject.GetComponent<SpriteRenderer>().sprite = textSprite;
				privateObjIndex = objIndex;
			}
			if(objIndex == -1){
				gameObject.GetComponent<SpriteRenderer>().sprite = null;
			}
		}
		if(!hasObject01 && hasObject02){
			int objIndex = -1;
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.English){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj02Name_English);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Italian){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj02Name_Italian);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Spanish){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj02Name_Spanish);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.German){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj02Name_German);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.French){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj02Name_French);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Japanese){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj02Name_Japanese);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Chinese){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj02Name_Chinese);
			}
			if(FPH_LanguageManager.gameLanguage == FPH_LanguageManager.LanguagesEnum.Russian){
				objIndex = FPH_InventoryManager.inventoryName.IndexOf(obj02Name_Russian);
			}
			
			if(objIndex != -1){
				Texture2D spriteText = (Texture2D) Resources.Load("ItemTexture/" + FPH_InventoryManager.inventoryTexture[objIndex]) as Texture2D;
				Sprite textSprite = Sprite.Create(spriteText, new Rect(0, 0, 128.0f, 128.0f), new Vector2(0.5f, 0.5f), 100);
				gameObject.GetComponent<SpriteRenderer>().sprite = textSprite;
				privateObjIndex = objIndex;
			}
			if(objIndex == -1){
				gameObject.GetComponent<SpriteRenderer>().sprite = null;
			}
		}

		
		if(!hasObject01 && !hasObject02){
			privateObjIndex = -1;
			gameObject.GetComponent<SpriteRenderer>().sprite = null;
		}
	}
	
	public void OnCustomMouseUp(){
		HandleButtonUp();
	}
	public void OnTouchUp(){
		HandleButtonUp();
	}
	
	// To select an item you only have to set the selected index var
	void HandleButtonUp(){
		if(privateObjIndex == -1){
			FPH_InventoryManager.selectedIndex = privateObjIndex;
		}
	}
}
