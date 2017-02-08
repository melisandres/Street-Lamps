using System.Collections;
using UnityEngine;

public class bus_stop_manager : MonoBehaviour 
{
	public input_manager inputManager;

	public GameObject busStopPrompt;


	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			busStopPrompt.SetActive (true);
			inputManager.canGoHome = true;
		}
	}


	public void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			busStopPrompt.SetActive (false);
			inputManager.canGoHome = false;
		}
	}
}
