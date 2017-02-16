using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lamp_post_climber : MonoBehaviour 
{

	public input_manager inputManager;
	public GameObject climbingPrompt;

	public GameObject myLampPost;


	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			climbingPrompt.SetActive (true);
			inputManager.canClimb = true;
			other.gameObject.GetComponent<player_controller> ().myLampPost = myLampPost;
		}
	}


	public void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			climbingPrompt.SetActive (false);
			inputManager.canClimb = false;
		}
	}
		
}
