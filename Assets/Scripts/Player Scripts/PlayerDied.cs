using UnityEngine;
using System.Collections;

public class PlayerDied : MonoBehaviour {

	public delegate void EndGame();
	public static event EndGame endGame;
	public bool alive;

	void PlayerDiedEndGame()
	{
		if (endGame != null) {
			endGame ();
		}
		Destroy (gameObject);
		Time.timeScale = 0;
		alive = false;
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Collector") {
			PlayerDiedEndGame ();
		}
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Enemy") {
			PlayerDiedEndGame ();
		}
		if (target.gameObject.tag == "Collectables") {
			HUDScript.playerScore += 35f;
			target.gameObject.SetActive (false);
		}
	}

	// Use this for initialization
	void Start () {
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
