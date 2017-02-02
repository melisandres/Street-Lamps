using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_switcher : MonoBehaviour 
{
	//this script is attached to the player and keeps track of which camera is on.
	
	public Camera mainCamera;
	public Camera camera1;
	public Camera camera2;

	public Camera currentCamera;
	public Camera thisCamera;

	void Start()
	{
		currentCamera = camera2;
	}

	public void ChangeCurrentCamera(Camera thisCamera) 
	{
		currentCamera.enabled = false;
		currentCamera = thisCamera;
		currentCamera.enabled = true;
	}
}
