using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerGO : MonoBehaviour {

	public GameObject PanelPauseGame;

	GameObject playerName;

	private bool isPaused = false;

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
		PlayerPrefs.SetString("PlayerName", inputField.text);

		PlayerPrefs.Save();

		SceneManager.LoadScene("Game");
	}
}
