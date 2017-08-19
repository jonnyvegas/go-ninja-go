using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	GameObject[] pauseObjects;
	GameObject[] finishObjects;
	PlayerDied playerDied;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("Paused");
		HidePaused ();
		finishObjects = GameObject.FindGameObjectsWithTag ("Finished");
		HideFinished ();
		if (Application.loadedLevelName == "Gameplay") {
			playerDied = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerDied> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P) && playerDied.alive) {
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				ShowPaused();
			}
			else if(Time.timeScale == 0 && playerDied.alive)
			{
				Time.timeScale = 1;
				HidePaused ();
			}
		}

		if (Time.timeScale == 0 && !playerDied.alive) {
			ShowFinished ();
		}
	}

	public void Reload()
	{
		SceneManager.LoadScene ("Gameplay");
		HUDScript.playerScore = 0.0f;
	}

	public void PauseControl()
	{
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			ShowPaused ();
		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
			HidePaused ();
		}
	}

	public void ShowPaused()
	{
		foreach (GameObject g in pauseObjects) {
			g.SetActive (true);
		}
	}

	public void HidePaused()
	{
		foreach (GameObject g in pauseObjects) {
			g.SetActive (false);
		}
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
		HUDScript.playerScore = 0.0f;
	}

	public void ShowFinished()
	{
		foreach (GameObject g in finishObjects) {
			g.SetActive (true);
		}
	}

	public void HideFinished()
	{
		foreach (GameObject g in finishObjects) {
			g.SetActive (false);
		}
	}
}
