using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class lamp_post_top : MonoBehaviour 
{
	public camera_blurring cameraBlurring;
	public GameObject lightSwitchesPanel;
	public GameObject myLampPost;

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

			//set the light controlling panel as active
			lightSwitchesPanel.SetActive (true);

			//get the info of your lampPost, and reset your Slider the the info for THIS lampPost
//			float intensity = myLampPost.GetComponent<lamp_post_information>().myIntensity;
//			lightSwitchesPanel.GetComponentInChildren<Slider> ().value = intensity;


			//set the position of the slider based on the intensity of the current light
			float intensity = other.GetComponent<player_controller> ().myLampPost.GetComponent<lamp_post_information> ().myIntensity;
			lightSwitchesPanel.GetComponentInChildren<Slider> ().value = intensity;
			Debug.Log (intensity);
		}
	}
}
