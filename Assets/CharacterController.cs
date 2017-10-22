using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rb;
	private float maxSpeed=10f;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {

		float move = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (move*maxSpeed, rb.velocity.y);


	}

}
