using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	float enemySpeed = 2f;
	int health = 5;
	private bool enemyFire = true;
	private Vector2 fireVector;
	private IEnumerator coroutine;
	private GameObject enemyBullet;
	private GameObject clone;
	public bool weaponized;

	Rigidbody2D rb;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = 1;
		enemyBullet = GameObject.Find ("EnemyBullet");
	}
	void Update () {
		
	}

	void FixedUpdate () {
		if (gameObject.name != "Enemy") {
			rb.velocity = new Vector2 (enemySpeed, rb.velocity.y);
			if (Mathf.Abs (rb.position.x) > 4.5f) {
				enemySpeed *= -1;
				rb.velocity = new Vector2 (enemySpeed, rb.velocity.y);
				if (enemyFire) {
					enemyFire = false;
					clone = Instantiate (enemyBullet, rb.transform.position, Quaternion.identity);
					coroutine = reloadTimer (3);
					StartCoroutine (coroutine);

				}
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			weaponized = true;
			coroutine = reloadTimer (.1f);
			StartCoroutine (coroutine);
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "bullet")
			health--;
		if (coll.gameObject.tag == "sword" && weaponized)
			health -= 2;
		if(health<1)
			Destroy (this.gameObject);
	}
	private IEnumerator reloadTimer(float waitTime)
	{	
		yield return new WaitForSeconds(waitTime);
		if (weaponized)
			weaponized = false;
		else
			enemyFire = true;

	}

	void OnBecameInvisible()
	{
		Destroy (this.gameObject);
	}
}
