using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {

	public GameObject player;
	public GameObject gameOverMenu;
	private bool isGameOver;

	public AudioSource Deathsound;

	void Awake () {
		gameOverMenu.SetActive(false);
	}

	void Update () {
		if (isGameOver == true) {
			if (Input.GetKeyDown (KeyCode.Mouse1)) {
				return;
			} else if (Input.anyKeyDown) {
				GameOverMenu ();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			DestroyGameObject ();
			Deathsound.Play ();
			GameOverMenu ();
		}
	}

	void DestroyGameObject () {
		Destroy (player);
		Deathsound.Play ();
	}

	void GameOverMenu () {
		gameOverMenu.SetActive(true);
		Time.timeScale = 0f;
		isGameOver = true;
	}

	public void PlayAgain () {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("lv01");
	}

	public void LoadMenu () {
		SceneManager.LoadScene ("TitleScreen");
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
