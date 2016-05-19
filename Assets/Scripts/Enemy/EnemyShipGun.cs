using UnityEngine;
using System.Collections;

public class EnemyShipGun : MonoBehaviour {

	public GameObject EnemyShipBulletGO;

	// Use this for initialization
	void Start () {

		Invoke("FireEnemyBullet", 1f);

	}

	void FireEnemyBullet() {

		//Get Player's Spaceship Position
		GameObject spaceship = GameObject.Find("SpaceshipGO");


		if(spaceship != null) {

			GameObject bullet = (GameObject)Instantiate(EnemyShipBulletGO);

			bullet.transform.position = transform.position;

			Vector2 direction = spaceship.transform.position - bullet.transform.position;

			bullet.GetComponent<EnemyShipBullet>().SetDirection(direction);
		}

	}

}
