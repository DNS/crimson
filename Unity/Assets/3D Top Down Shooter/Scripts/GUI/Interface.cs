using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour 
{
	public GUIStyle movementRound;
	public GUIStyle joystick;
	public GUIStyle heroback;
	public GUIStyle hp;
	public GUIStyle mp;
	public GUIStyle heroshadow;
	
	private float hpCount = 220;
	private float mpCount = 220;
	private float hpPerPixel;
	
	GameObject Player;
	
	void Start()
	{
		Player = GameObject.FindWithTag("Player");
		
		hpPerPixel = (Player.GetComponent(typeof(CharacterLifeMeter)) as CharacterLifeMeter).Life / 220f;
	}
	
	void Update()
	{
		hpCount =  (Player.GetComponent(typeof(CharacterLifeMeter)) as CharacterLifeMeter).Life / hpPerPixel;
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, 354, 169), GUIContent.none, heroback);
		GUI.Box(new Rect(100, 31, hpCount, 20), GUIContent.none, hp);
		GUI.Box(new Rect(100, 54, mpCount, 20), GUIContent.none, mp);
		GUI.Box(new Rect(100, 31, 220, 42), GUIContent.none, heroshadow);
		
		GUI.Box(new Rect(0, Screen.height - 220, 220, 220), GUIContent.none, movementRound);
		GUI.Box(new Rect(36, Screen.height - 184, 148, 148), GUIContent.none, joystick);		
	}
}
