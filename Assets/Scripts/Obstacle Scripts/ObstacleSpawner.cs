using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] obstacles;
	private List<GameObject> obstaclesForSpawning = new List<GameObject>();

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnRandomObstacle ());
	}

	void Awake(){
		InitializeObstacles ();
	}

	void InitializeObstacles()
	{
		int index = 0;
		for (int i = 0; i < obstacles.Length * 3; i++) {
			GameObject obj = Instantiate (obstacles [index], new Vector3 (transform.position.x,
				transform.position.y, 1), Quaternion.identity) as GameObject;
			obstaclesForSpawning.Add (obj);
			obstaclesForSpawning [i].SetActive (false);
			index++;
			if (index == obstacles.Length) {
				index = 0;
			}
		}
	}

	void Shuffle()
	{
		for (int i = 0; i < obstaclesForSpawning.Count; i++) {
			GameObject temp = obstaclesForSpawning [i];
			int rand = Random.Range (i, obstaclesForSpawning.Count);
			obstaclesForSpawning [i] = obstaclesForSpawning [rand];
			obstaclesForSpawning [rand] = temp;
		}
	}

	IEnumerator SpawnRandomObstacle()
	{
		yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));
		int index = Random.Range (0, obstaclesForSpawning.Count);
		bool looping = true;
		while (looping) {
			if (!obstaclesForSpawning [index].activeInHierarchy) {
				obstaclesForSpawning [index].SetActive (true);
				obstaclesForSpawning [index].transform.position = new Vector3 (transform.position.x, transform.position.y, 1);
				looping = false;
			} else {
				index = Random.Range(0, obstaclesForSpawning.Count);
			}
		}
		StartCoroutine(SpawnRandomObstacle());
			
	}

	// Update is called once per frame
	void Update () {
	
	}
}
