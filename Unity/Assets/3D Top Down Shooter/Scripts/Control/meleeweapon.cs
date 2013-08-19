using UnityEngine;
using System.Collections;

public class meleeweapon : MonoBehaviour {
	
	// Mehtod of use: Put this script in a weapon that the player will use, this object must have a trigger collider
	public Animation meleeatackanim; //Animation that plays the player
	public string meleeatackanimname; //Animation Name
	public Vector2 Timelineattack; //Determines where in animation time (in seconds) the melee attack animation deal damage, put 0 in the "Y" value for do the damage until animation ends
	public int Damage;//Damage that deals the atack
	//var MeleeButtonName:String;//Button that you use for do a melee Attack	
	
	private bool dealdamage;	
	
	// Update is called once per frame
	void Update()
	{
		if(meleeatackanim[meleeatackanimname].time>=Timelineattack.x * Time.deltaTime && Timelineattack.y==0)
			dealdamage=true;
		else if(meleeatackanim[meleeatackanimname].time>=Timelineattack.x * Time.deltaTime && meleeatackanim[meleeatackanimname].time<=Timelineattack.y * Time.deltaTime)
			dealdamage=true;
		else
			dealdamage=false;
	}
	
	public void Strike()
	{
		if(!meleeatackanim.IsPlaying(meleeatackanimname))
			meleeatackanim.Play(meleeatackanimname);	
	}
	
	public void OnTriggerEnter(Collider col)
	{
		if(dealdamage && col.gameObject.tag =="Enemy")
			col.gameObject.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
	}
}
