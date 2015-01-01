using UnityEngine;
using System.Collections;

public enum ENUM_bulletType  {oneHPDown,twoHPDown, specialShot};
public enum ENUM_bulletMovment  {vertical,wave};

public class HeroShot : MonoBehaviour {
	public float timeLeft;
	public float force;
	public ENUM_bulletType eBulletType;
	public ENUM_bulletMovment bulletMovment;
	public Vector3 direction;
	public float FPS;
	public float waveFrequency;//If not Wave ignore.
	private float timeLeftWaveFrequency;

	
	void Start(){
		timeLeftWaveFrequency = waveFrequency;
		if (eBulletType == ENUM_bulletType.specialShot)
			return;
		//Vector3 direction = new Vector3 (0, 1, 0);
		this.gameObject.rigidbody2D.AddForce (direction *force);

		GameObject [] rewardGO = GameObject.FindGameObjectsWithTag ("reward");
		foreach(GameObject gobject in rewardGO)
		{
			Physics2D.IgnoreCollision(gobject.collider2D, this.gameObject.collider2D);
		}
	}
	
	void Update(){
		if (eBulletType == ENUM_bulletType.specialShot)
			return;
		timeLeft -= Time.deltaTime;
		if(ENUM_bulletMovment.wave == bulletMovment){
			timeLeftWaveFrequency -= Time.deltaTime;
			if ( timeLeftWaveFrequency < 0 ){
				direction.x *= -1;
				timeLeftWaveFrequency = waveFrequency;
			}
		}

		if ( timeLeft < 0 )
			Destroy(this.gameObject);
	}

	void FixedUpdate () {  //decrease shot size as time progresses
		if (eBulletType == ENUM_bulletType.specialShot)
			return;
		transform.localScale = transform.lossyScale*0.99f;
		
	}

	public float getFPS(){
		return FPS;
	}

}

