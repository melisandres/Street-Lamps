using System.Collections;
using UnityEngine;

public class go_to_work_script : MonoBehaviour 
{
	public fade_to_white fadeToWhite;
	public input_manager inputManager;
	public GameObject player;

	public void GoToWork()
	{
		fadeToWhite.SetAlphaOut ();
		fadeToWhite.StopThem ();
		inputManager.movement = "regular";
		Vector3 newPosition = new Vector3 (0, 1, -5);
		player.transform.position = newPosition;
	}
}
