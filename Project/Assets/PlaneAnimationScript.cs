using UnityEngine;
using System.Collections;

public class PlaneAnimationScript : MonoBehaviour {

	public Sprite[] spriteArray;
	public float sampleTime;
	private float timeLeft;
	private int i;
	private new SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
		timeLeft = sampleTime;
		i = 0;
		renderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			renderer.sprite = spriteArray [i];
			i = (i + 1) % spriteArray.Length;
			timeLeft = sampleTime;
		}
	}
}
