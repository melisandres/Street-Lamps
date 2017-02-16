﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_blurring : MonoBehaviour 
{
	public float blurrTime;
	public float displayTime;

	private IEnumerator blurrIt;
	private IEnumerator unblurrIt;


	private Camera myCamera;


	public void LetsBlurr (Camera myCamera) 
	{
		if (blurrIt != null) 
		{
			StopCoroutine (blurrIt);
		}
		blurrIt = BlurrIt (myCamera);
		StartCoroutine (blurrIt);
	}

	IEnumerator BlurrIt (Camera myCamera) 
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