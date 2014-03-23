using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	public GameObject enemyPrefab;  
	public Transform[] spawnPoints; // a list of transform points that the enemy can spawn at
	public int spawnDelay;//how many frames to wait until a new enemy gets spawned
	public int delayDecay = 5; //how much the spawn delay gets reduced by every time an enemy is spawned
	public GameObject playerObject;

	private int _spawnTimeCounter = 0; 
	
	// Update is called once per frame
	void Update () {
		if(_spawnTimeCounter-- == 0) 
		{
			SpawnObject();
			_spawnTimeCounter = spawnDelay;
		}	
	}

	void SpawnObject()
	{
		GameObject enemy = Instantiate(enemyPrefab,spawnPoints[Random.Range(0,spawnPoints.Length)].position,Quaternion.identity) as GameObject;
		//set the enemy to target the player object
		enemy.GetComponent<FollowTargetScript>().target = playerObject;
		//reduce the spawn delay counter
		spawnDelay = Mathf.Max(spawnDelay-delayDecay,1);
	}
}
