using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class GameScore : MonoBehaviour {

	public GameObject HighscoreManagerGO;

	Text ScoreText;

	int _score;

	int highscore;

	public int Score {

		get {
			return _score;
		}
		set {
			_score = value;
			UpdateScoreText();
		}
	}

	// Use this for initialization
	void Start () {

		ScoreText = GetComponent<Text>();

		highscore = HighscoreManagerGO.GetComponent<HighscoresManager>().GetLowestScore();
	
	}
	
	void UpdateScoreText () {

		string scoreStr = string.Format("{0:000000}", _score);

		if(isHighscore()) ScoreText.color = Color.yellow;

		ScoreText.text = scoreStr;

	}

	public bool isHighscore() {

		if(_score > highscore) { return true; }

		return false;
	}

	public void PlaySound() {

		GetComponent<AudioSource>().Play();

	}

}
