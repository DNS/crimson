using UnityEngine;
using System.Collections;

public class CharacterLifeMeter : MonoBehaviour 
{
	public int Life;
	public int lifeTemp;
	
	public bool destroyPlayer = true;
	public int enemyScore = 100;
	public int overDamageBonusMultiplier = 5;
	public int overtimeBonusMultiplier = 2;
	public GameObject replacement;
	public int[] deathAnimationsIndex;
	public GameObject wound;
	public AudioClip playerWounded;
	private int deathState;
	
	// Use this for initialization
	void Start () 
	{
		lifeTemp = Life;
		if(gameObject.tag == "Enemy")
			Life *= GameplayGlobals.dificultyMultiplier;
		if(deathAnimationsIndex.Length > 1)
			deathState = deathAnimationsIndex[Random.Range(0, deathAnimationsIndex.Length)];
		else if (deathAnimationsIndex.Length == 1)
			deathState = deathAnimationsIndex[0];
	}
	
	public void FixedUpdate()
	{
		if(gameObject.tag == "Enemy")
		{			
			if(Life <= 0)
			{
				if(Life <- 25)
				{
					if(replacement)
						Instantiate(replacement, transform.position, transform.rotation);
					Destroy(gameObject);
					if(GameplayGlobals.completed)
						GameplayGlobals.cashinPockets += enemyScore * overDamageBonusMultiplier * overtimeBonusMultiplier;
					else
						GameplayGlobals.cashinPockets += enemyScore * overDamageBonusMultiplier;
					GameplayGlobals.fraggedZombies++;
				}
				else
				{		
						if(GetComponent<AIScript>())
							Destroy(GetComponent<AIScript>());
						else
							Destroy(GetComponent<AIScriptAvoidance>());
						Destroy(rigidbody);
						Destroy(collider);
						gameObject.layer = 8;
						if(GameplayGlobals.completed)
							GameplayGlobals.cashinPockets += enemyScore * overtimeBonusMultiplier;
						else
							GameplayGlobals.cashinPockets += enemyScore;
						
						if(deathAnimationsIndex != null)
							gameObject.BroadcastMessage ("PlayerAnimationState", deathState);				
				}
				GameplayGlobals.enemyCount--;
				GameplayGlobals.killedZombies++;
				Destroy(this);
			}
		}
	}
	
	public void ApplyDamage(int lifeRested) 
	{
		Life -= lifeRested;

		if(gameObject.tag == "Player")
		{
			Instantiate(wound, transform.position, transform.rotation);
			if(playerWounded)
				audio.PlayOneShot(playerWounded);
		}
		if(Life <= 0)
		{
			if(gameObject.tag == "Player")
			{
				Destroy(GetComponent("MouseLook"));
				Destroy(GetComponent("Character move"));
				if(deathAnimationsIndex.Length >= 1)
				{
					gameObject.BroadcastMessage("PlayerAnimationState", deathState);
					if(destroyPlayer)
						Destroy(gameObject, 10);
				}
				else
				{	
					Instantiate(replacement, transform.position, transform.rotation);
					Destroy(gameObject);
				}
				Destroy(GetComponent<ConfigurableJoint>());
				Destroy(rigidbody);
				Destroy(collider);
	
			}
			if(gameObject.tag == "Enemy")
				Destroy(gameObject,10);
		}
	}
}
