using UnityEngine;
using System.Collections;

public enum Movment {Vertical,Horizontal,Wave};

public class EnemyMovment : MonoBehaviour {
	public float speed;
	private Vector3 directionOfMovment;
	public float WaveMovementTime;
	private float waveTime;
	
	public Movment movment;

	void Start(){
		waveTime = WaveMovementTime;
		switch (movment) {
			case Movment.Horizontal:
				directionOfMovment = new Vector3(1f,0f,0f);
				break;
			case Movment.Vertical:
				directionOfMovment = new Vector3(0f,-1f,0f);
				break;
			case Movment.Wave:
				directionOfMovment = new Vector3(1f,-1f,0f);
				break;
		}

	}

	void FixedUpdate () {
		this.rigidbody2D.velocity = directionOfMovment * speed;
		waveTime -= Time.deltaTime;
		if (waveTime < 0) {
			waveTime = WaveMovementTime;
			directionOfMovment.y *= -1;
		}
	}

	public Movment getMovmentType(){
		return movment;
	}
}
