using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;
using UnityEngine.UI;

public class HighscoresManager : MonoBehaviour {

	JSONNode _highscores;

	// Use this for initialization
	void Start () {

		var N = JSON.Parse(PlayerPrefs.GetString("HighscoresJSON"));

		_highscores = N["highscores"];

		OrderHighscores();

	}

	void OrderHighscores() {

		JSONNode tmpHighscores = new JSONNode();

		for(int i = 0; i < 10; i++) {

			for(int j = i+1; j < 10; j++) {

				if(_highscores[j]["score"].AsInt > _highscores[i]["score"].AsInt) {

					tmpHighscores = _highscores[i];

					_highscores[i] = _highscores[j];

					_highscores[j] = tmpHighscores;

				}

			}
		}

	}

	public JSONNode OrderHighscores(JSONNode highscores) {

		JSONNode tmpHighscores = new JSONNode();

		for(int i = 0; i < 10; i++) {

			for(int j = i+1; j < 10; j++) {

				if(highscores[j]["score"].AsInt > highscores[i]["score"].AsInt) {

					tmpHighscores = highscores[i];

					highscores[i] = highscores[j];

					highscores[j] = tmpHighscores;

				}

			}
		}

		return highscores;
	}

	public int GetLowestScore() {
		Start();
		return _highscores[9]["score"].AsInt;
	}

	public int GetHighestScore() {
		Start();
		return _highscores[0]["score"].AsInt;
	}

}
