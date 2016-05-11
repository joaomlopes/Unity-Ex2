using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake() {
		if(instance != null) {
			//Destroy the duplicate game object
			Destroy(gameObject);
		} else {
			//Assign this game object to the instance
			instance = this;
			//Avoid gameobject get destroyed everytime that the scene loads
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	void ChangeVolume() {
		
	}
}
