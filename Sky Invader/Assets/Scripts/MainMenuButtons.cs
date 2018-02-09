using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	void Start () {
		Time.timeScale = 0.00000000001f;
	}

	public void PlayGame() {
		SceneManager.LoadScene ("lv01");
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
