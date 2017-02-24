using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class choice_button_script : MonoBehaviour 
{
	public Button button;
	public Text text;

	public enum buttonTypes
	{
		option1,
		option2,
		option3,
		option4,
		option5
	}

	public buttonTypes myButtonType;
}
