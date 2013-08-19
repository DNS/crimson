using UnityEngine;
using System.Collections;

public class AIAnimationBehaviour : MonoBehaviour 
{	
	void Start () 
	{
		animation["walk"].layer = -1;
		animation["idle"].layer = -1;
		animation["back"].layer = -1;
		animation["strafe left"].layer = -1;
		animation["strafe right"].layer = -1;
		animation["shoot"].layer = 1;
		animation["shoot"].weight = 1;
		animation["shoot"].blendMode = AnimationBlendMode.Additive;
		animation["shoothard"].layer = 1;
		animation["shoothard"].weight = 1;
		animation["shoothard"].blendMode = AnimationBlendMode.Additive;
		animation["hit"].layer = 2;
		animation["hit"].weight = 1;
		animation["hit"].blendMode = AnimationBlendMode.Additive;
		animation.Stop();
	}
	
	public void PlayerAnimationState(int state) 
	{
		switch(state)
		{
			case 0: animation.CrossFade("idle"); break;
			case 3: animation.CrossFade("walk"); break;
			case 4: animation.CrossFade("back"); break;
			case 5: animation["strafe left"].speed = 1; animation.CrossFade("strafe left"); break;
			case 6: animation["strafe right"].speed = 1; animation.CrossFade("strafe right"); break;
			case 7: animation.Play("shoot"); break;
			case 8: animation.CrossFade("death"); break;
			case 9: animation["strafe left"].speed = -1; animation.CrossFade("strafe left"); break;
			case 10: animation["strafe right"].speed = -1; animation.CrossFade("strafe right"); break;
			case 11: animation.Rewind("hit"); animation.Play("hit"); break;
			case 12: animation.Stop("shoot"); break;
			case 13: animation.Rewind("idle"); animation.Play("shoot"); break;
			case 14: animation["shoothard"].speed = 1.33f; animation.Play("shoothard"); break;
			case 15: animation.Rewind("idle"); animation["shoothard"].speed = 1.33f; animation.Play("shoothard"); break;
			case 16: animation["shoothard"].speed = 0.75f; animation.Play("shoothard"); break;
			case 17: animation.Rewind("idle"); animation["shoothard"].speed = 0.75f; animation.Play("shoothard"); break;
		}
	}
}
