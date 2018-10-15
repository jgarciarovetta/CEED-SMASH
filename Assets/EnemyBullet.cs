using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	public Rigidbody2D rb;
	float bulletSpeed = 10f;
	public GameObject player;	
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Character");
		enemy = GameObject.Find ("Enemy");
		Vector3 playerPos = player.transform.position;
		//Vector3 screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 offset = transform.position - playerPos;
		float angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler ( 0,0, angle);
		if (gameObject.name != "EnemyBullet") {
			rb = GetComponent<Rigidbody2D> ();
			rb.velocity = new Vector2 (player.transform.position.x - transform.position.x , 
				player.transform.position.y - transform.position.y).normalized;
			rb.velocity = new Vector2 (rb.velocity.x * bulletSpeed, rb.velocity.y * bulletSpeed);
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D coll)
	{			
		if (coll.gameObject.tag == "character" || coll.gameObject.tag == "ground") {
			if (gameObject.name != "EnemyBullet") {					
				Destroy (this.gameObject);
			}
		}		
	}
	void OnBecameInvisible()		
	{			
		if (gameObject.name != "EnemyBullet") {
		Destroy (this.gameObject);			}
	
	}
}
