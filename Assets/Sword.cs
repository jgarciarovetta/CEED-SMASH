using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
	float angle;
	private IEnumerator coroutine;
	//float armLength = 1.5f;
	private GameObject player;
	bool weaponized = false;
	bool pause = false;
	private GameObject enemy;
	void Start () {
		player = GameObject.Find ("Character");
		enemy = GameObject.Find ("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 swordPos = Camera.main.ScreenToWorldPoint (Input.mousePosition) - player.transform.position;
		swordPos.z = 0;
		if (!pause) {
			transform.position = player.transform.position - swordPos.normalized;
		}
		Vector3 mouse = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 offset = mouse - screenPoint;
		float angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg;
		if(!pause)
			transform.rotation = Quaternion.Euler ( 0,0, angle);
		if (Input.GetMouseButtonDown (1)) {
			weaponized = true;
			transform.position = player.transform.position + swordPos.normalized;
			pause = true;
			coroutine = reloadTimer (.1f);
			StartCoroutine (coroutine);

		}
	}
	private IEnumerator reloadTimer(float waitTime)
	{	
		yield return new WaitForSeconds(waitTime);
		pause = false;
	}


}
