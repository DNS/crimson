using UnityEngine;
using System.Collections;

public class AIEnemyAnimationBehaviour : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		animation["walk1"].layer = -1;
		animation["idle1"].layer = -1;
		animation["attack1"].layer = -1;
		animation["run1"].layer = -1;
		animation["run2"].layer = -1;
		animation["hit1"].layer = 10;
		animation["hit1"].weight = 1;
		animation["hit1"].blendMode = AnimationBlendMode.Additive;
		animation.Stop();
	}
	
	public void PlayerAnimationState (int state) 
	{
		switch(state)
			{
				case 0: animation.CrossFade("idle1"); break;
				case 1: animation.CrossFade("idle2"); break;
				case 2: animation.CrossFade("idle3"); break;
				case 3: animation.CrossFade("walk1"); break;
				case 4: animation.CrossFade("walk2"); break;
				case 5: animation.Play("attack1"); break;
				case 6: animation.Play("attack2"); break;
				case 7: animation.Play("death1"); break;
				case 8: animation.Play("death2"); break;
				case 9: animation.Play("death3"); break;
				case 10: animation.CrossFade("run1"); break;
				case 11: animation.CrossFade("run2"); break;
				case 12: animation.Rewind("hit1"); animation.Play("hit1"); break;
				case 13: animation.Rewind("hit2"); animation.Play("hit2"); break;
				case 14: animation.Rewind("hit3"); animation.Play("hit3"); break;
			}
	}
}
