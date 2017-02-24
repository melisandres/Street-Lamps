using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class light_controller : MonoBehaviour 
{
	public player_controller playerController;
	public Slider mySlider;


	public void ChangeLightIntensity()
	{
		Light myLight = playerController.myLampPost.GetComponentInChildren<Light>(); 
		float amplitude = mySlider.value;
		myLight.intensity = amplitude;
		playerController.myLampPost.GetComponent<lamp_post_information> ().myIntensity = amplitude;
	}


	public void MakeLightRed()
	{
		Light myLight = playerController.myLampPost.GetComponentInChildren<Light>(); 
		myLight.color = Color.red;	
		playerController.myLampPost.GetComponent<lamp_post_information> ().myColor = Color.red;
	}


	public void MakeLightBlue()
	{
		Light myLight = playerController.myLampPost.GetComponentInChildren<Light>(); 
		myLight.color = Color.blue;	
		playerController.myLampPost.GetComponent<lamp_post_information> ().myColor = Color.blue;
	}
}
