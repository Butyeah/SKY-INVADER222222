using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 0;
	public float JumpHeight = 0;

	// maakosketus tranformed
	public Transform GroundCheck;
	public float groundCheckRadius = 0.1f;
	public LayerMask whatIsGround;
	public bool grounded;

	private bool doubleJumped;


	//Laukasukohta ja ammus
	public Transform firePoint;
	public GameObject fireBall;

	public AudioSource JumpingSound;

	private Animator anim;

	private float moveVelocity;



	private void Start()
	{
		//Animaatiota voidaan kontrolloida
		anim = GetComponent<Animator> ();
	}


	void FixedUpdate(){

		// grounded = true, kun ollaan maassa ja false kun ei olla maassa
		grounded = Physics2D.OverlapCircle (GroundCheck.position, groundCheckRadius, whatIsGround);
		Debug.Log ("grounded = " + grounded);
	}

	// Update is called once per frame
	void Update () {

		//Debug.Log ("JumpHeight = " + JumpHeight);

		//ollaanko maassa?
		if (grounded) {
			//ollaan maassa, estetään tuplahyppy
			doubleJumped = false;
		}

		// Määritellään hyppyanimaation tila
		anim.SetBool("Grounded", grounded);


		// Tarkistetaan voidaanko hypätä
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			// Painettiin välilyöntinäppäintä , suoritetaan hyppy
			// velocity = nopeus
			// hyppy onnistuu jos ollaan maassa
			Jump ();



		}

		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			// Ääni hypyssä
			JumpingSound.Play ();

		}
	

		// Tarkistetaan voidaanko hypätä uudelleen
		if (Input.GetKeyDown (KeyCode.Space) && !grounded && !doubleJumped) {
			// Hyppy onnistuu, jos ei olla maassa eikä olla tekemässä kaksoishyppyä.
			// Painettiin välilyöntinäppäintä , suoritetaan hyppy
			Jump ();
			doubleJumped = true;

		}

		if (Input.GetKeyDown (KeyCode.Space) && !grounded && !doubleJumped) {
			JumpingSound.Play ();
			doubleJumped = true;
		}
		//Ennen painikkeiden painamista, nopeus = 0
		moveVelocity = 0;

		if (Input.GetKey (KeyCode.D)) {
			// liike oikealle
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = moveSpeed;
		}

		if (Input.GetKey (KeyCode.A)) {
			// liike oikealle
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = -moveSpeed;
		}

		anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);


		//käännetään pelihahmo sen transformin avulla
		if(GetComponent<Rigidbody2D>().velocity.x > 0){

			//suunta on oikea
			transform.localScale = new Vector3(0.4f,0.4f,0.4f);
		}
		else if (GetComponent<Rigidbody2D>().velocity.x < 0){

			//Suunta on vasemmalle
			transform.localScale = new Vector3(-0.4f,0.4f,0.4f);
		}

		//Ampuminen. Painettiinko return painiketta?
		if (Input.GetKey (KeyCode.Return)) {

			//Return.painiketta painettu, joten laukaistaan ammus (prefabs-kansiosta)
			Instantiate(fireBall, firePoint.position, firePoint.rotation);
		}
	}

	void Jump(){
		GetComponent <Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
		JumpingSound.Play();
	}
}
