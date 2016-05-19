using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;

public class PrintHighscores : MonoBehaviour {

	public GameObject HighscoresManagerGO;

	public GameObject HighscorePanelGO;

	public Canvas canvas;

	JSONNode _highscores;

	// Use this for initialization
	void Start() {
		var N = JSON.Parse(PlayerPrefs.GetString("HighscoresJSON"));

		_highscores = N["highscores"];

		_highscores = HighscoresManagerGO.GetComponent<HighscoresManager>().OrderHighscores(_highscores);

		PrintTableHighscores();
	}

	void PrintTableHighscores () {
		for(int i = 1; i <= 10; i++) {

			GameObject highscorePanel = (GameObject)Instantiate(HighscorePanelGO);

			highscorePanel.transform.position = new Vector2(0, -40*i);

			highscorePanel.transform.SetParent(canvas.transform, false);

			highscorePanel.GetComponent<HighscorePanel>().Position = i + ".";

			highscorePanel.GetComponent<HighscorePanel>().Name = _highscores[i-1]["name"];

			highscorePanel.GetComponent<HighscorePanel>().Score = _highscores[i-1]["score"];

		} 

	}
}
