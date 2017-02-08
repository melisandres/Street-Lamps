using System.Collections;
using UnityEngine;

public class meh_script : MonoBehaviour 
{
	public go_to_work_script goToWorkScript;
	public day_changer dayChanger;


	public void Meh()
	{
		int random;
		random = Random.Range (1, 3);
		Debug.Log (random);
		if (random > 1) 
		{
			goToWorkScript.GoToWork();
		}

		else 
		{
			dayChanger.StayAtHome();
			dayChanger.ChangeTheDay();
		}
	}
}
