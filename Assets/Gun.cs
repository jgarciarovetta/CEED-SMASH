using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	float angle;
	//float armLength = 1.5f;
	private GameObject player;
	void Start () {
		player = GameObject.Find ("Character");
	}
	
	// Update is called once per	 frame
	void Update () {
		Vector3 gunPos = Camera.main.ScreenToWorldPoint (Input.mousePosition) - player.transform.position;
		gunPos.z = 0;
		transform.position = player.transform.position + gunPos.normalized;
		Vector3 mouse = Input.mousePosition;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 offset = mouse - screenPoint;
		float angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler ( 0,0,angle);
		/*Vector3 rotatePos = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y, 0);
		transform.RotateAround(rotatePos, Vector3.back , angle);*/

	}
}
