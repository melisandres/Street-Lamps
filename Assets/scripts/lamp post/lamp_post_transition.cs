using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp_post_transition : MonoBehaviour 
{

	public GameObject scriptManager;
	public string myMovement;

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			Debug.Log ("nearing the TOP!");

			//disable movement
			scriptManager.GetComponent<input_manager> ().movement = myMovement;

			//keep moving the player up
			other.GetComponent<player_controller> ().autoClimbing = true;

			//start a coroutine that blurs currentCamera
			Camera myCamera = other.GetComponent<camera_switcher>().currentCamera;
			gameObject.GetComponent<camera_blurring>().LetsBlurr(myCamera);
		}
	}
}
