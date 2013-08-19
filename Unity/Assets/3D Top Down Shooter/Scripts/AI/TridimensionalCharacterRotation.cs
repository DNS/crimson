using UnityEngine;
using System.Collections;

public class TridimensionalCharacterRotation : MonoBehaviour 
{
	private Vector3 LastPosition = Vector3.zero;
	private Vector3 ActualPosition = Vector3.zero;
	private GameObject player;	
	
	void Start() 
	{
		player = GameObject.FindWithTag("Player");
	}
	
	public void RotateCharacter(int rotateType) 
	{
		if(rotateType == 2)
		{
			ActualPosition = transform.position;
			ActualPosition.y = 0;

			if(LastPosition != ActualPosition)
			{
				Quaternion moveRotation = Quaternion.LookRotation(ActualPosition - LastPosition);
				transform.rotation = Quaternion.Slerp(transform.rotation, moveRotation, 10 * Time.deltaTime);
			}
			LastPosition = transform.position;
			LastPosition.y = 0;
		}
		
		else if(rotateType == 1)
			transform.LookAt(player.transform);
	}
}
