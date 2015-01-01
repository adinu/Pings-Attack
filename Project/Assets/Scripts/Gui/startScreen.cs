using UnityEngine;
using System.Collections;

public class startScreen : MonoBehaviour {
	public GameObject pauseMenu;				// The pause menu UI element to be activated on pause
	public GameObject gameOverMenu;				// The game over menu UI element to be activated on pause
	private bool paused = false;				// The boolean value to keep track of whether or not the game is currently paused
	public Sprite pause_sprite1_Pause; // Drag your first sprite here
	public Sprite pause_sprite2_Play; // Drag your second sprite here
	public SpriteRenderer spriteRenderer; 
	public int highScore;
	string highScoreKey = "HighScore";
	
	private bool isGameStpoed=false;
	// Use this for initialization
	void Start () {
		// we are accessing the SpriteRenderer that is attached to the Gameobject
		
		spriteRenderer = GetComponent<SpriteRenderer>();
		Screen.autorotateToPortrait = false;
		Screen.orientation = ScreenOrientation.Landscape;
	}
	
	// Update is called once per frame
	void Update () {
		// Pause game
//		if (Input.GetButtonDown("Pause"))
//		{
//			paused = !paused;
//			if (paused)
//				Pause();
//			else
//				Play();
//		}
	}
	
	public void RestartLevel()
	{
		// Restart this level
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void startGame()
	{
		Application.LoadLevel(1);
		Debug.Log ("should load scene 1");
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
		Debug.Log (highScoreKey);
	}
	
	public void Pause () 
	{
			//GameObject canvas_popUpMenu = GameObject.FindGameObjectWithTag ("popUpmenuCanvas");
			//canvas_popUpMenu.SetActive(true);
			//canvas_popUpMenu.GetComponent<Canvas>().enabled=true;
			//yield return new WaitForSeconds(1);
			
			Time.timeScale = 0;
			Debug.Log ("pause pressed");
			// Activate the pause menu UI element
			if (pauseMenu != null)
				pauseMenu.SetActive(true);
			
			paused = true;
			isGameStpoed=true;
			//spriteRenderer.sprite = pause_sprite1_Pause; // set the sprite to sprite1- pause
	}

	public void Play () 
	{
			Time.timeScale = 1;
			Debug.Log ("play pressed");
			// Deactivate the pause menu UI element
			if (pauseMenu != null)
				pauseMenu.SetActive(false);
			
			paused = false;
			isGameStpoed=false;
			//spriteRenderer.sprite = pause_sprite2_Play; // set the sprite to sprite1- play
	}

	public void gameOver()
	{
		Time.timeScale = 0;
		Debug.Log ("game over");
		// Activate the pause menu UI element
		if (gameOverMenu != null)
			gameOverMenu.SetActive(true);
		
		paused = true;
		isGameStpoed=true;
	}

	public void startNewGame(){
		// Restart the game
		Application.LoadLevel(1);
	}
	
	public void setSound(float sliderValue)
	{
		Debug.Log ("sound slider value= " + sliderValue);
		Debug.Log ("sound slider value test");
		AudioListener.volume = sliderValue/10;
	}
	// Quit the game
	public void Quit()
	{
		Application.Quit();
	}
}
