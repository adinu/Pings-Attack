using UnityEngine;
using System.Collections;

public class ParachuteBeh : MonoBehaviour {
	public float force;

	private Rigidbody2D penguin;
	// Use this for initialization
	void Start () {
		penguin = this.GetComponentInParent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		penguin.AddForce ((new Vector2 (0, 10)) * force);
	}

	void OnEnterCollision2D(Collision2D col){
		if (col.gameObject.tag == "heroBullet") {
			Destroy(this.gameObject);
		
		}

	}
}
