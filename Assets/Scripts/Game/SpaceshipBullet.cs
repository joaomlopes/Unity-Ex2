﻿using UnityEngine;
using System.Collections;

public class SpaceshipBullet : MonoBehaviour {

	public int speed;

	public int damage;

	public int Speed {

		get {
			return this.speed;
		}

		set {
			this.speed = value;
		}

	}

	public int Damage {

		get {
			return this.damage;
		}

		set {
			this.damage = value;
		}
	}

	void Start() {

	}

	// Update is called once per frame
	void Update () {

		Vector2 pos = transform.position;

		pos = new Vector2(pos.x, pos.y + speed * Time.deltaTime);

		transform.position = pos;

		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		if(transform.position.y > max.y) {
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D col) {

		if(col.tag == "EnemyShipTag") {
			Destroy(gameObject);
		} 

	}
}
