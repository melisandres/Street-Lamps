using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class test_modal_window : MonoBehaviour 
{

	public modal_panel modalPanel;
	public display_manager displayManager;

	public Sprite icon;



	//Send to the Modal Panel to set up the Buttons and Functions to call
	public void TestWHM()
	{
		modalPanel.DayChoice ("Time to leave bed, head into the world, and change the lights...", TestWorkFunction, TestHomeFunction, TestMehFunction);
	}

	//Sent to the Modal panel but with an icon
	public void TestWHMI()
	{
		modalPanel.DayChoice ("The moon is up. Time to leave bed, head into the world, and change the lights...", icon, TestWorkFunction, TestHomeFunction, TestMehFunction);
	}

		

	public void TestWorkFunction()
	{
		displayManager.DisplayMessage ("another day, another dollar");
	}

	public void TestHomeFunction()
	{
		displayManager.DisplayMessage ("stay in bed. forever.");
	}

	public void TestMehFunction()
	{
		displayManager.DisplayMessage ("Does it really matter, either way?");
	}
}

