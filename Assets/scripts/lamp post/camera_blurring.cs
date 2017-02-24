using System.Collections;
using UnityEngine;

public class camera_blurring : MonoBehaviour 
{
	public GameObject player;
	public float blurrTime;
	public float displayTime;

	private IEnumerator blurrIt;
	private IEnumerator unblurrIt;


	//private Camera myCamera;


	public void LetsBlurr (Camera myCamera, bool blurAndUnblur, Camera myNextCamera) 
	{
		if (blurrIt != null) 
		{
			StopCoroutine (blurrIt);
		}
		blurrIt = BlurrIt (myCamera, blurAndUnblur, myNextCamera);
		StartCoroutine (blurrIt);
	}

	IEnumerator BlurrIt (Camera myCamera, bool blurAndUnblur, Camera myNextCamera) 
	{
		myCamera.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = true;
		int myBlurr = myCamera.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().blurIterations;
		float myBlurrFloat = 1f;

		yield return new WaitForSeconds (blurrTime);

		while (myBlurr < 4) 
		{
			myBlurr = Mathf.RoundToInt(myBlurrFloat += Time.deltaTime / blurrTime);
			myCamera.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().blurIterations = myBlurr;
			yield return null;
		}

		//this is called specifically when you are going down the lamp post
		if (blurAndUnblur && myBlurr == 4) 
		{
			player.GetComponent<camera_switcher> ().ChangeCurrentCamera (myNextCamera);
			LetsUnblurr (myNextCamera);
		}
			
		yield return null;
	}



	public void LetsUnblurr (Camera myCamera) 
	{
		if (unblurrIt != null) 
		{
			StopCoroutine (unblurrIt);
		}
		unblurrIt = UnblurrIt (myCamera);
		StartCoroutine (unblurrIt);
	}

	IEnumerator UnblurrIt (Camera myCamera) 
	{
		myCamera.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = true;
		int myBlurr = myCamera.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().blurIterations;
		float myBlurrFloat = 1f;

		yield return new WaitForSeconds (blurrTime);

		while (myBlurr > 1) 
		{
			myBlurr = Mathf.RoundToInt(myBlurrFloat -= Time.deltaTime / blurrTime);
			myCamera.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().blurIterations = myBlurr;
			yield return null;

			if (myBlurr == 1)
			{
				myCamera.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = false;
			}
		}
		yield return null;
	}
}