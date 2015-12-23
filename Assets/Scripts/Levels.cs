using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour 
{

	public int levelToLoad;
	private string loadPrompt;
	private bool inRange = false; 
	private int completedLevel;
	private bool canLoadLevel;
	public GameObject padlock;

	void Start()
	{
		completedLevel = PlayerPrefs.GetInt ("Level Completed");
		if (levelToLoad <= completedLevel) {
			canLoadLevel = true;
		} else {
			if (completedLevel < 1 && levelToLoad == 1) {
				canLoadLevel = true;
			} else {
				canLoadLevel = false;
			}
		}
		if(!canLoadLevel)
		{
			Instantiate(padlock, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), Quaternion.Euler(-90, 0, 0));
		}
	}

	void Update()
	{
		if (canLoadLevel && Input.GetButtonDown ("Action")) {
			Application.LoadLevel ("Level -" + levelToLoad.ToString ());
			
		}
	}

	void OnTriggerStay(Collider other)
	{
		inRange = true;
		if (canLoadLevel) {
			loadPrompt = "Left Click/Enter to load level " + levelToLoad.ToString ();
		} else {
			loadPrompt = "Locked level " + levelToLoad.ToString ();
		}

	}

	void OnTriggerExit()
	{
		inRange = false;
		loadPrompt = "";
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width/2 -  100, Screen.height/2 -20, 200, 40), loadPrompt);

	}

}
