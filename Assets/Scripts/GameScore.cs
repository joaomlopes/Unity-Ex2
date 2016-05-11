using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour {

	Text ScoreText;

	int score;

	int highscore;

	public int Score {

		get {
			return this.score;
		}
		set {
			this.score = value;
			UpdateScoreText();
		}
	}

	// Use this for initialization
	void Start () {

		ScoreText = GetComponent<Text>();

		highscore = 0;
	
	}
	
	void UpdateScoreText () {

		string scoreStr = string.Format("{0:000000}", score);

		if(score > highscore) ScoreText.color = Color.yellow;

		ScoreText.text = scoreStr;

	}
}
