using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour {

	AudioSource audioSource;

	float time = 0;
	float length;

	// Use this for initialization
	void Start () {
		audioSource=this.GetComponent<AudioSource>();

		length = audioSource.clip.length;

		audioSource.time = time;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= length - 1){
			
			audioSource.time = 90 + (time - length) - Time.deltaTime;	//90 seconds into the music
			time = audioSource.time;
		}
	}
}
