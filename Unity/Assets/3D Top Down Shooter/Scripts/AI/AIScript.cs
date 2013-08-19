using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour 
{
	
	public float enemyDistance = 15;
	public bool canJump = false; //this enemy can jump?
	public bool canShoot = false; //this enemy can shoot?
	public float speed = 4; //enemy speed
	public float maxSpeedVariation = 2;
	public float jumpSpeed = 8; //enemy jumpheight and max jump distance
	public float gravity = 9.81f; //gravity, dont touch it if you dont need it
	public float shootDistance = 5; //distance where the enemy starts to shoot
	public float shootRate = 1; //the shooting rate
	public float attackRate = 1; //melee attack rate
	public float attackDamage = 5; //meleeattackdamage
	public GameObject proyectile; //the proyectile prefab
	public float proyectileVelocity = 5; //proyectile velocity
	public float meleeAttackDistance = 1.2f;//melee attack distance
	public string animationBehaviourFunction = "PlayerAnimationState";
	public int[] attackAnimationsIndex;
	public int[] walkAnimationsIndex;
	public int[] idleAnimationsIndex;
	public int[] shootAnimationsIndex;
	public int[] jumpAnimationsIndex;
	public int[] runAnimationsIndex;
	
	private float actualSpeed = 0;
	private bool isPlayerSeeked = false;
	private bool isShooting = false;
	private int idleState;
	private int attackState;
	private int walkState;
	private int jumpState;
	private int shootState;
	private GameObject player;
	private Vector3 moveDirection = Vector3.zero;
	private bool grounded = false;
	private float flags;
	private float shootTime = 0;
	private float attackTime = 0;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		if(idleAnimationsIndex.Length > 1)
			idleState = idleAnimationsIndex[Random.Range(0, idleAnimationsIndex.Length)];
		else if(idleAnimationsIndex.Length == 1)
			idleState = idleAnimationsIndex[0];
		if(attackAnimationsIndex.Length > 1)
			attackState = attackAnimationsIndex[Random.Range(0, attackAnimationsIndex.Length)];
		else if(attackAnimationsIndex.Length == 1)
			attackState = attackAnimationsIndex[0];
		if(walkAnimationsIndex.Length > 1)
			walkState = walkAnimationsIndex[Random.Range(0, walkAnimationsIndex.Length)];
		else if(walkAnimationsIndex.Length == 1)
			walkState = walkAnimationsIndex[0];	
		if(shootAnimationsIndex.Length > 1)
			shootState = shootAnimationsIndex[Random.Range(0, shootAnimationsIndex.Length)];
		else if(shootAnimationsIndex.Length == 1)
			shootState = shootAnimationsIndex[0];
		if(jumpAnimationsIndex.Length > 1)
			jumpState = jumpAnimationsIndex[Random.Range(0, jumpAnimationsIndex.Length)];
		else if(jumpAnimationsIndex.Length == 1)
			jumpState = jumpAnimationsIndex[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!collider)
		{
			gameObject.BroadcastMessage("RotateCharacter", 0);
			return;
		}
		if(!player || !isPlayerSeeked)
		{
			gameObject.BroadcastMessage(animationBehaviourFunction, idleState);
			actualSpeed = Random.Range(speed + 1, speed * maxSpeedVariation);
		}
		else if(grounded) 
		{
			if(player)
			{	
				if(!isShooting)
				{
					if(actualSpeed <= speed + 1)
						gameObject.BroadcastMessage(animationBehaviourFunction, walkState);
					else if(actualSpeed > speed && actualSpeed < (speed * maxSpeedVariation - 2))
						gameObject.BroadcastMessage(animationBehaviourFunction, runAnimationsIndex[0]);
					else
						gameObject.BroadcastMessage(animationBehaviourFunction, runAnimationsIndex[1]);
					gameObject.BroadcastMessage("RotateCharacter", 2);
					if((player.GetComponent<CharacterLifeMeter>().Life) <= 0)
						player = null;
				}
				if(!player)
					return;
				else
				{
					moveDirection = player.transform.position - transform.position;
					moveDirection = transform.TransformDirection(moveDirection.normalized);
					moveDirection *= actualSpeed;
				}
				if(canJump && jumpAnimationsIndex.Length >= 1)
					if(Vector3.Distance(player.transform.position, transform.position) <= jumpSpeed && 
					   Vector3.Distance(player.transform.position, transform.position) >= jumpSpeed * 0.66f)
					{	
						gameObject.BroadcastMessage(animationBehaviourFunction, jumpState);
						moveDirection.y = jumpSpeed;
					}
				if(canShoot && shootAnimationsIndex.Length >= 1)
						if(Vector3.Distance(player.transform.position, transform.position) <= shootDistance)
						{
							moveDirection = Vector3.zero;
							isShooting = true;
							gameObject.BroadcastMessage("RotateCharacter", 1);
							Shooting();
						}	
						else
							isShooting = false;
				else if(attackAnimationsIndex.Length >= 1)
				{
						if(Vector3.Distance(transform.root.position, player.transform.position) <= meleeAttackDistance)
						{
							moveDirection = Vector3.zero;
							Attacking();
						}
				}
			}
				
		}
		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;
		// Move the controller
		CharacterController controller = GetComponent<CharacterController>();
		if(player)
			if(Vector3.Distance(player.transform.position, transform.position) <= enemyDistance)
				{	
					flags = (float)controller.Move(moveDirection * Time.deltaTime);
					grounded = ((int)flags & (int)CollisionFlags.CollidedBelow) != 0;
					isPlayerSeeked = true;
				}
			else
			{
				isPlayerSeeked = false;
			}
	}
	
	public void Shooting()
	{
		Vector3 shootDirection = player.transform.position - transform.position;
		if(Time.time >= shootTime)
		{
			gameObject.BroadcastMessage(animationBehaviourFunction, shootState);
			if(proyectile)
				Shot(shootDirection);
			shootTime = Time.time + shootRate;
		}
	}
	
	public void Attacking()
	{
		if(Time.time >= attackTime)
		{
			player.SendMessage("ApplyDamage", attackDamage);
			gameObject.BroadcastMessage(animationBehaviourFunction, attackState);
			attackTime = Time.time + attackRate;
		}
			if ((player.GetComponent<CharacterLifeMeter>().Life) <= 0)
				player = null;
	}
	
	public void Shot(Vector3 direction)
	{
		if ((player.GetComponent<CharacterLifeMeter>().Life) <= 0)
				player = null;
		GameObject Proyectile = Instantiate(proyectile, transform.position + Vector3.up, Quaternion.LookRotation(direction)) as GameObject;
		Proyectile.rigidbody.velocity = direction.normalized * proyectileVelocity;
		Physics.IgnoreCollision(Proyectile.collider, transform.root.collider);
	}
}
