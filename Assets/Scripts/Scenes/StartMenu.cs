using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	public Text PlayerName;

	// Use this for initialization
	void Start () {

		//Initialize Highscores
		string json = Resources.Load("highscores").ToString();

		PlayerPrefs.SetString("HighscoresJSON", json);


		//Initialize Player's Name
		PlayerPrefs.SetString("PlayerName", "Player 1");
		PlayerName.text = "Player 1";

		//Save PlayerPrefs
		PlayerPrefs.Save();
	}

}
