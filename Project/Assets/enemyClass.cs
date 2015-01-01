using UnityEngine;
using System.Collections;

public class enemyClass : MonoBehaviour {
	public int HP;
	private GameObject GameController;
	public GameObject points;
	public GameObject [] rewards; //0-shots  1-live  2-bomb
	public int pointsToScore;
	//public Sprite demaged;
	//public Sprite dead;
	public AudioClip[] deathClips;
	public Vector4 oddsVector; //[0] :shots  [1]:lives [2]:bomb  [3]:empty
	//private SpriteRenderer ren;	
	private Animator anim;
	public bool facingRight;
		

	void Start(){
		//Check if enemy has parachute,if he has pick random color for it.
		foreach (SpriteRenderer t in GetComponentsInChildren<SpriteRenderer> ()){
			if(t.sprite.name == "prop_parachute")
				t.color =  new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), 1f);
		}


		anim = GetComponent<Animator> ();
		//ren = GetComponent<SpriteRenderer> ();
		GameController = GameObject.FindGameObjectWithTag ("GameController");
		GameObject [] rewardGO = GameObject.FindGameObjectsWithTag ("enemy");
		foreach(GameObject gobject in rewardGO)
		{
			Physics2D.IgnoreCollision(gobject.collider2D, this.gameObject.collider2D);
		}
	}
	

	// Use this for initialization
	public void Hit (int hp) {
		HP= HP-hp;
		//if (HP == 1)
			//ren.sprite = demaged;
		if (HP <= 0) {
			this.gameObject.collider2D.enabled = false;
			//ren.sprite = dead;
			Kill();
		}
	}

	public void createEnemyExplosion()
	{
		//this.gameObject.collider2D.enabled = false;
		anim.SetBool ("Die", true);
		// Play a random audioclip from the deathClips array.
		int i = Random.Range (0, deathClips.Length);
		AudioSource.PlayClipAtPoint (deathClips [i], transform.position);
	}

	private void Kill (){
//		anim.SetBool ("Die", true);
//		// Play a random audioclip from the deathClips array.
//		int i = Random.Range (0, deathClips.Length);
//		this.gameObject.collider2D.enabled = false;
//		AudioSource.PlayClipAtPoint (deathClips [i], transform.position);
		createEnemyExplosion ();



		Instantiate (points, this.transform.position, Quaternion.identity);
		GameController.GetComponent<Controller> ().addScore (pointsToScore);

		//Create reward
		float ran = Random.Range (0f, 10f);//Choose a random number
		if (ran < oddsVector.x) //shots
		{
			Instantiate (rewards[0], this.transform.position, Quaternion.identity);
			return;
		}
		if (ran < oddsVector.y) //live
		{
			Instantiate (rewards[1], this.transform.position, Quaternion.identity);
			return;
		}
		if (ran < oddsVector.z) //bomb
		{
			Instantiate (rewards[2], this.transform.position, Quaternion.identity);
			return;
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "heroBullet") {
			ENUM_bulletType shotType = col.gameObject.GetComponent<HeroShot>().eBulletType;
			Destroy(col.gameObject);
			switch(shotType)
			{
			case ENUM_bulletType.oneHPDown:
				Hit(1);
				break;
			case ENUM_bulletType.twoHPDown:
				Hit(2);
				break;
			case ENUM_bulletType.specialShot:
				break;
			}
		}

	}

	private void DestroyThis(){
		Destroy (this.gameObject);
	}

}
