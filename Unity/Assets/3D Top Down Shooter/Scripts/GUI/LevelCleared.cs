using UnityEngine;
using System.Collections;

public class LevelCleared : MonoBehaviour 
{
	public GUIText[] stats;
	public float showTime = 0.5f;
	public int overTimeBonus;
	public int killedZombiesBonusMultiplier;
	public int fraggedZombiesBonusMultiplier;
	public int stageBonusMultiplier;
	private int killedBonus = 0;
	private int fraggedBonus = 0;
	private int stageBonus = 0;
	
	// Use this for initialization
	IEnumerator Start() 
	{
		GlobalStats.Killed += GameplayGlobals.killedZombies;
		GlobalStats.enemiesFragged += GameplayGlobals.fraggedZombies;
		killedBonus = GameplayGlobals.killedZombies * killedZombiesBonusMultiplier;
		fraggedBonus = GameplayGlobals.fraggedZombies * fraggedZombiesBonusMultiplier;
		stageBonus = GlobalStats.Level * stageBonusMultiplier;
		stats[0].text += GameplayGlobals.killedZombies;
		yield return new WaitForSeconds(showTime);
		stats[1].text += GameplayGlobals.fraggedZombies;
		yield return new WaitForSeconds(showTime);
		stats[2].text += killedBonus;
		yield return new WaitForSeconds(showTime);
		stats[3].text += fraggedBonus;
		yield return new WaitForSeconds(showTime);
		if(GameplayGlobals.recieveOvertimeBonus)
			stats[4].text += overTimeBonus;
		else
			stats[4].text += 0;
		yield return new WaitForSeconds(showTime);
		stats[5].text += stageBonus;
		yield return new WaitForSeconds(showTime *  2);
		if(GameplayGlobals.recieveOvertimeBonus)
			GameplayGlobals.cashinPockets += (killedBonus + fraggedBonus + overTimeBonus + stageBonus);
		else
			GameplayGlobals.cashinPockets += (killedBonus + fraggedBonus + stageBonus);
		GlobalStats.totalScore += GameplayGlobals.cashinPockets;
		stats[6].text += GameplayGlobals.cashinPockets;
		yield return new WaitForSeconds(showTime * 2);
		stats[7].text += GlobalStats.totalScore;
		yield return new WaitForSeconds(showTime * 4);
		stats[8].text = "Press Space Bar for go to the next level";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Space))
		{
			GlobalStats.Level++;
			Application.LoadLevel("Stage " + GlobalStats.Level);
			if(GlobalStats.Level == 3)
			{
				GameplayGlobals.RestartGame();
				GlobalStats.ResetStats();
			}
			else
				GameplayGlobals.RestartGameplay();
		}
	}
}
