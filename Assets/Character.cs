using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rb;
	float maxSpeed = 8f;
	float jumpVelocity = 8f;
	bool landed = true;
	float distToGround;
	float jumpx;
	float jumpy;
	float jumpForce=350;
	Vector2 jumpDirection;
	Vector2 characterDirection;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		distToGround = gameObject.GetComponent<Collider2D> ().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && landed) {
			rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
			landed=false;
		}	
		if (Input.GetMouseButtonDown (1)) {
			jumpDirection = new Vector2(Input.mousePosition.x - ((transform.position.x+10)*50), (Input.mousePosition.y - ((transform.position.y+5)*50))).normalized*jumpVelocity;
			rb.velocity = jumpDirection;
			if (rb.velocity.y > 0) {
				landed = false;
			}
		}
		if(!(Input.GetKey(KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && landed)
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
	}

	void FixedUpdate () {
		/*float move = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);*/
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			rb.velocity = new Vector2 (-maxSpeed, rb.velocity.y);
		} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			rb.velocity = new Vector2 (maxSpeed, rb.velocity.y);
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "ground")
		{
			landed = true;
			rb.velocity = new Vector2 (0, 0);
		}
	}

}