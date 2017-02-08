using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class day_changer : MonoBehaviour 
{
	public fade_to_white fadeToWhite;

	public int today = 0;
	public int yesterday = -1;
	public bool atHome;

	public void ChangeTheDay()
	{
		fadeToWhite.FadeIn ();
		today++;
		yesterday++;
	}

	public void StayAtHome()
	{
		atHome = true;
		fadeToWhite.SetAlphaOut();
		fadeToWhite.StopThem ();
	}
}
