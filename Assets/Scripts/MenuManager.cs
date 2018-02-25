using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject m_controls;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonStart(){
		SceneManager.LoadScene(1);
	}

	public void ButtonControls(){
		m_controls.SetActive(!m_controls.activeInHierarchy);
	}
}
