using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour 
{
	public camera_switcher camera_switcher;
	public Camera myCamera;
	public string myMovement;
	public GameObject scriptManager;

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			Debug.Log ("on trigger enter triggered");
			camera_switcher.ChangeCurrentCamera (myCamera);
			scriptManager.GetComponent<input_manager> ().movement = myMovement;
		}
	}
}
