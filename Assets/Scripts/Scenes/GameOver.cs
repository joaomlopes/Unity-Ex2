using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Text ScoreText;

	// Use this for initialization
	void Start () {
		ScoreText.text = PlayerPrefs.GetInt("GameScore").ToString();		
	}
}
