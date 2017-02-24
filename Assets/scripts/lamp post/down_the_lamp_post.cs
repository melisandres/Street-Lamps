using System.Collections;
using UnityEngine;

public class down_the_lamp_post : MonoBehaviour 
{
	public GameObject player;
	public camera_blurring cameraBlurring;
	public GameObject lampPost;

	public void FinishBirdwatching()
	{
		//set the light controlling panel as inactive!
		gameObject.SetActive (false);

		//myLampPost 
		lampPost = player.GetComponent<player_controller>().myLampPost;

		//engage the blur of this camera
		Camera currentCamera = lampPost.GetComponent<lamp_post_information>().topCamera;
		Camera nextCamera = lampPost.GetComponent<lamp_post_information> ().underCamera;
		cameraBlurring.LetsBlurr(currentCamera, true, nextCamera);

		//player can move again!
		player.GetComponent<player_controller>().UnFreeze ();

		//make the player visible again
		player.SetActive (true);

		//change the player's position
		player.transform.position = lampPost.transform.GetChild(0).transform.position;
	}
}
