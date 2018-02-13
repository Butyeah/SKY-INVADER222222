using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	public AudioSource ButtonSound;
	public AudioSource QuitButtonSound;

	void Start () {
		Time.timeScale = 0.00000000001f;
	}

	public void PlayGame() {
		ButtonSound.Play ();
		SceneManager.LoadScene ("lv01");
	}

	public void QuitGame () {
		QuitButtonSound.Play ();
		Application.Quit ();
	}
}
