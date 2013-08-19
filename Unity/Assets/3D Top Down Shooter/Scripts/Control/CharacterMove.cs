using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class CharacterMove : MonoBehaviour 
{
	public float speed = 6;
	public float strafeSpeedReduction = 0.7f;
	public float backSpeedReduction = 0.5f;
	public float gravity = 20;
	public float directionDiff = 15;
	public CharacterLifeMeter characterLife;
	public int characterIdleStateAnim;
	public int[] characterMoveAnimIndexes;
	public int hardShotAnim;
	public int idleHardShotAnim;
	public int loopShotAnim;
	public int idleLoopShotAnim;
	public int singleShotAnim;
	public int idleSingleShotAnim;
	public int stopAnim;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 moveDirection2 = Vector3.zero;
	private Quaternion direction = Quaternion.identity;
	private float finalSpeed = 0;
	private float angle;
	
	// Update is called once per frame
	void Update () 
	{
		if(characterLife.Life > 0)
		{
			var aimDirection = GameObject.FindWithTag("playerDirection");
			direction = aimDirection.transform.rotation;
			
			if(moveDirection2 != Vector3.zero)
			{
				Quaternion CharacterDirection = Quaternion.LookRotation(moveDirection2);
				angle = Quaternion.Angle(direction, CharacterDirection);
			}
			if(angle >= 90 - directionDiff && angle < 90 + directionDiff && moveDirection2 != Vector3.zero)
			{
				if(Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)
					;//gameObject.BroadcastMessage("PlayerAnimationState", characterMoveAnimIndexes[6], SendMessageOptions.DontRequireReceiver);	
				else
					;//gameObject.BroadcastMessage("PlayerAnimationState", characterMoveAnimIndexes[7], SendMessageOptions.DontRequireReceiver);
				finalSpeed = speed * strafeSpeedReduction;
			}
			else if(angle >= 45 - directionDiff && angle < 45 + directionDiff && moveDirection2 != Vector3.zero)
			{
				if(Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)
					;//gameObject.BroadcastMessage("PlayerAnimationState", characterMoveAnimIndexes[2], SendMessageOptions.DontRequireReceiver);	
				else
					;//gameObject.BroadcastMessage("PlayerAnimationState", characterMoveAnimIndexes[3], SendMessageOptions.DontRequireReceiver);
				finalSpeed = speed;
			}
			else if(angle >= 135 - directionDiff && angle < 135 + directionDiff && moveDirection2 != Vector3.zero)
			{
				if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
					;//gameObject.BroadcastMessage("PlayerAnimationState", characterMoveAnimIndexes[4], SendMessageOptions.DontRequireReceiver);	
				else
					;//gameObject.BroadcastMessage("PlayerAnimationState", characterMoveAnimIndexes[5], SendMessageOptions.DontRequireReceiver);	
				finalSpeed = speed * backSpeedReduction;
			}
			else if(angle >= 0 && angle < directionDiff && moveDirection2 != Vector3.zero)
			{
				;//gameObject.BroadcastMessage("PlayerAnimationState", characterMoveAnimIndexes[0], SendMessageOptions.DontRequireReceiver);
				finalSpeed = speed;
			}
			else if(angle <= 180 && angle > angle - directionDiff && moveDirection2 != Vector3.zero)
			{
				;//gameObject.BroadcastMessage ("PlayerAnimationState", characterMoveAnimIndexes[1], SendMessageOptions.DontRequireReceiver);
				finalSpeed = speed * backSpeedReduction;
			}
			else if(moveDirection2 == Vector3.zero)
				;//gameObject.BroadcastMessage("PlayerAnimationState", characterIdleStateAnim, SendMessageOptions.DontRequireReceiver);
			
			if(GameplayGlobals.weaponType == 1 || GameplayGlobals.weaponType == 3 || GameplayGlobals.weaponType == 4)
			{	
				if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetButton("Fire1"))
					;//gameObject.BroadcastMessage("PlayerAnimationState", idleLoopShotAnim, SendMessageOptions.DontRequireReceiver);
				else if(Input.GetButton("Fire1"))
					;//gameObject.BroadcastMessage("PlayerAnimationState", loopShotAnim, SendMessageOptions.DontRequireReceiver);
				else
					;//gameObject.BroadcastMessage("PlayerAnimationState", stopAnim, SendMessageOptions.DontRequireReceiver);
			}
			else if(GameplayGlobals.weaponType ==2)
			{	
				if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetButton("Fire1"))
					;//gameObject.BroadcastMessage("PlayerAnimationState", idleSingleShotAnim, SendMessageOptions.DontRequireReceiver);
				else	if(Input.GetButton("Fire1"))
					;//gameObject.BroadcastMessage("PlayerAnimationState", singleShotAnim, SendMessageOptions.DontRequireReceiver);
				else
					;//gameObject.BroadcastMessage("PlayerAnimationState", stopAnim, SendMessageOptions.DontRequireReceiver);
			}	
			else if(GameplayGlobals.weaponType == 5)
			{	
				if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetButton("Fire1"))
					;//gameObject.BroadcastMessage ("PlayerAnimationState", idleHardShotAnim, SendMessageOptions.DontRequireReceiver);
				else	if(Input.GetButton("Fire1"))
					;//gameObject.BroadcastMessage("PlayerAnimationState", hardShotAnim, SendMessageOptions.DontRequireReceiver);
				else
					;//gameObject.BroadcastMessage("PlayerAnimationState", stopAnim, SendMessageOptions.DontRequireReceiver);
			}
			
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection2 = moveDirection;
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= finalSpeed;
			moveDirection.y -= gravity;
			
			CharacterController controller = GetComponent(typeof(CharacterController)) as CharacterController;
			CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
		}
	}
}
