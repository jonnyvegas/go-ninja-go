using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Enemy") {
			target.gameObject.SetActive(false);
			HUDScript.playerScore += 8.75f;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
