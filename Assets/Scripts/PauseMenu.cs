using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	
	public static PauseMenu m_instance;
	public GameObject m_pauseCanvas;

	bool m_pauseOpened;

	// Use this for initialization
	void Start () {
		m_instance = this;
		m_pauseOpened = false;
		LockCursor();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (m_pauseOpened){
				ClosePauseMenu();
			}
			else{
				OpenPauseMenu();
			}
		}
	}

	void LockCursor(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void UnlockCursor(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void ClosePauseMenu(){
		m_pauseCanvas.SetActive(false);
		m_pauseOpened = false;
		LockCursor();
		Time.timeScale = 1;
	}

	public void OpenPauseMenu(){
		m_pauseCanvas.SetActive(true);
		m_pauseOpened = true;
		UnlockCursor();
		Time.timeScale = 0;
	}

	public void TitleScreen(){
		UnlockCursor();
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}

	public bool IsPaused(){
		return m_pauseOpened;
	}
}
