using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class display_score : MonoBehaviour {

	public GameObject ScoreTextUi;
	public GameObject highScoreTextUi;
	private GameObject controllerGameObject; // Drag the game controller here
	Text textScore;							//Drag the text ui object here
	Text textHighScore;
	public int game_score_to_display;
	public int highScore = 0;
	string highScoreKey = "HighScore";
	
	void Start () {
		controllerGameObject = GameObject.FindGameObjectWithTag ("GameController");
		game_score_to_display = 0;
		textScore = ScoreTextUi.GetComponent<Text>();  //The text component of a UI Text Object
		textScore.text="Score : " + game_score_to_display;
		//Get the highScore from player prefs if it is there, 0 otherwise.
		highScore = PlayerPrefs.GetInt(highScoreKey,0);
		textHighScore = highScoreTextUi.GetComponent<Text>();
		textHighScore.text="HighScore : " + highScore.ToString();
		Debug.Log (highScore);
	}

	void Update () {
		game_score_to_display = controllerGameObject.GetComponent<Controller> ().getScore();
		textScore.text = "Score: " + game_score_to_display.ToString();
		//Debug.Log (game_score_to_display);
		//If our scoree is greter than highscore, set new higscore and save.
		if(game_score_to_display>highScore){
			PlayerPrefs.SetInt(highScoreKey, game_score_to_display);
			PlayerPrefs.Save();
		}
	}
	void OnDisable(){
		
		//If our scoree is greter than highscore, set new higscore and save.
		if(game_score_to_display>highScore){
			PlayerPrefs.SetInt(highScoreKey, game_score_to_display);
			PlayerPrefs.Save();
			Debug.Log (game_score_to_display);
		}
	}
}
