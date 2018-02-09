using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float moveSpeed;
	public float tileSpeedZ;


	private bool hasPlayerMoved = false;

	private Vector3 startPosition;

// Use this for initialization
void Start () {
		startPosition = transform.position;

		Time.timeScale = 0.00000000001f;
}

// Update is called once per frame
void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			Time.timeScale = 1f;
			hasPlayerMoved = true;
		}

		if (hasPlayerMoved == true) {
			float newPosition = Mathf.Repeat (Time.time * moveSpeed, tileSpeedZ);
			transform.position = startPosition + Vector3.up * newPosition;
		}
}
}