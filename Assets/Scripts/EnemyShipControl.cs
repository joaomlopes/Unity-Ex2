using UnityEngine;
using System.Collections;

public class EnemyShipControl : MonoBehaviour {

	GameObject scoreUI;

	public GameObject ExplosionGO;

	public float speed;

	// Use this for initialization
	void Start () {
		scoreUI = GameObject.FindGameObjectWithTag("ScoreTextTag");
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 pos = transform.position;

		pos = new Vector2(pos.x, pos.y - speed * Time.deltaTime);

		transform.position = pos;

		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

		//If the ship went outside the screen, then it gets destroyed
		if(transform.position.y < min.y) {
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D col) {

		if((col.tag == "SpaceshipTag") || (col.tag == "SpaceshipBulletTag")) {

			PlayExplosion();

			Destroy(gameObject);

			scoreUI.GetComponent<GameScore>().Score += 100;

		} 

	}

	void PlayExplosion() {

		GameObject explosion = (GameObject)Instantiate(ExplosionGO);

		explosion.transform.position = transform.position;

	}

}
