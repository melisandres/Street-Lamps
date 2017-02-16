using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp_post_top : MonoBehaviour 
{
	public camera_blurring cameraBlurring;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			//set autoClimbing to false
			other.GetComponent<player_controller>().autoClimbing = false;

			//freeze the player's position
			other.GetComponent<player_controller>().Freeze();

			//make the player invisible
			other.gameObject.SetActive (false);

			//make the new camera Unblur
			Camera myCamera = other.GetComponent<camera_switcher>().currentCamera;
			cameraBlurring.LetsUnblurr (myCamera);
		}
	}


}
