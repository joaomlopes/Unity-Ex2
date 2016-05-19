using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.IO;
using AssetBundles;

public class SpaceshipControl : MonoBehaviour {

	public GameObject GameManagerGO;

	public GameObject SpaceshipBulletGO;

	public GameObject SpaceshipLeftGun;

	public GameObject SpaceshipRightGun;

	public GameObject ExplosionGO;

	public GameObject ScoreText;

	public float speed;

	public const string AssetBundlesOutputPath = "/AssetBundles/";
	public string assetBundleName;
	string assetName;

	GameObject prefab;

	// Use this for initialization
	IEnumerator Start ()
	{
		yield return StartCoroutine(Initialize() );
		
		// Load asset.
		yield return StartCoroutine(InstantiateGameObjectAsync (assetBundleName, assetName) );
	}
	
	// Update is called once per frame
	void Update () {

		//Fire bullets when space is pressed
		if(Input.GetKeyDown(KeyCode.Space)) {

			GetComponent<AudioSource>().Play();

			//Create the bullet in the left gun
			GameObject left_bullet = (GameObject)Instantiate(prefab);
			left_bullet.transform.position = SpaceshipLeftGun.transform.position;

			//Create the bullet in the right gun
			GameObject right_bullet = (GameObject)Instantiate(prefab);
			right_bullet.transform.position = SpaceshipRightGun.transform.position;
		}

		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(x, y).normalized;

		MoveSpaceship(direction);
	}

	void MoveSpaceship(Vector2 direction) {
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

		//Define the min width and height with the spaceship inside
		min.x = min.x + 0.3f;
		min.y = min.y + 0.38f;

		//Define the max width and height with the spaceship inside
		max.x = max.x - 0.3f;
		max.y = max.y - 0.38f;

		//Temp variable to store the new position
		Vector2 pos = transform.position;

		//Calculate the new position
		pos += direction * speed * Time.deltaTime;

		//Make sure that the new position isn't outside the screen
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		//Update Spaceship's position
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D col) {

		if((col.tag == "EnemyShipTag") || (col.tag == "EnemyShipBulletTag")) {

			PlayExplosion();

			GameManagerGO.GetComponent<GameManager>().DecrementLive();

			if(GameManagerGO.GetComponent<GameManager>().isGameOver()) {

				PlayerPrefs.SetInt("GameScore", ScoreText.GetComponent<GameScore>().Score);

				PlayerPrefs.Save();

			 	Destroy(gameObject);

//			 	Invoke("ChangeScene", 2.0f);

				ChangeScene();

			}
		} 

	}

	void PlayExplosion() {

		GameObject explosion = (GameObject)Instantiate(ExplosionGO);

		explosion.transform.position = transform.position;

	}


	void ChangeScene() {

	 	if(ScoreText.GetComponent<GameScore>().isHighscore()) {

	 		 UpdateHighscores();

			 SceneManager.LoadScene("NewRecord");

		} else {

	 		SceneManager.LoadScene("GameOver");

	 	}

	}

	void UpdateHighscores() {

		JSONNode highscores;

		var N = JSON.Parse(PlayerPrefs.GetString("HighscoresJSON"));

		highscores = N["highscores"];

		//Block to Order Highscores

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

		//Block to Order Highscores

		highscores[9]["name"] = PlayerPrefs.GetString("PlayerName").ToString();
		highscores[9]["score"] = PlayerPrefs.GetInt("GameScore").ToString();


		N["highscores"] = highscores;

		File.WriteAllText("Assets/Resources/highscores.json", N.ToString());

		PlayerPrefs.SetString("HighscoresJSON", N.ToString());

		PlayerPrefs.Save();

	}

	// Initialize the downloading url and AssetBundleManifest object.
	protected IEnumerator Initialize()
	{
		// Don't destroy this gameObject as we depend on it to run the loading script.
//		DontDestroyOnLoad(gameObject);

		if(PlayerPrefs.GetString("GunSelected") == null) {
			//Initialize Spaceship Gun
			PlayerPrefs.SetString("GunSelected", "air");
			PlayerPrefs.Save();
		}

		if(Time.timeScale == 0) Time.timeScale = 1;

		assetName = PlayerPrefs.GetString("GunSelected");

		Debug.Log(assetName);


		// With this code, when in-editor or using a development builds: Always use the AssetBundle Server
		// (This is very dependent on the production workflow of the project. 
		// 	Another approach would be to make this configurable in the standalone player.)
		#if DEVELOPMENT_BUILD || UNITY_EDITOR
		AssetBundleManager.SetDevelopmentAssetBundleServer ();
		#else
		// Use the following code if AssetBundles are embedded in the project for example via StreamingAssets folder etc:
		AssetBundleManager.SetSourceAssetBundleURL(Application.dataPath + "/");
		// Or customize the URL based on your deployment or configuration
		//AssetBundleManager.SetSourceAssetBundleURL("http://www.MyWebsite/MyAssetBundles");
		#endif

		// Initialize AssetBundleManifest which loads the AssetBundleManifest object.
		var request = AssetBundleManager.Initialize();
		if (request != null)
			yield return StartCoroutine(request);

	}

	protected IEnumerator InstantiateGameObjectAsync (string assetBundleName, string assetName)
	{
		// This is simply to get the elapsed time for this phase of AssetLoading.
		float startTime = Time.realtimeSinceStartup;

		// Load asset from assetBundle.
		AssetBundleLoadAssetOperation request = AssetBundleManager.LoadAssetAsync(assetBundleName, assetName, typeof(GameObject) );

		if (request == null)
			yield break;
		yield return StartCoroutine(request);

		// Get the asset.
		prefab = request.GetAsset<GameObject> ();

		if (prefab != null)
			PlayerPrefs.SetInt("SpaceshipBulletDamage", prefab.GetComponent<SpaceshipBullet>().Damage);


		// Calculate and display the elapsed time.
		float elapsedTime = Time.realtimeSinceStartup - startTime;
		Debug.Log(assetName + (prefab == null ? " was not" : " was")+ " loaded successfully in " + elapsedTime + " seconds" );
	}


}
