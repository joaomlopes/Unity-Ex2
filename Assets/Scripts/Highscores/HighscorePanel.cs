using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscorePanel : MonoBehaviour {

	public Text PlayerPosition;
	public Text PlayerName;
	public Text PlayerScore;

	public string Position {
		get {
			return this.PlayerPosition.text;
		}
		set {
			this.PlayerPosition.text = value;
		}
	}

	public string Name {
		get {
			return this.PlayerName.text;
		}
		set {
			this.PlayerName.text = value;
		}
	}
	
	public string Score {
		get {
			return this.PlayerScore.text;
		}
		set {
			this.PlayerScore.text = value;
		}
	}
}
