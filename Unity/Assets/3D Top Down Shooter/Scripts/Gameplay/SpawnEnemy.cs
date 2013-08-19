using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour 
{
	public bool isSpawning = false;
	public float timeSpawnMin = 5;
	public float timeSpawnMax = 10;
	public GameObject[] enemyPrefab;
	private float timeNow;
	private float timeSpawn;

	void Start () 
	{
		timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);
	}	

	void FixedUpdate () 
	{		
		if(isSpawning == true)
		{
			timeNow += Time.deltaTime;
			
			if(timeNow >= timeSpawn)
				StartCoroutine(Spawning());
		}
		else	
			timeNow = 0;
	}
	
	IEnumerator Spawning()
	{
		if(GameplayGlobals.enemyCount < GameplayGlobals.enemyLimit)
		{		
			GameObject[] gos = GameObject.FindGameObjectsWithTag("EnemySpawn");	
			int r = Random.Range(0, enemyPrefab.Length);
			Instantiate(enemyPrefab[r],
			                       gos[Random.Range(0, gos.Length)].transform.position + new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)),
			                       enemyPrefab[r].transform.rotation);
			GameplayGlobals.enemyCount++;	
		}
		else
		{
			if(GameplayGlobals.enemyCount == 0)
				isSpawning = false;
		}
		
		timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax) * (1 / GameplayGlobals.dificultyMultiplier);
		timeNow = 0;
		yield return null;
	}
}
