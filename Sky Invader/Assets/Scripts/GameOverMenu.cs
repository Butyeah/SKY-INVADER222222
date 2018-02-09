using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	private KillPlayer killPlayer;

	// Use this for initialization
	void Start () {
		killPlayer = FindObjectOfType<KillPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
