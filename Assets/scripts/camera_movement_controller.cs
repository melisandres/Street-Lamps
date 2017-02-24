using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement_controller : MonoBehaviour 
{
	public float steeringForce = 100f;
	private float topMostRotation = 350;
	private float bottomMostRotation = 40;
	private float rightMostRotation = 30;
	private float leftMostRotation = 330;

	public float currentRotation = 0.0f;
	public float rotationY;
	public float rotationX;

	public void RotateCameraLeft()
	{
		transform.Rotate (0, -0.3f * steeringForce * Time.deltaTime, 0);

		rotationY = transform.localEulerAngles.y;
		if (rotationY < leftMostRotation && rotationY > leftMostRotation - 10.0f)
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, leftMostRotation, transform.localEulerAngles.z);

		float z = transform.eulerAngles.z;
		transform.Rotate(0, 0, -z);
	}



	public void RotateCameraRight()
	{
		transform.Rotate(0, 0.3f * steeringForce * Time.deltaTime, 0);

		rotationY = transform.localEulerAngles.y;
		if (rotationY > rightMostRotation && rotationY < rightMostRotation + 10.0f)
		transform.eulerAngles = new Vector3(transform.localEulerAngles.x, rightMostRotation, transform.localEulerAngles.z);

		float z = transform.localEulerAngles.z;
		transform.Rotate(0, 0, -z);
	}



	public void RotateCameraUp()
	{
		gameObject.transform.Rotate (-0.3f * steeringForce * Time.deltaTime, 0 , 0);

		rotationX = transform.localEulerAngles.x;
		if (rotationX < topMostRotation && rotationX > topMostRotation - 10.0f)
			transform.eulerAngles = new Vector3(topMostRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
		
		float z = transform.eulerAngles.z;
		transform.Rotate(0, 0, -z);
	}



	public void RotateCameraDown()
	{
		gameObject.transform.Rotate (0.3f * steeringForce * Time.deltaTime, 0 , 0);

		rotationX = transform.localEulerAngles.x;
		if (rotationX > bottomMostRotation && rotationX < bottomMostRotation + 10.0f)
			transform.eulerAngles = new Vector3(bottomMostRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);

		float z = transform.eulerAngles.z;
		transform.Rotate(0, 0, -z);
	}
		
}
