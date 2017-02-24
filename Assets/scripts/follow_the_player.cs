using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class follow_the_player : MonoBehaviour 
{
	public GameObject player;
	public Camera myCamera;
	public Canvas myCanvas;
	RectTransform rt;

	void Start()
	{
		rt = gameObject.GetComponent<RectTransform> ();
	}

	void Update()
	{
		
		if (gameObject.tag == "speechBubble") 
		{
			Vector3 playerPosition = myCamera.WorldToScreenPoint (player.transform.position);
			playerPosition.y = playerPosition.y + 200;
			playerPosition.x = playerPosition.x - 100;
			rt.position = playerPosition;
		} 

		else 
		{
			Vector3 playerPosition = myCamera.WorldToScreenPoint (player.transform.position);
			playerPosition.y = playerPosition.y + 200;
			rt.position = playerPosition;
		}

	}

}
