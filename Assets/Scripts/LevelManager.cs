using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public AudioClip levelcomplete;
	
	public void LoadLevel(string name){
		Application.LoadLevel(name);
		Debug.Log ("The level you're going to load is: " + name);
	}
	
	public void QuitRequest(){
		Application.Quit();
		Debug.Log("Quit request fired: ");
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	 
}
