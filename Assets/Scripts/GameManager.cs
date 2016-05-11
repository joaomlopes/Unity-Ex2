using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	float _lives;

	public Image live1;
	public Image live2;
	public Image live3;
	public Image live4;
	public Image live5;

	public GameObject scoreText;

	void Start() {

		_lives = 5;

		DrawHeartsByLives();

		scoreText.GetComponent<GameScore>().Score = 0;

		Time.timeScale = 1;


	}

	public void DecrementLive() {
		_lives--;

		DrawHeartsByLives();

	}

	public bool isGameOver() {

		if(_lives == 0) return true;


		return false;

	}

	void DrawHeartsByLives() {

		if(_lives == 1) {

			live1.sprite = Resources.Load<Sprite>("full-heart");
			live2.sprite = Resources.Load<Sprite>("no-heart");
			live3.sprite = Resources.Load<Sprite>("no-heart");
			live4.sprite = Resources.Load<Sprite>("no-heart");
			live5.sprite = Resources.Load<Sprite>("no-heart");

		} else if(_lives == 2) {

			live1.sprite = Resources.Load<Sprite>("full-heart");
			live2.sprite = Resources.Load<Sprite>("full-heart");
			live3.sprite = Resources.Load<Sprite>("no-heart");
			live4.sprite = Resources.Load<Sprite>("no-heart");
			live5.sprite = Resources.Load<Sprite>("no-heart");

		} else if(_lives == 3) {

			live1.sprite = Resources.Load<Sprite>("full-heart");
			live2.sprite = Resources.Load<Sprite>("full-heart");
			live3.sprite = Resources.Load<Sprite>("full-heart");
			live4.sprite = Resources.Load<Sprite>("no-heart");
			live5.sprite = Resources.Load<Sprite>("no-heart");

		} else if(_lives == 4) {

			live1.sprite = Resources.Load<Sprite>("full-heart");
			live2.sprite = Resources.Load<Sprite>("full-heart");
			live3.sprite = Resources.Load<Sprite>("full-heart");
			live4.sprite = Resources.Load<Sprite>("full-heart");
			live5.sprite = Resources.Load<Sprite>("no-heart");

		} else if(_lives == 5) {

			live1.sprite = Resources.Load<Sprite>("full-heart");
			live2.sprite = Resources.Load<Sprite>("full-heart");
			live3.sprite = Resources.Load<Sprite>("full-heart");
			live4.sprite = Resources.Load<Sprite>("full-heart");
			live5.sprite = Resources.Load<Sprite>("full-heart");

		} else if(_lives < 1) {

			live1.sprite = Resources.Load<Sprite>("no-heart");
			live2.sprite = Resources.Load<Sprite>("no-heart");
			live3.sprite = Resources.Load<Sprite>("no-heart");
			live4.sprite = Resources.Load<Sprite>("no-heart");
			live5.sprite = Resources.Load<Sprite>("no-heart");

		}
	}
	
}
