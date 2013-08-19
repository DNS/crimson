using UnityEngine;
using System.Collections;

public class CharacterRotation : MonoBehaviour 
{
	private CharacterLifeMeter characterLife;
	private Vector3 centerScreen;
	private Vector3 rotator;
	
	void Start()
	{
		characterLife = GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(CharacterLifeMeter)) as CharacterLifeMeter;
	}
	void Update () 
	{
		if(characterLife.Life > 0)
		{
			centerScreen = new Vector3(Screen.width * 0.5f, 0, Screen.height * 0.5f);
			rotator = Input.mousePosition;
			rotator.z = rotator.y;
			rotator.y = 0;
			Vector3 inputRotation = rotator - centerScreen;
			transform.rotation = Quaternion.LookRotation(inputRotation);
		}
	}
}
