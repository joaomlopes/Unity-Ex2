using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceshipControl : MonoBehaviour {

	public GameObject GameManagerGO;

	public GameObject SpaceshipBulletGO;

	public GameObject SpaceshipLeftGun;

	public GameObject SpaceshipRightGun;

	public GameObject ExplosionGO;

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Fire bullets when space is pressed
		if(Input.GetKeyDown(KeyCode.Space)) {

			GetComponent<AudioSource>().Play();

			//Create the bullet in the left gun
			GameObject left_bullet = (GameObject)Instantiate(SpaceshipBulletGO);
			left_bullet.transform.position = SpaceshipLeftGun.transform.position;

			//Create the bullet in the right gun
			GameObject right_bullet = (GameObject)Instantiate(SpaceshipBulletGO);
			right_bullet.transform.position = SpaceshipRightGun.transform.position;
		}

		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(x, y).normalized;

		MoveSpaceship(direction);
	}

	void MoveSpaceship(Vector2 direction) {
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

		//Define the min width and height with the spaceship inside
		min.x = min.x + 0.3f;
		min.y = min.y + 0.38f;

		//Define the max width and height with the spaceship inside
		max.x = max.x - 0.3f;
		max.y = max.y - 0.38f;

		//Temp variable to store the new position
		Vector2 pos = transform.position;

		//Calculate the new position
		pos += direction * speed * Time.deltaTime;

		//Make sure that the new position isn't outside the screen
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		//Update Spaceship's position
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D col) {

		if((col.tag == "EnemyShipTag") || (col.tag == "EnemyShipBulletTag")) {

			PlayExplosion();

			GameManagerGO.GetComponent<GameManager>().DecrementLive();

			if(GameManagerGO.GetComponent<GameManager>().isGameOver()) Destroy(gameObject);
		} 

	}

	void PlayExplosion() {

		GameObject explosion = (GameObject)Instantiate(ExplosionGO);

		explosion.transform.position = transform.position;

	}


}
