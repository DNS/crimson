using UnityEngine;
using System.Collections;

public class ZombiesKilled : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		gameObject.guiText.text = "Monster Killed: " + GameplayGlobals.killedZombies + "/" + GameplayGlobals.toNextStageKills;
	}
}
