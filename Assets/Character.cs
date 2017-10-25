using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rb;
	float maxSpeed = 10f;
	float jumpForce = 150f;
	bool landed = true;
	float distToGround;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		distToGround = gameObject.GetComponent<Collider2D> ().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		
		float move = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) && landed==true) {
			
			rb.AddForce (transform.up * jumpForce);
			landed=false;
		}	



	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log (coll.gameObject.tag);
			//Debug.Log ("WORKS");
		if(coll.gameObject.tag == "ground")
		{
			Debug.Log ("WORKS");
			landed = true;
		}
	}

}
