using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{	
	// Update is called once per frame
	void Update () 
	{
		gameObject.guiText.text = "Score: " + GameplayGlobals.cashinPockets;
	}
}
