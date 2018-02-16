using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtanaPickUp : MonoBehaviour {

	public int pointsToAdd;

	// Äänilähde
	public AudioSource EtanaSoundEffect;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		ScoreManager.AddPoints(pointsToAdd);

		// Rahan keruuääni
		EtanaSoundEffect.Play();

		Destroy (this.gameObject);


	}
}
