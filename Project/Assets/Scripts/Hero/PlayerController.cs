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
	public float FPS = 1;
	private float timeLeft;

	void Start(){
		anim = GetComponent<Animator> ();
		facingRight = true;
		healthBarImage = GameObject.FindGameObjectWithTag ("HealthBar").GetComponent<Image> ();
		GameController = GameObject.FindGameObjectWithTag ("GameController");
		currentBullet = bullets [0];
		timeLeft = FPS;

	}


	// Update is called once per frame
	void Update () {	
		if (GameController.GetComponent<Controller> ().getShotsCount () > 0) {
			if (!Application.isMobilePlatform) {	
				if (Input.GetMouseButtonDown (0)) {  
					Instantiate (currentBullet, this.transform.position + offsetBullet, Quaternion.identity);
					GameController.GetComponent<Controller> ().addShots (-1);
				}
			}else {
				timeLeft -= Time.deltaTime;
				if ( timeLeft < 0 ){
					Instantiate (currentBullet, this.transform.position + offsetBullet, Quaternion.identity);
					timeLeft = FPS;
				}
			}

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
		if(healthBarImage.fillAmount > 0 )
		{
			healthBarImage.fillAmount = healthBarImage.fillAmount - 0.2f;
		}
		if (HP == 0) {
			Kill();
		}
	}


	private void Kill (){
		Destroy (this.gameObject);
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
					GameController.GetComponent<Controller>().addShots(30);
				
				break;
				}
		}

	public void addLive()
	{
			if (HP < maxHP) { //We can still add lives
					HP++;

				healthBarImage.fillAmount = healthBarImage.fillAmount + 0.2f;
			}
	}


				


}
