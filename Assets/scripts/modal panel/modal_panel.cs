using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class modal_panel : MonoBehaviour 
{
	public go_to_work_script goToWorkScript;
	public day_changer dayChanger;
	public meh_script mehScript;

	public Text question;
	public Image iconImage;
	public Button workButton;
	public Button homeButton;
	public Button mehButton;
	public GameObject modalPanelObject;
			

	public void DayChoice (string question, Sprite iconImage, UnityAction workEvent, UnityAction homeEvent, UnityAction mehEvent)
	{


		workButton.onClick.RemoveAllListeners ();
		workButton.onClick.AddListener (workEvent);
		workButton.onClick.AddListener (ClosePanel);
		workButton.onClick.AddListener (goToWorkScript.GoToWork);

		homeButton.onClick.RemoveAllListeners ();
		homeButton.onClick.AddListener (homeEvent);
		homeButton.onClick.AddListener (ClosePanel);
		homeButton.onClick.AddListener (dayChanger.StayAtHome);
		homeButton.onClick.AddListener (dayChanger.ChangeTheDay);

		mehButton.onClick.RemoveAllListeners ();
		mehButton.onClick.AddListener (mehEvent);
		mehButton.onClick.AddListener (mehScript.Meh);
		mehButton.onClick.AddListener (ClosePanel);

		this.question.text = question;
		this.iconImage.sprite = iconImage;

		modalPanelObject.SetActive (true);
		this.iconImage.gameObject.SetActive (true);
		workButton.gameObject.SetActive (true);
		homeButton.gameObject.SetActive (true);
		mehButton.gameObject.SetActive (true);
	}

	//okay, the weird thing is that you can call DayChoice()
	//and it will look at your arguments, and choose the right DayChoice() based on the type/number of arguments
	//you've got... ? weird.

	public void DayChoice (string question, UnityAction workEvent, UnityAction homeEvent, UnityAction mehEvent)
	{
		modalPanelObject.SetActive (true);

		workButton.onClick.RemoveAllListeners ();
		workButton.onClick.AddListener (workEvent);
		workButton.onClick.AddListener (ClosePanel);

		homeButton.onClick.RemoveAllListeners ();
		homeButton.onClick.AddListener (homeEvent);
		homeButton.onClick.AddListener (ClosePanel);

		mehButton.onClick.RemoveAllListeners ();
		mehButton.onClick.AddListener (mehEvent);
		mehButton.onClick.AddListener (ClosePanel);

		this.question.text = question;

		this.iconImage.gameObject.SetActive (false);
		workButton.gameObject.SetActive (true);
		homeButton.gameObject.SetActive (true);
		mehButton.gameObject.SetActive (true);
	}

	public void ClosePanel()
	{
		modalPanelObject.SetActive (false);
	}
}
