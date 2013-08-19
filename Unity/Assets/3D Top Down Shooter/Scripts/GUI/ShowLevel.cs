using UnityEngine;
using System.Collections;

public class ShowLevel : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		if(GameplayGlobals.survivalMode)
			gameObject.guiText.text = "Level " + GameplayGlobals.dificultyMultiplier;
		else
			gameObject.guiText.text = "";
	}
}
