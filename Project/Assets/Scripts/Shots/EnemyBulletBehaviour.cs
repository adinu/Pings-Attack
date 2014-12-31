using UnityEngine;
using System.Collections;

public class EnemyBulletBehaviour : MonoBehaviour {
	private Vector3 heroPos;
	public float force;
	// Use this for initialization
	void Start () {
		heroPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		Vector3 direction = heroPos - this.transform.position;
		this.gameObject.rigidbody2D.AddForce (direction *force);
	}

}
