using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lamp_post_climber : MonoBehaviour 
{

	public input_manager input_manager;
	public GameObject climbingPrompt;


	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			climbingPrompt.SetActive (true);
			input_manager.canClimb = true;
		}
	}


	public void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			climbingPrompt.SetActive (false);
			input_manager.canClimb = false;
		}
	}
		
}
