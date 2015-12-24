using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour 
{

	public int levelToLoad ;
	private string loadPrompt; 
	private int completedLevel;
	private bool canLoadLevel;
	public GameObject padlock;

	void Start()
	{
		completedLevel = PlayerPrefs.GetInt ("Level Completed");
		if (levelToLoad <= completedLevel) 
		{
			canLoadLevel = true;

		} 
		if(!canLoadLevel)
		{
			Instantiate(padlock, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), Quaternion.Euler(-90, 0, 0));
		}
	}

	void Update()
	{
		if (canLoadLevel == true && Input.GetButtonDown ("Action")) 
		{
			if (loadPrompt == "Left Click/Enter to load level 0")
				Application.LoadLevel ("Main-Menu");
			else if (loadPrompt == "Left Click/Enter to load level 1")
				Application.LoadLevel ("Level -1");
			else if (loadPrompt == "Left Click/Enter to load level 2")
				Application.LoadLevel ("Level -2");
		}
	}

	void OnTriggerStay(Collider other)
	{

		if (canLoadLevel) {
			loadPrompt = "Left Click/Enter to load level " + levelToLoad.ToString ();

		} 
		else 
		{
			loadPrompt = "Locked level " + levelToLoad.ToString ();
		}

	}

	void OnTriggerExit()
	{
		loadPrompt = "";
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width/2 -  100, Screen.height/2 -20, 200, 40), loadPrompt);

	}

}
