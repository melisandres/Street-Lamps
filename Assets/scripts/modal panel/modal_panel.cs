using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class modal_panel : MonoBehaviour 
{
	public Text question;
	public Image iconImage;
	public Button workButton;
	public Button homeButton;
	public Button mehButton;
	public GameObject modalPanelObject;
			

	public void DayChoiceWithImage (string question, Sprite iconImage, UnityAction workEvent, UnityAction homeEvent, UnityAction mehEvent)
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
		this.iconImage.sprite = iconImage;

		this.iconImage.gameObject.SetActive (true);
		workButton.gameObject.SetActive (true);
		homeButton.gameObject.SetActive (true);
		mehButton.gameObject.SetActive (true);
	}




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
