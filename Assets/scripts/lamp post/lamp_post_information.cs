using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp_post_information : MonoBehaviour 
{
	//myCameras!!
	public Camera underCamera;
	public Camera topCamera;

	//what's going on with my light today!
	public float myIntensity = 4.0f;
	public Color myColor;


	//and how about every other day????

	class lampPostDailyData
	{
		public float intensity;
		public Color myColor;
	}

	//and how about the spawn points that are near me?
	//although if these spawn points reference me, does that mean I shouldn't reference them?
}
