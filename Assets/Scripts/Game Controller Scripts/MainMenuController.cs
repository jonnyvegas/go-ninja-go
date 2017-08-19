using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene ("Gameplay");
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
