using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour {

	public GameObject victoryScreen;

	void Awake () {
		victoryScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			victoryScreen.SetActive(true);
			Time.timeScale = 0f;
		}
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
