var Prefab:GameObject;	//ENG: the object that instantce when the object is destroyed
									//ESP: el objeto que vas a instanciar cuando el objeto es destruido
function Start(){
var player = GameObject.FindWithTag("Player");
Physics.IgnoreCollision(player.collider,gameObject.collider,true);
}
function OnCollisionEnter (collision:Collision) {
	var contact = collision.contacts[0];
	//var rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
	var pos = contact.point+Vector3.up;
	Instantiate(Prefab,pos,Quaternion.identity);
	Destroy(gameObject);
}