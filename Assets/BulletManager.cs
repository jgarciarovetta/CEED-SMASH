using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	public Vector3 spawnPoint;
	public int bulletCounter = 0;
	GameObject bullet;
	GameObject enemyBullet;
	private GameObject clone;
	private GameObject enemy;
	private GameObject guntip;
	private Vector2 playerPos;
	private Vector2 enemyPos;
	private Vector3 tipPos;
	private Vector2 fireVector;
	private IEnumerator coroutine;
	public bool enemyFire = true;
	public GameObject player;	
	float bulletSpeed = 10f;
	Vector3 offset;
	void Start () {
		bullet = GameObject.Find("Bullet");
		enemyBullet = GameObject.Find ("EnemyBullet");
		enemy = GameObject.Find ("Enemy");
		guntip = GameObject.Find ("GunTip");
		player = GameObject.Find ("Character");
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && bulletCounter<10) {
			bulletCounter++;
			tipPos = guntip.transform.position;
			clone = Instantiate (bullet, tipPos , Quaternion.identity);
			if (bulletCounter == 10) {
				coroutine = reloadTimer (3);
				StartCoroutine (coroutine);
			}
		}
		/*if (enemy!=null && enemyFire) {
			enemyFire = false;
			enemyPos = enemy.transform.position;			
			enemyPos.y += 1f;
			//clone = Instantiate (enemyBullet, enemyPos, Quaternion.identity);
			fireVector = new Vector2 (player.transform.position.x - transform.position.x , 
				player.transform.position.y - transform.position.y).normalized;
			//rb.velocity = new Vector2 (rb.velocity.x * bulletSpeed, rb.velocity.y * bulletSpeed);
			EnemyBullet enemybullet = new EnemyBullet(fireVector*bulletSpeed, enemyPos);
			coroutine = reloadTimer (3);
			StartCoroutine (coroutine);

		}*/

	}
	private IEnumerator reloadTimer(float waitTime)
	{	
		yield return new WaitForSeconds(waitTime);
		if (bulletCounter == 10) {
			bulletCounter = 0;
		} else {
			enemyFire = true;
		}
	}
	

}
