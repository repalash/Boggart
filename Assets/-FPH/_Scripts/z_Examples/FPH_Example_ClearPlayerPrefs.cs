using UnityEngine;
using System.Collections;

public class FPH_Example_ClearPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll();
		/*
		if(ES2.Exists("es2_keyInventoryName") && ES2.Exists("es2_keyInventoryTexture") && ES2.Exists("es2_keyInventoryDesc")){
			ES2.Delete("es2_keyInventoryName");
			ES2.Delete("es2_keyInventoryTexture");
			ES2.Delete("es2_keyInventoryDesc");
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
