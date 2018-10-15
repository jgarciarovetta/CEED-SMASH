using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour{

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			Application.LoadLevel("SceneDay3");
		}
	}
}



