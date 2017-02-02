using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour 
{
	public float accelForceNormal = 1000f;
	public float accelForce = 1000f;
	public float steeringForce = 1000f;

	public bool timeToRotate;
	public bool repositionPlayer;

	void Start()
	{
		//set the cursor as invisible and locked
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;	
	}

	void FixedUpdate() 
	{
		if (timeToRotate)
			RotateTowardsPole ();

	}


	public void RotateTowardsPole()
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast(transform.position, fwd, 1)) 
			timeToRotate = false;
		else 
			gameObject.transform.Rotate (0, 0.5f * steeringForce * Time.deltaTime, 0);
	}



	public void RetrieveTheCursor()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}


	public void RotateThePlayer()
	{
		gameObject.transform.Rotate (0, Input.GetAxis ("Mouse X") * steeringForce * Time.deltaTime, 0);
	}

	//this is to Climb... its just... um... moving up, until you hit the Top
	public void Climb()
	{
		Vector3 direction = new Vector3 ();
		direction.y = 1; 
		direction = direction.normalized;	
		gameObject.GetComponent<Rigidbody> ().AddForce (direction * accelForce * Time.deltaTime);
	}


	//the following two functions are being called by input_manager on keyDown, to figure out which direction is 
	//right, left, away, or towards the current camera
	public Vector3 GetCameraDirectionRight()
	{
		Vector3 direction = new Vector3 ();
		Camera currentCameraRef = gameObject.GetComponent<camera_switcher>().currentCamera;
		direction = currentCameraRef.transform.right; 
		return(direction);
	}
		
	public Vector3 GetCameraDirectionForward()
	{
		Vector3 direction = new Vector3 ();
		Camera currentCameraRef = gameObject.GetComponent<camera_switcher>().currentCamera;
		direction = currentCameraRef.transform.forward; 
		return(direction);
	}


	//movement scripts called after the directions are determined (by the 2 scripts above)
	public void MoveLeft(Vector3 direction)
	{
		direction = direction * -1; 
		direction = direction.normalized;	
		gameObject.GetComponent<Rigidbody> ().AddForce (direction * accelForce * Time.deltaTime);
	}

	public void MoveRight(Vector3 direction)
	{
		direction = direction * 1; 
		direction = direction.normalized;	
		gameObject.GetComponent<Rigidbody> ().AddForce (direction * accelForce * Time.deltaTime);
	}

	public void MoveUp(Vector3 direction)
	{
		direction = direction * 1; 
		direction = direction.normalized;	
		gameObject.GetComponent<Rigidbody> ().AddForce (direction * accelForce * Time.deltaTime);
	}

	public void MoveDown(Vector3 direction)
	{
		direction = direction * -1; 
		direction = direction.normalized;	
		gameObject.GetComponent<Rigidbody> ().AddForce (direction * accelForce * Time.deltaTime);
	}
}
