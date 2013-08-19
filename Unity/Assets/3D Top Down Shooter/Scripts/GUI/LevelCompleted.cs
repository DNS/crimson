using UnityEngine;
using System.Collections;

public class LevelCompleted : MonoBehaviour 
{
	public int overtime = 15;
	private float timer = 0;
	
	// Update is called once per frame
	void Update () 
	{
		if(GameplayGlobals.completed)
		{
			if(GameplayGlobals.enemyCount == 0)
				guiText.text = "Zone Cleared, wait for the copter";
			else
				guiText.text = " Objetive Completed!!! \n In " + overtime + " seconds, a Helicopter will arrive. \n Clear the zone meanwhile...";
			timer += Time.deltaTime;
			if(timer >= overtime)
				Application.LoadLevel("Level Cleared");
		}
	}
}
