using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour {

	public static Difficulty m_instance;
	int m_difficulty = 0;

	// Use this for initialization
	void Start () {
		if (m_instance == null){
			m_instance = this;
		}
		else{
			Destroy(gameObject);
		}
		
		m_difficulty = 0;

		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetEasy(){
		m_difficulty = 0;
	}

	public void SetNormal(){
		m_difficulty = 1;
	}
	public void ChangeDifficulty(int num){
		m_difficulty = num;
		Debug.Log("Difficulty:"+m_difficulty);
	}

	public int GetDifficulty(){
		return m_difficulty;
	}

}
