using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour {

	AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource=this.GetComponent<AudioSource>();
		Application.runInBackground = true;
	}
	
	// Update is called once per frame
	void Update () {


		if (!audioSource.isPlaying){
			Debug.Log("restart music");
			audioSource.time = 90.2f;
			audioSource.Play();
		}
	}
}
