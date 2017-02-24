using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_manager : MonoBehaviour 
{
	public camera_movement_controller cameraMovementController;
	public player_controller player_controller;
	public day_changer dayChanger;

	Vector3 cameraRight;
	Vector3 cameraForward;


	public string movement = "regular";
	//other possible strings are: climbing, birdwatching

	public bool canClimb = false;
	public bool canGoHome = false;

	public KeyCode keyUp = KeyCode.W;
	public KeyCode keyDown = KeyCode.S;

	public KeyCode keyLeft = KeyCode.A;
	public KeyCode keyRight = KeyCode.D;

	public KeyCode escape = KeyCode.Escape;

	public KeyCode interact = KeyCode.R;


	void Start()
	{
		cameraRight = player_controller.GetCameraDirectionRight ();
		cameraForward = player_controller.GetCameraDirectionForward ();
	}


	void Update()
	{
	}


	void FixedUpdate()
	{
		//going from canClimb to climbing  
		if (Input.GetKeyDown(interact) && canClimb) 
		{
			//check the position of the player if the postition isn't on the right side of the lamppost reposition the player

			player_controller.timeToRotate = true;
			//timeToRotate is checked in player_controller fixed update.
			//when true, it engages the RotateTowardsPole function
			//this function: rotates the player until a short raycast hits an object with the lampPost tag...
			movement = "climbing";
		}


		//going from canGoHome to dayMode
		if (Input.GetKeyDown(interact) && canGoHome) 
		{
			//dayMode movement is... um... no movement.
			movement = "dayMode";

			//day increase, fade to white (and then to black), and eventually... "record" your day.
			dayChanger.ChangeTheDay ();
			canGoHome = false;
		}


		if (movement == "climbing") 
		{
			//I make sure I'm done rotating towards the pole, before I start climbing
			//I should also make sure I've repositioned myself
			if (Input.GetKey (interact) && player_controller.timeToRotate == false)
				player_controller.Climb ();	
		}


		if (movement == "autoClimbing") 
		{
			//this is where you lose all control and the player will just keep going up on their own
			//until they hit the TOP
		}


		//regular movement
		if (movement == "regular") 
		{
			//first on key press, I need to evaluate where the camera is to determine what the directions are
			if (Input.GetKeyDown (keyLeft) || Input.GetKeyDown (keyRight)) 
				cameraRight = player_controller.GetCameraDirectionRight ();

			if (Input.GetKeyDown (keyUp) || Input.GetKeyDown (keyDown)) 
				cameraForward = player_controller.GetCameraDirectionForward ();


			//as the key continues to press, I need to keep the direction that I took at the moment of the key press
			if (Input.GetKey (keyLeft))
				player_controller.MoveLeft (cameraRight);

			if (Input.GetKey (keyRight))
				player_controller.MoveRight (cameraRight);

			if (Input.GetKey (keyUp))
				player_controller.MoveUp (cameraForward);

			if (Input.GetKey (keyDown))
				player_controller.MoveDown (cameraForward);
		}


		//birdWatching movement
		if (movement == "birdwatching") 
		{
			//I just wanna rotate the camera... 
			if (Input.GetKey (keyLeft))
				cameraMovementController.RotateCameraLeft();

			if (Input.GetKey (keyRight))
				cameraMovementController.RotateCameraRight();

			if (Input.GetKey (keyUp))
				cameraMovementController.RotateCameraUp();

			if (Input.GetKey (keyDown))
				cameraMovementController.RotateCameraDown();
		}


		//dayMode movement
		if (movement == "dayMode")
		{
			//for now, I think... in day mode, all you can do is interact with the UI.
			//so it's okay if this is empty....
		}

	}
}
