using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	private GameObject clone;
	private GameObject newEnemy;
	private float xposition;
	private float timing;
	private IEnumerator coroutine;
	private bool create;
	void Start () {
		newEnemy = GameObject.Find ("Enemy");
		timing = 3;
		create = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (create) {	
			create = false;
			if(timing>.1f)
				timing -= .05f;
			xposition = (Random.value * 5) - 5;
			Vector2 spawnPoint = new Vector2 (xposition, 10f);
			clone = Instantiate (newEnemy, spawnPoint, Quaternion.identity);
			coroutine = reloadTimer (timing);
			StartCoroutine (coroutine);
		}
			
	}
	private IEnumerator reloadTimer(float waitTime)
	{	
		yield return new WaitForSeconds(waitTime);
		create = true;
	}
}
