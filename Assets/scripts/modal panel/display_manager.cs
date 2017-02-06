using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class display_manager : MonoBehaviour 
{

	public Text displayText;
	public float displayTime;
	public float fadeTime;

	private IEnumerator fadeAlpha;

	private static display_manager displayManager;

	public static display_manager Instance () 
	{
		if (!displayManager) 
		{
			displayManager = FindObjectOfType(typeof (display_manager)) as display_manager;
			if (!displayManager)
				Debug.LogError ("There needs to be one active DisplayManager script on a GameObject in your scene.");
		}

		return displayManager;
	}

	public void DisplayMessage (string message) 
	{
		displayText.text = message;
		SetAlpha ();
	}

	void SetAlpha () 
	{
		if (fadeAlpha != null) 
		{
			StopCoroutine (fadeAlpha);
		}
		fadeAlpha = FadeAlpha ();
		StartCoroutine (fadeAlpha);
	}

	IEnumerator FadeAlpha () 
	{
		Color resetColor = displayText.color;
		resetColor.a = 1;
		displayText.color = resetColor;

		yield return new WaitForSeconds (displayTime);

		while (displayText.color.a > 0) 
		{
			Color displayColor = displayText.color;
			displayColor.a -= Time.deltaTime / fadeTime;
			displayText.color = displayColor;
			yield return null;
		}
		yield return null;
	}
}

