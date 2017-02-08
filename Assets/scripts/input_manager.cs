using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_manager : MonoBehaviour 
{

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
		//cursor
		if (Input.GetKeyDown (KeyCode.Escape))
			player_controller.RetrieveTheCursor();

		//rotation
		if (Input.GetAxis ("Mouse X") > 0.09f || Input.GetAxis ("Mouse X") < -0.09f)
			player_controller.RotateThePlayer ();
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
			//this function: gives the player a short ray cast, and if it doesn't hit ANYTHING...
			//it rotates the player until it hits SOMETHING (it seems to hit the collider although its set to trigger.)
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
			//
		}


		//dayMode movement
		if (movement == "dayMode")
		{
			//for now, I think... in day mode, all you can do is interact with the UI.
		}

	}
}
