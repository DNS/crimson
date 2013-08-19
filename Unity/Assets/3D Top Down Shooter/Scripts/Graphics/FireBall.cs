using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour 
{
	public GameObject BloodSplat;
	public GameObject MissShot;
	public float Damage;
	public int[] HitReactionIndex;
	public string AnimationBehaviourFunction = "PlayerAnimationState";
	
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
		Destroy(gameObject);
	}
}
