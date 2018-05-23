using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

	// Use this for initialization
	void Start () {
        if (instance != null) {
            Destroy(gameObject);
            print("Destroyed an instance of Music Player.");
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
