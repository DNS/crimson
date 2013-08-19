var BloodSplat:GameObject;
var MissShot:GameObject;
var Damage:float;
var HitReactionIndex:int[];
var AnimationBehaviourFunction = "PlayerAnimationState";

private var player;
function Start(){

	player = GameObject.FindWithTag("Player");
	Physics.IgnoreCollision(player.collider,gameObject.collider,true);
}

function Update () {

}

function OnCollisionEnter(col:Collision)
{
	var contact : ContactPoint = col.contacts[0];
	var rot : Quaternion = Quaternion.FromToRotation(Vector3.up, contact.normal);
	var pos : Vector3 = contact.point;
	if(col.gameObject.tag == "Enemy")
	{	
		col.gameObject.SendMessage("ApplyDamage", Damage);
		Instantiate(BloodSplat,pos,rot);
	}	
	else if(MissShot)
		Instantiate(MissShot, pos, rot);
	Destroy(gameObject);
}