using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {
	public GameObject bullet;
	public GameObject heroPos;
	Vector3 startPos;
	private int score;
	public int shotsCount;

	//public Text scoreText;
		
	void Start(){
		score = 0;
	}

	public void addScore(int points){
		score += points;	
	}

	public int getScore(){
		return score;	
	}

	public void addShots(int shotsToAdd){
		shotsCount += shotsToAdd;	
	}
	
	public int getShotsCount(){
		return shotsCount;	
	}
}
