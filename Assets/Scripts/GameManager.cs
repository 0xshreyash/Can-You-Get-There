using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static int  score;
	public static int  highScore; 
	public static int tokenCount;
	private int totalTokens;
	public static int  currentLevel; 
	public int unlockedLevel;

	public GUISkin skin;
	public float startTime;
	string currentTime;
	public static bool completed = false;
	public static bool gameOver = false;
	public static bool winner = false;

	public GameObject tokenParent;

	private static bool showWinScreen = false;

	public Rect timerArea;
	public void Update()
	{
		if (!completed) 
		{
			gameOver = false;
			startTime -= Time.deltaTime;
			if (startTime <= 0) 
			{
				startTime = 0;
				gameOver = true;
				Time.timeScale = 0f; 

			}
			currentTime = string.Format ("{0:0.0}", startTime);
		}




	}
	void Start()
	{
		totalTokens = tokenParent.transform.childCount;

		if (PlayerPrefs.GetInt ("Level Completed") > 0) {
			currentLevel = PlayerPrefs.GetInt ("Level Completed");
		} else
			currentLevel = 1;
		//DontDestroyOnLoad (gameObject);
	}

	public static void CompleteLevel()
	{
		showWinScreen = true;
	}

	public void LoadNextLevel()
	{
		if (currentLevel < 2) {
			currentLevel++;
			SaveGame ();
			Application.LoadLevel (currentLevel);
			Time.timeScale = 1f;
		}
	

	}

	public void SaveGame()
	{
		PlayerPrefs.SetInt ("Level Completed", currentLevel);
		PlayerPrefs.SetInt ("Level " + currentLevel.ToString () + " score", score);
	}

	
	public static void AddToken()
	{
		tokenCount ++;
	}


	void OnGUI()
	{

		GUI.skin = skin;
		GUI.Label (timerArea, currentTime);
		GUI.Label (new Rect(300,10,200,200),tokenCount.ToString() + " of " + totalTokens.ToString());

		if (showWinScreen)
		{

			completed = true;
			Rect winScreenRect = new Rect(Screen.width/2-150, Screen.height/2-25, 300, 90);
			GUI.Box(winScreenRect, "You successfully completed level " + currentLevel +  " !! Yay !!");
			int time = (int)startTime ;
			score = tokenCount * time ;
			if(GUI.Button(new Rect(Screen.width/2-250+100, Screen.height/2-25+50+10,100, 25), "Continue"))
			{
				tokenCount = 0;
				showWinScreen = false;
				completed = false;
				if(currentLevel == 2)
				winner = true;
				LoadNextLevel();



			}
			if(GUI.Button(new Rect(Screen.width/2+150-100, Screen.height/2-25+50+10,100, 25), "Quit"))
			{
				tokenCount = 1;
				showWinScreen = false;
				completed = false;
				Application.LoadLevel("Main-Menu");

			}

			GUI.Label (new Rect (Screen.width - 400, 10, 300, 300), "Score : " + score.ToString ());

			

		}
		if (gameOver) 
		{
			completed = false;
			Rect winScreenRect = new Rect (Screen.width / 2 - 150, Screen.height / 2 - 25, 300, 90);
			GUI.Box (winScreenRect, "You were unsuccessful on level " + currentLevel + " !! Awww.");
			if (GUI.Button (new Rect (Screen.width / 2 - 150 + 100, Screen.height / 2 - 25 + 50 + 10, 100, 25), "OK")) 
			{
				tokenCount = 0;
				gameOver = false;
				Application.LoadLevel("Main-Menu");	
			}
		}
		if (winner) 
		{
			Rect winScreenRect = new Rect (Screen.width / 2 - 150, Screen.height / 2 - 25, 300, 90);
			GUI.Box (winScreenRect, "You won the game !! Yay !!");
			int time = (int)startTime;
			score = tokenCount * time;
			
			GUI.Label (new Rect (Screen.width - 250, 10, 300, 300), "Score : " + score.ToString ());
			
			if (GUI.Button (new Rect (Screen.width / 2 - 150 + 100, Screen.height / 2 - 25 + 50 + 10, 100, 25), "Main Menu")) 
			{
				tokenCount = 0;
				completed = false;
				Application.LoadLevel("Main-Menu");
				winner = false;

				
			}
		
			
		}


	}



	
}
