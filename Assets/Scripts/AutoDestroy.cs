﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {


	public float timer = 2.0f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,timer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
