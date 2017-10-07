using UnityEngine;
using System.Collections;

public class FPH_ControlManager : MonoBehaviour {

	/*
	 * Here's where button config is stored.
	 * In this way we can refere to a button simply by calling the static var.
	 * This allow us to modify a button without modify every single script where
	 * this button is used.
	 * There are a couple of other important function like inventory "trigger"
	 * and save bool function.
	 */
	
	[Header("Interactions Buttons")]
	public KeyCode observeButton = KeyCode.L;
	public KeyCode inventoryObjButton = KeyCode.K;
	public KeyCode showInventoryButton = KeyCode.Y;
	public KeyCode showInventorySpriteButton = KeyCode.U;
	public KeyCode interactButton = KeyCode.J;
	public KeyCode interactDialogButton = KeyCode.L;
	public KeyCode showTextButton = KeyCode.J;
	public KeyCode interactChangeLevelButton = KeyCode.I;
	public KeyCode interactDoorButton = KeyCode.J;
	
	[Header("Change Level Buttons")]
	public KeyCode changeLevelYes_Button = KeyCode.M;
	public KeyCode changeLevelNo_Button = KeyCode.N;
	
	[Header("Flashlight Buttons")]
	public KeyCode switchFlashlight = KeyCode.F;
	public KeyCode useBatteries = KeyCode.T;
	
	[Header("Other Buttons")]
	public KeyCode pauseButton = KeyCode.P;

	[Header("")]
	public GameObject pauseUI;

	public static KeyCode static_observeButton;
	public static KeyCode static_inventoryObjButton;
	public static KeyCode static_showInventoryButton;
	public static KeyCode static_showInventorySpriteButton;
	public static KeyCode static_interactButton;
	public static KeyCode static_interactChangeLevelButton;
	public static KeyCode static_changeLevelYes_Button;
	public static KeyCode static_changeLevelNo_Button;
	public static KeyCode static_interactDialogButton;
	public static KeyCode static_showTextButton;
	public static KeyCode static_switchFlashlight;
	public static KeyCode static_interactDoorButton;
	public static KeyCode static_useBatteries;
	public static KeyCode static_pauseButton;
	
	public static bool isScreenLocked;
	public static bool canBeControlled;
	public static bool isOnPause;

	
	// Use this for initialization
	void Awake(){
		static_observeButton = observeButton;
		static_inventoryObjButton = inventoryObjButton;
		static_showInventoryButton = showInventoryButton;
		static_showInventorySpriteButton = showInventorySpriteButton;
		static_interactButton = interactButton;
		static_changeLevelYes_Button = changeLevelYes_Button;
		static_changeLevelNo_Button = changeLevelNo_Button;
		static_interactDialogButton = interactDialogButton;
		static_showTextButton = showTextButton;
		static_interactChangeLevelButton = interactChangeLevelButton;
		static_switchFlashlight = switchFlashlight;
		static_interactDoorButton = interactDoorButton;
		static_useBatteries = useBatteries;
		static_pauseButton = pauseButton;
	}

	// Use this for initialization
	void Start(){
		FPH_ControlManager.canBeControlled = true;
		isScreenLocked = true; // Screen.lockCursor = true;
		isOnPause = false;
		pauseUI.SetActive(false);
	}

	// Use this for initialization
	void Update(){
		if(Input.GetKeyUp(showInventoryButton)){
			FPH_InventoryManager.showInventory = !FPH_InventoryManager.showInventory;
			isScreenLocked = !isScreenLocked; // Screen.lockCursor = !Screen.lockCursor;
			FPH_ControlManager.canBeControlled = !FPH_ControlManager.canBeControlled;
			FPH_InventoryManager.equippedItem = "";
			FPH_InventoryManager.equippedItem_Index = -1;
			FPH_InventoryManager.selectedIndex = -1;
		}
		if(Input.GetKeyUp(showInventorySpriteButton)){
			FPH_InventoryManager.showInventory_Sprite = !FPH_InventoryManager.showInventory_Sprite;
			isScreenLocked = !isScreenLocked; // Screen.lockCursor = !Screen.lockCursor;
			FPH_ControlManager.canBeControlled = !FPH_ControlManager.canBeControlled;
			FPH_InventoryManager.equippedItem = "";
			FPH_InventoryManager.equippedItem_Index = -1;
			FPH_InventoryManager.selectedIndex = -1;
		}

		if(Input.GetKeyUp(pauseButton)){
			if(FPH_ControlManager.canBeControlled && !isOnPause){
				isOnPause = true;
				FPH_ControlManager.canBeControlled = false;
				isScreenLocked = false;
				pauseUI.SetActive(isOnPause);
			}
			else if(!FPH_ControlManager.canBeControlled && isOnPause){
				isOnPause = false;
				FPH_ControlManager.canBeControlled = true;
				isScreenLocked = true;
				pauseUI.SetActive(isOnPause);
			}
		}


		if(isScreenLocked){
			// Comment the next line if using Unity 5
			// Screen.lockCursor = true;

			// Uncomment these lines if using Unity 5

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;

		}
		else{
			// Comment the next line if using Unity 5
			// Screen.lockCursor = false;

			// Uncomment these lines if using Unity 5

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

		}
	}

	// 1 is true 0 is false
	public static void SaveBool(string keyToSave, bool value){
		if(value){
			PlayerPrefs.SetInt(keyToSave, 1);
		}
		else{
			PlayerPrefs.SetInt(keyToSave, 0);
		}
	}

	public static bool LoadBool(string keyToLoad){
		int boolInt = PlayerPrefs.GetInt(keyToLoad);

		if(boolInt == 0){
			return false;
		}
		else if(boolInt == 1){
			return true;
		}
		return false;
	}
}