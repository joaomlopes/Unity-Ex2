using UnityEngine;
using System.Collections;

public class EnemyShipSpawner : MonoBehaviour {

	public GameObject EnemyShipGO;

	float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	void Start () {

		Invoke("SpawnEnemyShip", maxSpawnRateInSeconds);

		InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}

	void SpawnEnemyShip() {

		Vector2 min = Camera.main.ViewportToWorldPoint( new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint( new Vector2(1,1));


		GameObject enemyShip = (GameObject)Instantiate(EnemyShipGO);

		enemyShip.transform.position = new Vector2(Random.Range(min.x+0.3f, max.x-0.3f), max.y);

		//Repeating the spawn method
		NextEnemyShipSpawn();
	}

	void NextEnemyShipSpawn() {

		float spawnInSeconds;

		if(maxSpawnRateInSeconds > 1f) {
			spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
		} else {
			spawnInSeconds = 1f;
		}

		Invoke("SpawnEnemyShip", spawnInSeconds);

	}

	void IncreaseSpawnRate() {

		if(maxSpawnRateInSeconds > 1f) maxSpawnRateInSeconds--;
		EnemyShipGO.GetComponent<EnemyShipControl>().Speed = EnemyShipGO.GetComponent<EnemyShipControl>().Speed + (EnemyShipGO.GetComponent<EnemyShipControl>().Speed * (float)0.05);

		Debug.Log(EnemyShipGO.GetComponent<EnemyShipControl>().Speed);

		if(maxSpawnRateInSeconds == 1f) CancelInvoke("IncreaseSpawnRate");

	}
}
