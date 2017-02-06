using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class day_narr_reader : MonoBehaviour 
{
	public JsonHelper jsonHelper;
	private string path;
	private string jsonString;
	public dayNarr[] narratives;

	void Awake () 
	{
		path = Application.streamingAssetsPath + "/day_narr.json";
		jsonString = File.ReadAllText (path);
		narratives = JsonHelper.FromJson<dayNarr>(jsonString);
	}
		
	[System.Serializable]
	public class dayNarr
	{
		public int read;
		public string name;
		public int[] sleeplessness;
		public int[] dreamlessness;
		public int[] crime;
		public bool[] lights;
		public int[] arc;
		public string[] keywords;
		public string[] prerequisites;
		public string[] postrequisites;
		public string vignette;
	}



	public day_narr_reader dayNarrReader;
	int sleeplessness = 0;
	int dreamlessness = 0;
	int crime = 0;
	bool lightBright;
	bool lightBlue;
	bool lightOrange;
	int today = 0;
	public List <string> myKeyWords = new List<string>();
	public List <string> myPrerequisites = new List<string>();

	public void Start()
	{
		ChooseDayNarrative ();
	}

	public void ChooseDayNarrative()
	{
		for(int i = 0; i < narratives.Length; i++)

		{
			int score = 0;

			if (narratives [i].read == 1)
				i++;
			if (sleeplessness >= narratives[i].sleeplessness[0] && sleeplessness <= narratives[i].sleeplessness [1])
				score++;
			if (dreamlessness >= narratives[i].dreamlessness[0] && dreamlessness <= narratives[i].dreamlessness [1])
				score++;
			if (crime >= narratives[i].crime[0] && crime <= narratives[i].crime [1])
				score++;
			if (lightBright == narratives[i].lights[0])
				score++;
			if (lightBlue == narratives[i].lights[1])
				score++;
			if (lightOrange == narratives[i].lights[2])
				score++;
			if (today >= narratives[i].arc[0] && today <= narratives[i].arc [1])
				score++;


			//check keywords--this is going to be... er... possibly impossible.
			//check prerequisites


			if (score > 4)
				Debug.Log (narratives [i].vignette);
			else 
			{
				Debug.Log (narratives [i].name + " didn't score high enough");
				Debug.Log (score + " didn't score high enough");

			}
			
			//if a vignette is chosen
			//send this script a new postRequisite for the list
			//send this script some new KeyWords for the list
			//actually keywords have got to have a better way...
			//and maybe just making a bunch of serializable classes in Unity would be more accessible than Json?
			//also, send a "read" value to that entry... I guess in the translation.
			//a "save game would then send that information to the Json file. 
			// string narrativesJson = JsonHelper.ToJson(narratives);
		}
	
	}
}
