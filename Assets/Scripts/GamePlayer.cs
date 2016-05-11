using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayer : MonoBehaviour {

	string _name;

	public string Name {

		get {
			return _name;
		}
		set {
			_name = value;
		}
	}

}
