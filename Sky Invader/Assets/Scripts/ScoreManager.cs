using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;

	// Muuttuja edustaa ScoreCounter-tekstilaatikkoa
	Text text;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text>();

		score = 0;		
	}

	// Update is called once per frame
	void Update () {

		// Jos score menee alle nollan, niin estetään se
		if (score < 0)
			score = 0;
		// Päivittää ScoreCounteria
		text.text = "" + score;

	}

	public static void AddPoints(int pointsToAdd)
	{
		score += pointsToAdd;
	}
}
