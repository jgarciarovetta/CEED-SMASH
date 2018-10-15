using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	Rigidbody2D rb;
	float platformSpeed = -2f;
	private GameObject clone;
	private Vector2 spawnPoint;
	private float yPosition;
	bool alreadyCalled;
	// Use this for initialization
	void Start () {
		alreadyCalled = false;
		clone = GameObject.Find ("Platform");
		rb = GetComponent<Rigidbody2D>();
		yPosition = (Random.value * 5) - 5;
		spawnPoint = new Vector2 (15, yPosition);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (platformSpeed, 0);
		if (transform.position.x < 0f && !alreadyCalled) {
			clone = this.gameObject;
			clone = Instantiate (clone, spawnPoint, Quaternion.identity);
			alreadyCalled = true;
		}
	}

	void OnBecameInvisible()
	{
		Destroy (this.gameObject);
	}
}
