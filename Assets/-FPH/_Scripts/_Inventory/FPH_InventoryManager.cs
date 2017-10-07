using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FPH_InventoryManager : MonoBehaviour {

	public GUISkin customSkin;
	public GameObject inventoryUI_Sprite;
	public GameObject inventoryDesc_Sprite;
	public GameObject inventoryIconUI;
	public Text inventoryDesc_TextMesh;
	public Image inventoryIconUI_Sprite;
	//public SpriteRenderer[] inventoryItemRenderer;

	public static List<string> inventoryName = new List<string>();
	public static List<string> inventoryTexture = new List<string>();
	public static List<string> inventoryDesc = new List<string>();
	
	public static bool showInventory;
	public static bool showInventory_Sprite;
	public static int selectedIndex;
	public static string equippedItem;
	public static int equippedItem_Index;
	
	private float xMultiplier = 0.5078125f;
	private float yMultiplier = 0.632f;


	/*
	 * We reset some var and load the inventory.
	 * If you don't want to do that on Awake you can put " FPH_InventoryManager.LoadInventory(); "
	 * wherever you want.
	 */
	void Awake(){
		LoadInventory();
		showInventory = false;
		showInventory_Sprite = false;
		selectedIndex = -1;
		equippedItem = "";
		equippedItem_Index = -1;
	}
	
	void Update(){
		/*
		// This is some debug code in case you need it.
		if(selectedIndex != -1){
			Debug.Log("Equipped Item: " + equippedItem);
		}
		Debug.Log(inventoryName.Count);
		
		if(Input.GetKey(KeyCode.G)){
			RemoveAllInventoryItem();
		}
		*/

		/*
		 * This is here for debugging purpose, if you want to remove all
		 * The item which are inside of the inventory you only have to write this line
		 * " FPH_InventoryManager.RemoveAllInventoryItem(); "
		 */
		if(Input.GetKey(KeyCode.G)){
			RemoveAllInventoryItem();
		}

		if(showInventory_Sprite){
			inventoryUI_Sprite.SetActive(true);

			// If we selected one item we show the description and a bigger icon
			if(selectedIndex != -1){
				inventoryDesc_Sprite.SetActive(true);
				inventoryIconUI.SetActive(true);

				Texture2D spriteText = (Texture2D) Resources.Load("ItemTexture/" + inventoryTexture[selectedIndex]) as Texture2D;
				Sprite textSprite = Sprite.Create(spriteText, new Rect(0, 0, 128.0f, 128.0f), new Vector2(0.5f, 0.5f), 100);
				inventoryIconUI_Sprite.sprite = textSprite;
				inventoryDesc_TextMesh.text = inventoryDesc[selectedIndex];
			}
			else{ // If nothing is selected we hide everything
				inventoryDesc_Sprite.SetActive(false);
				inventoryIconUI.SetActive(false);
				inventoryIconUI_Sprite.sprite = null;
				inventoryDesc_TextMesh.text = "";
			}
		}
		if(!showInventory_Sprite){
			inventoryUI_Sprite.SetActive(false);
		}
	}

	public static void AddInventoryItem(string itemName, string itemTextureGUI, string itemDesc){
		if(inventoryName.Count < 40){ // I decided to put this limit to invetory capacity but you can increase it if you want
			inventoryName.Add(itemName);
			inventoryTexture.Add(itemTextureGUI);
			inventoryDesc.Add(itemDesc);
		}
		else{
			Debug.Log("Inventory Full");
		}
	}

	// You can call this function to know if an object is inside of the inventory
	public static bool HasObject(string itemName){
		if(inventoryName.FindIndex(itmString => itmString == itemName) > -1){
			return true;
		}
		else{
			return false;
		}
		//return false;
	}
	
	public static void RemoveInventoryItem(int index){
		inventoryName.RemoveAt(index);
		inventoryTexture.RemoveAt(index);
		inventoryDesc.RemoveAt(index);
		FPH_InventoryManager.SaveInventory();
	}
	
	public static void RemoveAllInventoryItem(){
		for(int i = 0; i < inventoryName.Count; i++){
			inventoryName.RemoveAt(i);
			inventoryTexture.RemoveAt(i);
			inventoryDesc.RemoveAt(i);
			FPH_InventoryManager.SaveInventory();
		}
	}

	/*
	 * This is the code about loading and saving inventory in order to load it when the player
	 * start the game again.
	 * Remember that " keyInventoryName ", " keyInventoryTexture ", " keyInventoryDesc " are keys
	 * that should not be used anywhere else in your game.
	 */
	public static void SaveInventory(){
		//Comment these lines if you want to use EasySave2 to SaveLoad inventory
		BinaryFormatter binFor_Name = new BinaryFormatter();
		MemoryStream memStr_Name = new MemoryStream();
		binFor_Name.Serialize(memStr_Name, inventoryName);
		PlayerPrefs.SetString("keyInventoryName", Convert.ToBase64String(memStr_Name.GetBuffer()));
		
		BinaryFormatter binFor_Text = new BinaryFormatter();
		MemoryStream memStr_Text = new MemoryStream();
		binFor_Text.Serialize(memStr_Text, inventoryTexture);
		PlayerPrefs.SetString("keyInventoryTexture", Convert.ToBase64String(memStr_Text.GetBuffer()));
		
		BinaryFormatter binFor_Desc = new BinaryFormatter();
		MemoryStream memStr_Desc = new MemoryStream();
		binFor_Desc.Serialize(memStr_Desc, inventoryDesc);
		PlayerPrefs.SetString("keyInventoryDesc", Convert.ToBase64String(memStr_Desc.GetBuffer()));

		/*
		//Uncomment that if you want to use EasySave2 to Load/Save inventory
		ES2.Save(inventoryName, "es2_keyInventoryName");
		ES2.Save(inventoryTexture, "es2_keyInventoryTexture");
		ES2.Save(inventoryDesc, "es2_keyInventoryDesc");
		*/
	}
	public static void LoadInventory(){
		//Comment these lines if you want to use EasySave2 to SaveLoad inventory
		inventoryName = RetrieveInventory(PlayerPrefs.GetString("keyInventoryName"));
		inventoryTexture = RetrieveInventory(PlayerPrefs.GetString("keyInventoryTexture"));
		inventoryDesc = RetrieveInventory(PlayerPrefs.GetString("keyInventoryDesc"));

		/*
		//Uncomment that if you want to use EasySave2 to Load/Save inventory
		if(ES2.Exists("es2_keyInventoryName") && ES2.Exists("es2_keyInventoryTexture") && ES2.Exists("es2_keyInventoryDesc")){
			inventoryName = ES2.LoadList<string>("es2_keyInventoryName");
			inventoryTexture = ES2.LoadList<string>("es2_keyInventoryTexture");
			inventoryDesc = ES2.LoadList<string>("es2_keyInventoryDesc");
		}
		*/
	}
	public static List<String> RetrieveInventory(string playerPrefsData){
		if(!String.IsNullOrEmpty(playerPrefsData)){
			BinaryFormatter binFor = new BinaryFormatter();
			try{
				MemoryStream memStr = new MemoryStream(Convert.FromBase64String(playerPrefsData));	
				List<String> objList = binFor.Deserialize(memStr) as List<String>;
				return objList;
			}
			catch(Exception ex){
				throw new Exception(ex.Message);
			}
			
		}
		else{
			List<string> emptyList = new List<string>();
			return emptyList;
		}
	}

	/*
	 * In case you don't want to use our sprite UI you can use standard UnityUI.
	 * To show this UI showInventory must be TRUE.
	 */
	void OnGUI(){
		GUI.skin = customSkin;

		if(showInventory){
			#region InventoryCell
			GUI.BeginGroup(new Rect((Screen.width/2) - (Screen.width * xMultiplier)/1.1f, (Screen.height/2) - (Screen.height * yMultiplier)/2, (Screen.width * xMultiplier), (Screen.height * yMultiplier)));
			GUI.Box(new Rect(0, 0, (Screen.width * xMultiplier), (Screen.height * yMultiplier)), "Inventory");

			if(inventoryName.Count >= 1){
				if(GUI.Button(new Rect((Screen.width * 0.003907f), (Screen.height * 0.0695f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[0]) as Texture)){
					selectedIndex = 0;
				}
			}
			if(inventoryName.Count >= 2){
				if(GUI.Button(new Rect((Screen.width * 0.066407f), (Screen.height * 0.0695f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[1]) as Texture)){
					selectedIndex = 1;
				}
			}
			if(inventoryName.Count >= 3){
				if(GUI.Button(new Rect((Screen.width * 0.128907f), (Screen.height * 0.0695f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[2]) as Texture)){
					selectedIndex = 2;
				}
			}
			if(inventoryName.Count >= 4){
				if(GUI.Button(new Rect((Screen.width * 0.191407f), (Screen.height * 0.0695f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[3]) as Texture)){
					selectedIndex = 3;
				}
			}
			if(inventoryName.Count >= 5){
				if(GUI.Button(new Rect((Screen.width * 0.253907f), (Screen.height * 0.0695f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[4]) as Texture)){
					selectedIndex = 4;
				}
			}
			if(inventoryName.Count >= 6){
				if(GUI.Button(new Rect((Screen.width * 0.316407f), (Screen.height * 0.0695f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[5]) as Texture)){
					selectedIndex = 5;
				}
			}
			if(inventoryName.Count >= 7){
				if(GUI.Button(new Rect((Screen.width * 0.378907f), (Screen.height * 0.0695f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[6]) as Texture)){
					selectedIndex = 6;
				}
			}
			if(inventoryName.Count >= 8){
				if(GUI.Button(new Rect((Screen.width * 0.441407f), (Screen.height * 0.0695f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[7]) as Texture)){
					selectedIndex = 7;
				}
			}


			if(inventoryName.Count >= 9){
				if(GUI.Button(new Rect((Screen.width * 0.003907f), (Screen.height * 0.18056f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[8]) as Texture)){
					selectedIndex = 8;
				}
			}
			if(inventoryName.Count >= 10){
				if(GUI.Button(new Rect((Screen.width * 0.066407f), (Screen.height * 0.18056f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[9]) as Texture)){
					selectedIndex = 9;
				}
			}
			if(inventoryName.Count >= 11){
				if(GUI.Button(new Rect((Screen.width * 0.128907f), (Screen.height * 0.18056f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[10]) as Texture)){
					selectedIndex = 10;
				}
			}
			if(inventoryName.Count >= 12){
				if(GUI.Button(new Rect((Screen.width * 0.191407f), (Screen.height * 0.18056f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[11]) as Texture)){
					selectedIndex = 11;
				}
			}
			if(inventoryName.Count >= 13){
				if(GUI.Button(new Rect((Screen.width * 0.253907f), (Screen.height * 0.18056f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[12]) as Texture)){
					selectedIndex = 12;
				}
			}
			if(inventoryName.Count >= 14){
				if(GUI.Button(new Rect((Screen.width * 0.316407f), (Screen.height * 0.18056f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[13]) as Texture)){
					selectedIndex = 13;
				}
			}
			if(inventoryName.Count >= 15){
				if(GUI.Button(new Rect((Screen.width * 0.378907f), (Screen.height * 0.18056f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[14]) as Texture)){
					selectedIndex = 14;
				}
			}
			if(inventoryName.Count >= 16){
				if(GUI.Button(new Rect((Screen.width * 0.441407f), (Screen.height * 0.18056f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[15]) as Texture)){
					selectedIndex = 15;
				}
			}

			if(inventoryName.Count >= 17){
				if(GUI.Button(new Rect((Screen.width * 0.003907f), (Screen.height * 0.291666666f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[16]) as Texture)){
					selectedIndex = 16;
				}
			}
			if(inventoryName.Count >= 18){
				if(GUI.Button(new Rect((Screen.width * 0.066407f), (Screen.height * 0.291666666f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[17]) as Texture)){
					selectedIndex = 17;
				}
			}
			if(inventoryName.Count >= 19){
				if(GUI.Button(new Rect((Screen.width * 0.128907f), (Screen.height * 0.291666666f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[18]) as Texture)){
					selectedIndex = 18;
				}
			}
			if(inventoryName.Count >= 20){
				if(GUI.Button(new Rect((Screen.width * 0.191407f), (Screen.height * 0.291666666f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[19]) as Texture)){
					selectedIndex = 19;
				}
			}
			if(inventoryName.Count >= 21){
				if(GUI.Button(new Rect((Screen.width * 0.253907f), (Screen.height * 0.291666666f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[20]) as Texture)){
					selectedIndex = 20;
				}
			}
			if(inventoryName.Count >= 22){
				if(GUI.Button(new Rect((Screen.width * 0.316407f), (Screen.height * 0.291666666f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[21]) as Texture)){
					selectedIndex = 21;
				}
			}
			if(inventoryName.Count >= 23){
				if(GUI.Button(new Rect((Screen.width * 0.378907f), (Screen.height * 0.291666666f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[22]) as Texture)){
					selectedIndex = 22;
				}
			}
			if(inventoryName.Count >= 24){
				if(GUI.Button(new Rect((Screen.width * 0.441407f), (Screen.height * 0.291666666f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[23]) as Texture)){
					selectedIndex = 23;
				}
			}

			if(inventoryName.Count >= 25){
				if(GUI.Button(new Rect((Screen.width * 0.003907f), (Screen.height * 0.402777777f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[24]) as Texture)){
					selectedIndex = 24;
				}
			}
			if(inventoryName.Count >= 26){
				if(GUI.Button(new Rect((Screen.width * 0.066407f), (Screen.height * 0.402777777f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[25]) as Texture)){
					selectedIndex = 25;
				}
			}
			if(inventoryName.Count >= 27){
				if(GUI.Button(new Rect((Screen.width * 0.128907f), (Screen.height * 0.402777777f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[26]) as Texture)){
					selectedIndex = 26;
				}
			}
			if(inventoryName.Count >= 28){
				if(GUI.Button(new Rect((Screen.width * 0.191407f), (Screen.height * 0.402777777f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[27]) as Texture)){
					selectedIndex = 27;
				}
			}
			if(inventoryName.Count >= 29){
				if(GUI.Button(new Rect((Screen.width * 0.253907f), (Screen.height * 0.402777777f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[28]) as Texture)){
					selectedIndex = 28;
				}
			}
			if(inventoryName.Count >= 30){
				if(GUI.Button(new Rect((Screen.width * 0.316407f), (Screen.height * 0.402777777f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[29]) as Texture)){
					selectedIndex = 29;
				}
			}
			if(inventoryName.Count >= 31){
				if(GUI.Button(new Rect((Screen.width * 0.378907f), (Screen.height * 0.402777777f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[30]) as Texture)){
					selectedIndex = 30;
				}
			}
			if(inventoryName.Count >= 32){
				if(GUI.Button(new Rect((Screen.width * 0.441407f), (Screen.height * 0.402777777f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[31]) as Texture)){
					selectedIndex = 31;
				}
			}


			if(inventoryName.Count >= 33){
				if(GUI.Button(new Rect((Screen.width * 0.003907f), (Screen.height * 0.513888888f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[32]) as Texture)){
					selectedIndex = 32;
				}
			}
			if(inventoryName.Count >= 34){
				if(GUI.Button(new Rect((Screen.width * 0.066407f), (Screen.height * 0.513888888f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[33]) as Texture)){
					selectedIndex = 33;
				}
			}
			if(inventoryName.Count >= 35){
				if(GUI.Button(new Rect((Screen.width * 0.128907f), (Screen.height * 0.513888888f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[34]) as Texture)){
					selectedIndex = 34;
				}
			}
			if(inventoryName.Count >= 36){
				if(GUI.Button(new Rect((Screen.width * 0.191407f), (Screen.height * 0.513888888f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[35]) as Texture)){
					selectedIndex = 35;
				}
			}
			if(inventoryName.Count >= 37){
				if(GUI.Button(new Rect((Screen.width * 0.253907f), (Screen.height * 0.513888888f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[36]) as Texture)){
					selectedIndex = 36;
				}
			}
			if(inventoryName.Count >= 38){
				if(GUI.Button(new Rect((Screen.width * 0.316407f), (Screen.height * 0.513888888f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[37]) as Texture)){
					selectedIndex = 37;
				}
			}
			if(inventoryName.Count >= 39){
				if(GUI.Button(new Rect((Screen.width * 0.378907f), (Screen.height * 0.513888888f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[38]) as Texture)){
					selectedIndex = 38;
				}
			}
			if(inventoryName.Count >= 40){
				if(GUI.Button(new Rect((Screen.width * 0.441407f), (Screen.height * 0.513888888f), (Screen.width * 0.0625f), (Screen.height * 0.111111111f)), Resources.Load("ItemTexture/" + inventoryTexture[39]) as Texture)){
					selectedIndex = 39;
				}
			}

			GUI.EndGroup();
			#endregion


			#region Details
			if(selectedIndex != -1){
				GUI.BeginGroup(new Rect(Screen.width/1.5f, (Screen.height/2) - (Screen.height * yMultiplier)/2, (Screen.width * 0.234375f), (Screen.height * 0.56f)), "");
					
				GUI.Box(new Rect(0, 0, (Screen.width * 0.234375f), (Screen.height * 0.416666666f)), "");
				if(GUI.Button(new Rect(0, (Screen.height * 0.48f), (Screen.width * 0.1f), (Screen.height * 0.0695f)), "Back")){
					selectedIndex = -1;
				}
				if(GUI.Button(new Rect((Screen.width * 0.13f), (Screen.height * 0.48f), (Screen.width * 0.1f), (Screen.height * 0.0695f)), "Equip")){
					EquipObject();
				}
				if(selectedIndex != -1){
					GUI.DrawTexture(new Rect((Screen.width * 0.01953125f), (Screen.height * 0.034722222f), (Screen.width * 0.1953125f), (Screen.height * 0.347222222f)), Resources.Load("ItemTexture/" + inventoryTexture[selectedIndex]) as Texture);
				}
				GUI.EndGroup();

				GUI.BeginGroup(new Rect((Screen.width/2) - (Screen.width * xMultiplier)/1.1f, (Screen.height * 0.833333333f), (Screen.width * xMultiplier), (Screen.height * 0.152777777f)), "");
				GUI.Box(new Rect(0.0f, 0.0f, (Screen.width * xMultiplier), (Screen.height * 0.152777777f)), "");

				if(selectedIndex != -1){
					GUI.Label(new Rect(0.0f, 0.0f, (Screen.width * xMultiplier), (Screen.height * 0.152777777f)), inventoryDesc[selectedIndex]);
				}
				
				GUI.EndGroup();
			}
			#endregion
		}

		if(equippedItem_Index != -1){
			GUI.DrawTexture(new Rect(1180.0f, 620.0f, 80.0f, 80.0f), Resources.Load("ItemTexture/" + inventoryTexture[equippedItem_Index]) as Texture);
		}
	}

	public static void EquipObject(){
		if(selectedIndex != -1){
			equippedItem = inventoryName[selectedIndex];
			equippedItem_Index = selectedIndex;
			FPH_ControlManager.isScreenLocked = true; // Screen.lockCursor = true;
			FPH_ControlManager.canBeControlled = true;
			showInventory = false;
			showInventory_Sprite = false;
			selectedIndex = -1;
			
			//Debug.Log("Equipped item: " + equippedItem);
		}
	}
}