using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Rigidbody2D rb;
	float bulletSpeed = 10f;
	public GameObject enemy;
	public GameObject player;
	void Start () {
		player = GameObject.Find ("Character");
		enemy = GameObject.Find ("Enemy");
		Vector3 mouse = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 offset = mouse - screenPoint;
		float angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler ( 0,0, angle);
		if (gameObject.name != "Bullet") {
			rb = GetComponent<Rigidbody2D> ();
			rb.velocity = new Vector2 ((Input.mousePosition.x - ((player.transform.position.x + 10) * 50)), (Input.mousePosition.y - ((player.transform.position.y + 5) * 50))).normalized;
			rb.velocity = new Vector2 (rb.velocity.x * bulletSpeed, rb.velocity.y * bulletSpeed);
		}
	}
	void Update () {
		

	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if ((coll.gameObject.tag == "ground"|| coll.gameObject.tag=="enemy") && gameObject.name != "Bullet") {
			Destroy (this.gameObject);
		}			
	}
	void OnBecameInvisible()		
	{
		if (gameObject.name != "Bullet") {
			Destroy (this.gameObject);
		}
			
	}

}
