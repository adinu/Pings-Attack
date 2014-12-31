using UnityEngine;
using System.Collections;

public class enemyDemage : MonoBehaviour {
	public int Lifes = 2;

	private GameObject GameController;
	public GameObject points;
	public int pointsToScore;
	
	
	void Start(){
		GameController = GameObject.FindGameObjectWithTag ("GameController");
	}
	


	// Use this for initialization
	public void Hit () {
		Lifes--;
		if (Lifes == 0)
			Kill ();	
	}
	
	// Update is called once per frame
	private void Kill () {
		Destroy (this);
		Instantiate(points,this.transform.position,Quaternion.identity);
		GameController.GetComponent<Controller>().addScore(10);
	}
}
