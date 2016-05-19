using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BundlesManager : MonoBehaviour {


	void Start() {

		switch(PlayerPrefs.GetString("GunSelected")) {

			case "air":

				break;

			case "earth":

				break;

			case "fire":

				break;

			case "grass":

				break;

			case "ocean":

				break;

			case "rock":

				break;

		}

	}

	public void SelectGun(string gun) {

//		Text button = gameObject.GetComponentsInChildren<Text>();

//		button.text = "SELECTED";

		PlayerPrefs.DeleteKey("GunSelected");

		PlayerPrefs.SetString("GunSelected", gun);

		PlayerPrefs.Save();

		Debug.Log("Gun: " + PlayerPrefs.GetString("GunSelected"));
	}

}