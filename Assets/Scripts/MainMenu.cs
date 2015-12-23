using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUISkin skin; 
	void OnGUI()
	{
		GUI.skin = skin;
		Time.timeScale = 1f;
		GUI.Label (new Rect (Screen.width/2 - 100, 30, 250, 75), "Main Menu");

		if (GUI.Button (new Rect (Screen.width/2 - 125, 150, 250, 75), "New Game")) 
		{
			PlayerPrefs.SetInt("Level Completed", 0);
			Application.LoadLevel(1);


		}
		if (PlayerPrefs.GetInt ("Level Completed") > 0) 
		{
			if (GUI.Button (new Rect (Screen.width/2 - 125, 275, 250, 75), "Continue")) 
			{

				Application.LoadLevel (PlayerPrefs.GetInt ("Level Completed"));


			}
		}
		if (GUI.Button (new Rect (Screen.width/2 - 125, 400, 250, 75), "World")) 
		{
			
			Application.LoadLevel ("World");

			
		}

		if (GUI.Button (new Rect (Screen.width/2 - 125, 650, 250, 75), "Quit")) 
		{
			
			Application.Quit();
			
		}

	}
}
