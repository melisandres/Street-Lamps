using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day_narr_manager : MonoBehaviour 
{
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
		
	}

//	public void ChooseDayNarrative()
//	{
//		//for(int i = 0; i < dayNarrReader.narratives.Length-1; i++)
//
//		foreach (var item in dayNarrReader.narratives)
//		{
//			int score = 0;
//			if (sleeplessness > item.sleeplessness[0] && sleeplessness < item.sleeplessness[1])
////			if (sleeplessness > dayNarrReader.narratives[i].sleeplessness[0] && sleeplessness < dayNarrReader.narratives[i].sleeplessness [1])
//				score++;
//			if (dreamlessness > item.dreamlessness[0] && dreamlessness < item.dreamlessness [1])
////			if (dreamlessness > dayNarrReader.narratives[i].dreamlessness[0] && dreamlessness < dayNarrReader.narratives[i].dreamlessness [1])
//				score++;
//			if (crime > item.crime[0] && crime < item.crime [1])
////			if (crime > dayNarrReader.narratives[i].crime[0] && crime < dayNarrReader.narratives[i].crime [1])
//				score++;
//			if (score > 4)
//				Debug.Log (item.vignette);
////				Debug.Log (dayNarrReader.narratives[i].vignette);
//			else 
//				Debug.Log (item.name + "didn't score high enough");	
////				Debug.Log (dayNarrReader.narratives[i].name + "didn't score high enough");	
//				
//		}

		//	"sleeplessness": [0,10],
		//	"dreamlessness": [0,10],
		//	"crime": [0,10],
		//	"lights": [true, true, true],
		//	"arc": [3,9],
		//	"keywords": ["day", "strange"],
		//	"prerequisites": ["working"],
		//	"postrequisites": ["none"],
//	}
}


