using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

	void Awake(){
		Camera m_minimapCamera = GetComponent<Camera>();

		float height = m_minimapCamera.pixelRect.height;

		Rect pixelRect = m_minimapCamera.pixelRect;

		pixelRect.width = height;
		pixelRect.x = (float)Screen.width - height;

		m_minimapCamera.pixelRect = pixelRect;
		Debug.Log(m_minimapCamera.pixelRect);
	}
}
