using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
	public bool showCursor = true;
	public float shotVelocity;
	public int shotGunShells;
	
	public AudioClip pistolShot;
	public AudioClip smgShot;
	public AudioClip shotGunshot;
	public AudioClip flameThrower;
	public AudioClip fleshImpact;
	public AudioClip missShot;
	
	public GameObject bloodSplat;
	public GameObject shellPrefab;
	
	private float accuracy = 0;
	private float fireRate = 0.25f;
	private float nextFire = 0;
	private GameObject player;
	public GameObject meteor;
	public GameObject spear;
	
	public GUIStyle attack1;
	public GUIStyle attack2;
	public GUIStyle attack3;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		SetUpsmg();
		Screen.showCursor = showCursor;
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width - 130, Screen.height - 130, 120, 120), GUIContent.none, attack1))
		{SetUpsmg(); Shotsmg();}
		if(GUI.Button(new Rect(Screen.width - 185, Screen.height - 175, 80, 80), GUIContent.none, attack2))
		{SetUpBow(); ShotSpear();}
		if(GUI.Button(new Rect(Screen.width - 210, Screen.height - 100, 80, 80), GUIContent.none, attack2))
		{SetUpBow(); Meteorite();}
	}
	
	private void Shotsmg()
	{
		if(Time.time > nextFire)
		{
			GameObject Shell = Instantiate(shellPrefab, transform.position, transform.rotation) as GameObject;
			Shell.rigidbody.AddRelativeForce(new Vector3(Random.Range(-accuracy, accuracy), 0, shotVelocity));
			if(smgShot)
				audio.PlayOneShot(smgShot);
			nextFire = Time.time + fireRate;
		}
	}
	
	private void ShotSpear()
	{
		if(Time.time > nextFire)
		{			
			GameObject Shell = Instantiate(spear,transform.position,transform.rotation) as GameObject;
			Shell.rigidbody.AddRelativeForce(new Vector3(Random.Range(-accuracy,accuracy),0,shotVelocity));			
			nextFire = Time.time+fireRate;
		}		
	}
	
	private void Meteorite()
	{
		if(Time.time > nextFire)
		{
			Vector3 p1;
			RaycastHit hit; 
			Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);	
			Physics.Raycast(ray1, out hit, 1000);
			p1 = hit.point;
			GameObject Shell = Instantiate(meteor,new Vector3(transform.position.x, transform.position.y + 20, transform.position.z), transform.rotation) as GameObject;
			Shell.transform.LookAt(new Vector3(p1.x, transform.position.y, p1.z));
			Shell.rigidbody.AddRelativeForce(new Vector3(Random.Range(-accuracy,accuracy),0,shotVelocity));			
			nextFire = Time.time+fireRate;
		}		
	}
	
	private void SetUpsmg()
	{
		accuracy = 250;
		fireRate = 0.1f;
	}
	
	private void SetUpBow()
	{
		accuracy = 0;
		fireRate = 1f;
	}
}
