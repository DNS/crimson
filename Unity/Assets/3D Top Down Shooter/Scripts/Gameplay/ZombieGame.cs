using UnityEngine;
using System.Collections;

public class ZombieGame : MonoBehaviour 
{
	private int objectiveKills;	
	
	void Start () 
	{
		objectiveKills = GameplayGlobals.toNextStageKills * GameplayGlobals.dificultyMultiplier;
	}	
	
	void Update () 
	{
		if(GameplayGlobals.killedZombies >= GameplayGlobals.toNextStageKills && GameplayGlobals.survivalMode == false)
		{	
			GetComponent<SpawnEnemy>().isSpawning=false;
			GameplayGlobals.completed = true;
			if(GameplayGlobals.enemyCount == 0)
				GameplayGlobals.recieveOvertimeBonus = true;
		}
		else if(GameplayGlobals.killedZombies >= GameplayGlobals.toNextStageKills && GameplayGlobals.survivalMode == true)
		{
			GameplayGlobals.dificultyMultiplier++;
			GameplayGlobals.toNextStageKills = objectiveKills * GameplayGlobals.dificultyMultiplier;
		}
	}
}
