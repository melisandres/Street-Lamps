using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class fade_to_white : MonoBehaviour 
{
	public day_changer dayChanger;
	public test_modal_window testModalWidow;

	public string startDayString= "~Day ";
	public string endDayString= "~";

	public float displayTime1;
	public float displayTime2;
	public float fadeTime1;
	public float fadeTime2;
	public GameObject panel;
	public Image white;
	public Image black;
	public Image blackMask;
	private bool canShowWindow;


	private IEnumerator fadeToWhite;
	private IEnumerator fadeToBlack;
	private IEnumerator fadeAlphaOut;

	//this is MESSYYYYYY. its an adaptation of the script that fades in/out text (from a unity tutorial)
	//it should be CLEANER.
	//I just have to figure it out!
	//Like... white fades in... when completely in, black is under and its alpha is turned to 1
	//Then, white's alpha fade back to zero. 
	//on click, white will continue its co-routine, but black can start fading out as well...
	//I don't know... whatever the case... the question panel, all of it... it all sorta works now. sorta.


	public void StopThem()
	{
		StopCoroutine (fadeToBlack);
		StopCoroutine (fadeToWhite);
	}


	public void FadeIn () 
	{
		panel.SetActive (true);
		SetAlphaWhite ();
	}



	void SetAlphaWhite () 
	{
		if (fadeToWhite != null) 
		{
			StopCoroutine (fadeToWhite);
		}
		fadeToWhite = FadeToWhite ();
		StartCoroutine (fadeToWhite);
	}
		
	IEnumerator FadeToWhite () 
	{
		Color resetColor = white.color;
		resetColor.a = 0;
		white.color = resetColor;

		yield return new WaitForSeconds (displayTime1);

		while (white.color.a < 1) 
		{
			Color displayColor = white.color;
			displayColor.a += Time.deltaTime / fadeTime1;
			white.color = displayColor;

			if (white.color.a > 0.7f) 
			{
				string message = startDayString + dayChanger.today + endDayString;
				white.GetComponentInChildren<Text> ().text = message; 
				white.GetComponentInChildren<Text>().enabled= true;
			}

			if (white.color.a > 0.98f) 
			{
				Color c = blackMask.color;
				c.a = 0;
				blackMask.color = c;
				canShowWindow = true;
			}

			yield return null;
		}
			yield return null;
		SetAlphaBlack ();
	}
		


	void SetAlphaBlack () 
	{
		if (fadeToBlack != null) 
		{
			StopCoroutine (fadeToBlack);
		}
		fadeToBlack = FadeToBlack ();
		StartCoroutine (fadeToBlack);
	}

	IEnumerator FadeToBlack () 
	{
		Color resetColor = black.color;
		resetColor.a = 0;
		black.color = resetColor;
		Debug.Log ("I'm fading to black");

		yield return new WaitForSeconds (displayTime2);

		while (black.color.a < 1) 
		{
			Color displayColor = black.color;
			displayColor.a += Time.deltaTime / fadeTime2;
			black.color = displayColor;

			if (black.color.a > 0.7f && canShowWindow) 
			{
				canShowWindow = false;
				white.GetComponentInChildren<Text>().enabled= false;
				testModalWidow.TestWHMI ();
			}
				
			yield return null;
		}
		yield return null;
	}



	public void SetAlphaOut () 
	{
		if (dayChanger.atHome) 
		{
			Debug.Log ("I'm at home, so I'm setting my mask on");
			Color c = blackMask.color;
			c.a = 1;
			blackMask.color = c;
			dayChanger.atHome = false;
		}

		if (fadeAlphaOut != null) 
		{
			StopCoroutine (fadeAlphaOut);
		}
		fadeAlphaOut = FadeAlphaOut ();
		StartCoroutine (fadeAlphaOut);
	}
		

	IEnumerator FadeAlphaOut () 
	{
		Color resetColor = white.color;
		resetColor.a = 0;
		white.color = resetColor;

		yield return new WaitForSeconds (displayTime1);

		while (black.color.a > 0) 
		{
			Color displayColor = black.color;
			displayColor.a -= Time.deltaTime / fadeTime1;
			black.color = displayColor;
			yield return null;
		}
		yield return null;
	}
}
