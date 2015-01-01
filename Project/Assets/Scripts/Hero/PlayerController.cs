using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
[System.Serializable]

public class PlayerController : MonoBehaviour {
	public GameObject[] bullets; //0- oneHP   1-twoHP  2-Double bullet
	Vector3 startPos;
	public Vector3 offsetBullet;
	public float speed;
	public float boundery;
	bool facingRight;
	public int HP; //current
	public int maxHP; 
	Animator anim;
	private Image healthBarImage;
	private GameObject GameController; 
	private GameObject currentBullet;
	private float FPS;
	private float timeLeft;
	int currentBull;
	public GameObject guiGO;

	void Start(){
		currentBull = 0;
		FPS = bullets [currentBull].gameObject.GetComponent<HeroShot> ().getFPS ();
		anim = GetComponent<Animator> ();
		facingRight = true;
		healthBarImage = GameObject.FindGameObjectWithTag ("HealthBar").GetComponent<Image> ();
		GameController = GameObject.FindGameObjectWithTag ("GameController");
		timeLeft = FPS;

	}


	// Update is called once per frame
	void Update () {	
				timeLeft -= Time.deltaTime;
				if ( timeLeft < 0 ){
					//Shoot constantly
					Instantiate (bullets [currentBull], this.transform.position + offsetBullet, Quaternion.identity);
					timeLeft = FPS;
				}
	}


	void FixedUpdate () {
		float horizontal;
		if (!Application.isMobilePlatform) {
			horizontal = Input.GetAxis ("Horizontal");
		} else { 	
			//horizontal = Input.acceleration.x;
				if(Input.GetTouch(0).phase == TouchPhase.Moved){
					horizontal = Input.GetTouch(0).deltaPosition.x;
					speed = 0.7f;
				}else
					horizontal = 0;
		}
		

		anim.SetFloat ("Speed", Mathf.Abs (horizontal));
		Vector3 movement = new Vector3 (horizontal, 0f, 0f);
		this.rigidbody2D.velocity = movement*speed;

		if ((horizontal < 0) && facingRight)
			Flip ();
		else if ((horizontal > 0) && !facingRight)
			Flip ();
		
		this.rigidbody2D.position = new Vector3 (
			Mathf.Clamp (this.transform.position.x, -boundery, boundery), this.transform.position.y, this.transform.position.z);
	}

	private void Flip(){
		facingRight = !facingRight;
		Vector3 scale = this.gameObject.transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "enemyBullet") {
			Destroy (col.gameObject);
			this.Hit();
		}

		if (col.gameObject.tag == "enemy") {
			col.gameObject.GetComponent<enemyClass>().createEnemyExplosion();
			this.Hit();
		}


	}


	public void Hit () {
		HP--;
		downgradeShots ();
		if(healthBarImage.fillAmount > 0 )
		{
			healthBarImage.fillAmount = healthBarImage.fillAmount - 0.333f;
		}
		if (HP == 0) {
			Kill();
		}
	}


	private void Kill (){
		//Call display game over menu
		guiGO.GetComponent<startScreen>().gameOver();

		Destroy (this.gameObject);
		//Time.timeScale = 0; //pause

	}

	public void reactToReward(Enum_RewardType rewardType){
				switch (rewardType) {
				case Enum_RewardType.BOMB:
					this.Hit();
						break;
				case Enum_RewardType.LIVES: 
						addLive();
						break;
				case Enum_RewardType.SHOTS:
						upgradeShots();
						break;
				}
		}

	public void addLive()
	{
			if (HP < maxHP) { //We can still add lives
					HP++;

				healthBarImage.fillAmount = healthBarImage.fillAmount + 0.333f;
			}
	}

	//Upgrade Shots
	private void upgradeShots ()
	{
		if (currentBull < bullets.Length - 1) 
		{
			currentBull++;
			FPS = bullets [currentBull].gameObject.GetComponent<HeroShot> ().getFPS ();
		}
	}
	
	//Down grade shots
	private void downgradeShots ()
	{
		if (currentBull > 0) 
		{
			currentBull--;
			FPS = bullets [currentBull].gameObject.GetComponent<HeroShot> ().getFPS ();
		}
	}


				


}
