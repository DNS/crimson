var BloodSplat:GameObject;
var MissShot:GameObject;
var Damage:float;

function Update () {
Destroy(gameObject,0.5);
}

function OnTriggerEnter(other:Collider){
	/*var contact : ContactPoint = col.contacts[0];
	var rot : Quaternion = Quaternion.FromToRotation(Vector3.up, contact.normal);
	var pos : Vector3 = contact.point;*/
	var relativePos = other.transform.position - transform.position;
	var rotation = Quaternion.LookRotation(relativePos);
	if(other.gameObject.tag=="Enemy")
	{	
		other.gameObject.SendMessage("ApplyDamage",Damage);
		other.gameObject.BroadcastMessage("PlayerAnimationState",Random.Range(12,15));
		Instantiate(BloodSplat,other.transform.position,rotation);
		Destroy(gameObject);
	}
	else if(other.gameObject.tag != "Enemy" && other.gameObject.tag != "Player" && other.gameObject.tag != "Weapon")
	{	if(MissShot)
			Instantiate(MissShot,transform.position,rotation);
		Destroy(gameObject);
	}
}