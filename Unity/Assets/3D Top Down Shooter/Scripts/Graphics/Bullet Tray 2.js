var BloodSplat:GameObject;
var MissShot:GameObject;
var PlayerDamage:float;
var HitReactionIndex:int[];
var AnimationBehaviourFunction = "PlayerAnimationState";

private var player;
function Start(){
	player=GameObject.FindWithTag("Player");
	Physics.IgnoreCollision(player.collider,gameObject.collider,true);
}

function Update () {
	rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(new Vector3(200 * Time.deltaTime, 0, 0) ));
}

function OnCollisionEnter(col:Collision){
	var contact : ContactPoint = col.contacts[0];
	var rot : Quaternion = Quaternion.FromToRotation(Vector3.up, contact.normal);
	var pos : Vector3 = contact.point;
	if(col.gameObject.tag=="Player")
	{	
		col.gameObject.SendMessage("ApplyDamage", PlayerDamage);
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