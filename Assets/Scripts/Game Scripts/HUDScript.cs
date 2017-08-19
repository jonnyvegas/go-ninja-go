using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

	public static float playerScore = 0.0f;
	public static float highScore = 0.0f;
	//private GUIStyle guiStyle = new GUIStyle();
	private bool isAlive;
	public Text scoreText;
	public Text highScoreText;

	// Update is called once per frame
	void Update () {
		if (isAlive) {
			UpdateScore ();
			CheckIfAlive ();
		}
	}

	void UpdateScore(){
		playerScore += Time.deltaTime;
		scoreText.text = "Score: " + ((int) (playerScore * 100) / 35);
		highScoreText.text = "Hi Score: " + ((int)(highScore * 100) / 35);
		if (highScore < playerScore) {
			highScore = playerScore;
			PlayerPrefs.SetInt ("Hi Score", (int)(highScore * 100) / 35);
			PlayerPrefs.Save();
		}
	}

	public void UpdateScore(int theScore)
	{
		playerScore += theScore;
	}
	void Start()
	{
		isAlive = true;
		highScore = PlayerPrefs.GetInt ("Hi Score");
	}

	public void IncreaseScore(int amount)
	{
		playerScore += amount;
	}

	void OnDisable()
	{
		PlayerPrefs.SetInt ("Score", (int)playerScore);
	}

	void OnGUI()
	{
//		guiStyle.fontSize = 50;
//		guiStyle.normal.textColor = Color.black;
//		GUI.Label (new Rect (10, 10, 500, 100), "Score: " + ((int)(playerScore * 100) / 35), guiStyle);
	}

	void CheckIfAlive()
	{
		if (GameObject.FindGameObjectWithTag("Player") == null) {
			isAlive = false;
		}
	}
}
