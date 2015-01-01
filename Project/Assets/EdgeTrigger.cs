using UnityEngine;
using System.Collections;

public class EdgeTrigger : MonoBehaviour {
	private float pos;
	public float offset;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "enemy") {
			other.gameObject.GetComponent<EnemyMovment> ().Flip ();
			if (other.gameObject.GetComponent<EnemyMovment> ().getMovmentType () == Movment.Wave){
				//If its a pilot then change direction. 
				other.gameObject.GetComponent<EnemyMovment> ().speed *= -1;

			}
		}
	}
}
