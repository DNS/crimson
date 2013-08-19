using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {
	
	public GameObject BloodSplat;
	public GameObject MissShot;
	public float Damage;
	public int[] HitReactionIndex;
	public string AnimationBehaviourFunction = "PlayerAnimationState";	
	public ParticleAnimator pa;
	
	void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Physics.IgnoreCollision(player.collider, gameObject.collider);		
	}	
	
	void OnCollisionEnter(Collision col)
	{
		ContactPoint contact = col.contacts[0];
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		if(col.gameObject.tag=="Enemy")
		{	
			col.gameObject.SendMessage("ApplyDamage",Damage);
			if(HitReactionIndex.Length==1)
				col.gameObject.BroadcastMessage(AnimationBehaviourFunction,HitReactionIndex[0]);
			else
				col.gameObject.BroadcastMessage(AnimationBehaviourFunction,Random.Range(HitReactionIndex[0],HitReactionIndex.Length));
			Instantiate(BloodSplat,pos,rot);
		}	
		else if(MissShot)
			Instantiate(MissShot,pos,rot);
		particleEmitter.emit = false;
		particleEmitter.minEnergy = 0.5f;
		particleEmitter.maxEnergy = 0.5f;		
		particleEmitter.rndVelocity = new Vector3(2, 2, 2);
		particleEmitter.Emit();
		pa.autodestruct = true;
		/*if(col.gameObject.tag != "Player")
			Destroy(gameObject);*/
	}
}
