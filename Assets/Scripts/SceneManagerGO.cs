using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerGO : MonoBehaviour {

	public GameObject PanelPauseGame;

	GameObject playerName;

	private bool isPaused = false;

	void Start() {

//		Spaceship spaceship = new Spaceship();
//
//		spaceship.id = 1;
//		spaceship.name = "Bananas";
//		spaceship.weapon_force = 1;
//
//		string json = JsonUtility.ToJson(spaceship);
//
//		Debug.Log("Json: " + json);

	}

	/* Function to Load Another Scenes */
	public void LoadScene(string name) {
		SceneManager.LoadScene(name);
	}

	public void PauseGame() {

		isPaused = !isPaused;

		if(isPaused) {
			PanelPauseGame.SetActive(true);
			Time.timeScale = 0;
		} else {
			PanelPauseGame.SetActive(false);
			Time.timeScale = 1;
		}
		
	}

	/* Function to Quit the Game */
	public void QuitGame() {
		Application.Quit();
	}

	public void StartGame(InputField inputField) {
		playerName = GameObject.FindGameObjectWithTag("PlayerNameTag");

		playerName.GetComponent<GamePlayer>().Name = inputField.text;

		Debug.Log("Name On SM: " + playerName.GetComponent<GamePlayer>().Name);

		SceneManager.LoadScene("Game");
	}
}
