using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class camera_switcher : MonoBehaviour 
{
	//this script is attached to the player and keeps track of which camera is on.

	public Canvas myCanvas;

	public Camera mainCamera;
	public Camera camera1;
	public Camera camera2;

	public Camera currentCamera;

	void Start()
	{
		currentCamera = camera2;
		myCanvas.GetComponent<Canvas> ().worldCamera = camera2;
		myCanvas.GetComponentInChildren<follow_the_player> ().myCamera = camera2;
	}

	public void ChangeCurrentCamera(Camera myNextCamera)
	{
		currentCamera.enabled = false;
		currentCamera = myNextCamera;
		currentCamera.enabled = true;
		myCanvas.GetComponentInChildren<follow_the_player> ().myCamera = myNextCamera;
	}
}
