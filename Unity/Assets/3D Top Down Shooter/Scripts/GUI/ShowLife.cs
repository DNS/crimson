using UnityEngine;
using System.Collections;

public class ShowLife : MonoBehaviour {
	
	private GameObject Player;	
	
	void Start()
	{
		Player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update()
	{
		gameObject.guiText.text = "Life: " + (Player.GetComponent(typeof(CharacterLifeMeter)) as CharacterLifeMeter).Life;
	}
}
