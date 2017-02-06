using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bring_to_front : MonoBehaviour 
{

	void OnEnable()
	{
		transform.SetAsLastSibling ();
	}
}
