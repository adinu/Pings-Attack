using UnityEngine;
using System.Collections;

public class EnemyShots : MonoBehaviour {
	public GameObject enemyBullet;
	public float startWait;
	public float shotWait;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		StartCoroutine (Shots());
	}
	
	// Update is called once per frame
	IEnumerator Shots () {
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Quaternion spawnRotation = Quaternion.identity;
			Vector3 pos = this.transform.position + offset;
			Instantiate (enemyBullet, pos, spawnRotation);
			yield return new WaitForSeconds (shotWait);
		}

	}
}
