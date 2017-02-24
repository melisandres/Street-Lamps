using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;

public class ink_manager: MonoBehaviour 
{
	[SerializeField]
	private TextAsset test_inkJSONAsset;
	private Story test_story;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private GameObject narrativePanel;

	//I want different bits of the narrative to display in different ways
	[SerializeField]
	private GameObject factBox;
	[SerializeField]
	private GameObject theirSpeechBubble;
	[SerializeField]
	private GameObject mySpeechBubble;
	[SerializeField]
	private GameObject thoughtBox; //thoughts are subtitles

	[SerializeField] 
	private GameObject currentSpeaker;

	[SerializeField]
	private string myCurrentText;
	public Text text;

	[SerializeField]
	private choice_button_script[] buttons;

	public bool waitingOnInput;
	public bool reading = false;

	//this script is adapted from an example game provided by inkle

	void Awake () 
	{
		StartStory();
	}


	void StartStory () 
	{
		InitSpeakers ();
		test_story = new Story (test_inkJSONAsset.text);
		//this is where I think I should send any variables to the ink story
		test_story.variablesState["something"] = true;
		//this is where I need to put the name of the current "knot"
		test_story.ChoosePathString("sound");
		RefreshView();
		reading = true;
	}

	void Update()
	{
		if (!waitingOnInput && Input.GetMouseButtonDown (0)) 
		{
			if (test_story.canContinue) 
			{
				RefreshView ();
			}
			else if (test_story.currentChoices.Count > 0) 
			{
				RefreshView ();
			}
			else 
			{
				if (Input.GetMouseButtonDown (0) && !test_story.canContinue && reading)
				{
					currentSpeaker.SetActive (false);
					Debug.Log ("and now I've ended it");
					reading = false;
				}
			}
		}
	}
		
public 	void RefreshView () 
	{
		//to print out everything without pause, you use while (canContinue)
		//and ensure that each line of text doesn't replace the last... 
		if (test_story.canContinue) 
		{
			HideContent ();
			HideChoices ();
			text.gameObject.SetActive(true);

			string rawText = test_story.Continue ().Trim();
			myCurrentText = ParseContent (rawText);
			text.text = myCurrentText;
		}
			
		if(test_story.currentChoices.Count > 0) 
		{
			for (int i = 0; i < Mathf.Min(test_story.currentChoices.Count, buttons.Length); i++) 
			{
				choice_button_script button = buttons [i];
				Choice choice = test_story.currentChoices [i];
				button.gameObject.SetActive (true);
				button.text.text = choice.text;

				button.button.onClick.AddListener (delegate 
				{
					OnClickChoiceButton (choice);
				});
			}
			waitingOnInput = true;
		} 
		else 
		{
			//Debug.Log ("end of story?");
		}
	}


	public string ParseContent(string rawContent)
	{
		string subjectID = "";
		string content = "";
		if (!TrySplitContentBySearchString(rawContent, ": ", ref subjectID, ref content))
		{
			return rawContent;
		}
		ChangeSpeaker (subjectID);
		return content;
	}

	public bool TrySplitContentBySearchString(string rawContent, string searchString, ref string left, ref string right)
	{
		int firstSpecialCharacterIndex = rawContent.IndexOf (searchString);
		if (firstSpecialCharacterIndex == -1)
			return false;
		left = rawContent.Substring (0, firstSpecialCharacterIndex).Trim ();
		right = rawContent.Substring (firstSpecialCharacterIndex + searchString.Length, rawContent.Length - firstSpecialCharacterIndex - searchString.Length).Trim ();
		return true;
 	}


	public void ShowContentView(string text)
	{
	}
	public void ShowChoiceView(string text)
	{
	}
	public void HideChildren()
	{
	}



	public void HideContent()
	{
		text.text = "";
		text.gameObject.SetActive (false);
	}



	public void HideChoices()
	{
		foreach (var button in buttons) 
		{
			button.gameObject.SetActive (false);
		}
	}
		

	void OnClickChoiceButton (Choice choice) 
	{

		for (int i = 0; i < Mathf.Min (test_story.currentChoices.Count, buttons.Length); i++) 
		{
			choice_button_script button = buttons [i];
			button.button.onClick.RemoveAllListeners ();
		}
		waitingOnInput = false;
		InitSpeakers();
		test_story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}


	private void InitSpeakers()
	{
		factBox.SetActive(false);
		theirSpeechBubble.SetActive (false);
		mySpeechBubble.SetActive (false);
		thoughtBox.SetActive (false);
		ChangeSpeaker ("thoughts");
	}

	private void ChangeSpeaker(string speaker)
	{

		if (currentSpeaker != null) 
		{
			currentSpeaker.SetActive (false);
		}

		if (speaker == "narrator") 
		{
			currentSpeaker = factBox;
		}

		else if (speaker == "player") 
		{
			currentSpeaker = mySpeechBubble;
		}
			
		else if (speaker == "other") 
		{
			currentSpeaker = theirSpeechBubble;
		} 

		else 
		{
			currentSpeaker = thoughtBox;
		}
			
		currentSpeaker.SetActive (true);
		text = currentSpeaker.GetComponentInChildren<Text>();

	}

}
