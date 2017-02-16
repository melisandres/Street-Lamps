using System.Collections;
using UnityEngine;

public class player_controller : MonoBehaviour 
{
	public float accelForceNormal = 1000f;
	public float accelForce = 800f;
	public float steeringForce = 800f;

	public bool timeToRotate;
	public bool autoClimbing;

	public GameObject myLampPost;
	public bool repositionPlayer;


	void FixedUpdate() 
	{
		if (timeToRotate)
			RotateTowardsPole ();

		if (autoClimbing)
			Climb();
	}


	public void RotateTowardsPole()
	{
		//this solution is not perfect, because the minute the raycast hits the lamp-post you can start to climb, 
		//which means that you won't be facing it directly... but almost. 
		//I should probably use math in order to determine a specific point to face between player and lampPost...
		//but I'll leave it at this for now. It mostly works.

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		int reach = 1;

		if (Physics.Raycast (transform.position, fwd, out hit, reach) && hit.transform.tag == "lampPost")
			timeToRotate = false;
		else 
			gameObject.transform.Rotate (0, 0.5f * steeringForce * Time.deltaTime, 0);
	}
		
	public void Freeze()
	{
		gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
	}

	public void UnFreeze()
	{
		gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
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
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1F);
	}

	public void MoveRight(Vector3 direction)
	{
		direction = direction * 1; 
		direction = direction.normalized;	
		gameObject.GetComponent<Rigidbody> ().AddForce (direction * accelForce * Time.deltaTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1F);
	}

	public void MoveUp(Vector3 direction)
	{
		direction = direction * 1; 
		direction = direction.normalized;	
		gameObject.GetComponent<Rigidbody> ().AddForce (direction * accelForce * Time.deltaTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1F);
	}

	public void MoveDown(Vector3 direction)
	{
		direction = direction * -1; 
		direction = direction.normalized;	
		gameObject.GetComponent<Rigidbody> ().AddForce (direction * accelForce * Time.deltaTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1F);
	}
}
