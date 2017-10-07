using UnityEngine;
using System.Collections;

public class FPH_FadeCamera : MonoBehaviour {
	
	public Texture2D fadeText;
	public float fadeSpeed = 0.3f;
	
	[HideInInspector] public float alpha = 1.0f;
	[HideInInspector] public enum FadeInOut {In, Out, NoFade}
	[HideInInspector] public FadeInOut fade = FadeInOut.In;
	
	// This fade from all black to transparent.
	public void FadeIn(){
		fade = FadeInOut.In;
	}

	// This fade from transparent to all black.
	public void FadeOut(){
		fade = FadeInOut.Out;
	}

	void OnGUI(){
		GUI.depth = -1000; //Change this value if you have some problem

		if(fade == FadeInOut.In){
			alpha += (fadeSpeed * Time.deltaTime) * -1.0f;
			alpha = Mathf.Clamp(alpha, 0.0f, 1.0f); // Is better to avoid " alpha " to be bigger than 1 and smaller than 0
			GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeText);
		}
		else if(fade == FadeInOut.Out){
			alpha += (fadeSpeed * Time.deltaTime) * 1.0f;
			alpha = Mathf.Clamp(alpha, 0.0f, 1.0f); // Is better to avoid " alpha " to be bigger than 1 and smaller than 0
			GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeText);
		}
		else if(fade == FadeInOut.NoFade){
			/*
			 * This may look useless but if yoiu do not want to fade the camera on start
			 * you will only have to set " fade " var to NoFade.
			 */
		}
	}
}