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

	void Start()
	{
		currentCamera = camera2;
	}

	public void ChangeCurrentCamera(Camera myNextCamera) 
	{
		currentCamera.enabled = false;
		currentCamera = myNextCamera;
		currentCamera.enabled = true;
	}
}
