using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCounter : MonoBehaviour {

	public static BoatCounter m_instance;
	public int m_boats = 7;

	public GameObject m_winMenu;

	// Use this for initialization
	void Start () {
		m_instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void BoatDestroyed(){
		m_boats--;
		Debug.Log("Boat kill confirmed");

		if (m_boats == 0){
			Debug.Log("You win");
			m_winMenu.SetActive(true);
		}	
	}
}
