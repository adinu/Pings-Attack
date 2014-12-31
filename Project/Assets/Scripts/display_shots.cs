using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class display_shots : MonoBehaviour {
	
	public GameObject ShotsTextUi;
	private GameObject controllerGameObject; // Drag the game controller here
	Text shotsScore;							//Drag the text ui object here
	int shots_to_display;
	
	void Start () {
		controllerGameObject = GameObject.FindGameObjectWithTag ("GameController");
		shots_to_display = 0;
		shotsScore = ShotsTextUi.GetComponent<Text>();  //The text component of a UI Text Object
		shotsScore.text="" + shots_to_display;
	}
	
	void Update () {
		shots_to_display = controllerGameObject.GetComponent<Controller> ().getShotsCount();
		shotsScore.text =  shots_to_display.ToString();

	}
}
