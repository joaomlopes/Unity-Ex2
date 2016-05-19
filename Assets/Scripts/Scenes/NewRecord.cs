using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;
using System.IO;

public class NewRecord : MonoBehaviour {

	public GameObject HighscorePanelGO;

	public Canvas canvas;

	JSONNode highscores;

	// Use this for initialization
	void Start () {

		var N = JSON.Parse(PlayerPrefs.GetString("HighscoresJSON"));

		highscores = N["highscores"];

		OrderHighscores();

		for(int i = 1; i <= 10; i++) {

//			if(highscores[i-1]["score"].AsInt == PlayerPrefs.GetInt("GameScore") && highscores[i-1]["name"] == PlayerPrefs.GetString("PlayerName")) {
			if(highscores[i-1]["score"].AsInt == PlayerPrefs.GetInt("GameScore")) {

				HighscorePanelGO.GetComponent<HighscorePanel>().Position = i + ".";

				HighscorePanelGO.GetComponent<HighscorePanel>().Name = highscores[i-1]["name"];

				HighscorePanelGO.GetComponent<HighscorePanel>().Score = highscores[i-1]["score"];

			}
		} 

	}

	void OrderHighscores() {

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

	}
}
