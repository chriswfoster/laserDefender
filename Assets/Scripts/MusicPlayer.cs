using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	// Use this for initialization
	static MusicPlayer instance = null;
	
	private AudioSource music;
	// Games are called in order: Awake > Start > Update.
	
	void Awake() {
		Debug.Log("Music player Awake " + GetInstanceID());
		if(instance != null && instance != this){
			Destroy (gameObject);
		} else {
			instance = this; // 
			GameObject.DontDestroyOnLoad(gameObject);
			//music = GetComponent<AudioSource>(); // for custom audio per level
		}
	}
	
	void Start () {
		Debug.Log("Music player Start " + GetInstanceID());
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnLevelWasLoaded (int level) {
		Debug.Log("Music player was loaded by level: "+level);
		// music.Stop(); // if I was doing custom audio per level
		/*if (level == 0){
			music.clip = startClip; // need to define these above...
		}
		if (level == 1){
			music.clip = bossClip;
		}
		if (level == 2){
			music.clip = endClip;
		}
		music.loop = true;
		music.Play ();*/
	}
	
	
}
