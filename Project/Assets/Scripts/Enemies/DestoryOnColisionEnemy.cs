using UnityEngine;
using System.Collections;

public class DestoryOnColisionEnemy : MonoBehaviour {
	private GameObject GameController;
	public GameObject points;


	void Start(){
		GameController = GameObject.FindGameObjectWithTag ("GameController");
		}



	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "bullet")
		{
			Destroy(col.gameObject);
			Destroy (this.gameObject);
			//GameController.SendMessage("addScore", 1);
			Instantiate(points,this.transform.position,Quaternion.identity);
			GameController.GetComponent<Controller>().addScore(10);
		}
	}
		
}
