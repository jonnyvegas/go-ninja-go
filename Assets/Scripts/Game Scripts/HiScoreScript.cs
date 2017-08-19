using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiScoreScript : MonoBehaviour {

	public Text highScoreText;
	float highScore = 0;
	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("Hi Score");
		highScoreText.text = "Hi Score: " + ((int)(highScore * 100) / 35);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
