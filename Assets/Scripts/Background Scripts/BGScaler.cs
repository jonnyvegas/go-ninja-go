using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var height = Camera.main.orthographicSize * 2f;
		var width = height * Screen.width / Screen.height;

		if (gameObject.name == "Background") {
			transform.localScale = new Vector3 (width, height, 0);
		}
		//ground
		else {
			//width + 3f makes wider than background. 5 is just standard move.
			transform.localScale = new Vector3 (width + 3f, 5, 0);
		}
	}
}
