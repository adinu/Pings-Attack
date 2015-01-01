using UnityEngine;
using System.Collections;

public class createEnemeiesWave : MonoBehaviour {
	public GameObject[] enemies;
	public Vector3[] positionValues;
	public float[] timeUntilNextEnemy;
	public float timeUntilFirstWave;
	
	void Start (){
		StartCoroutine (CreateWave ());
	}
	
	IEnumerator CreateWave ()
	{
		yield return new WaitForSeconds (timeUntilFirstWave);
		for (int i = 0; i < enemies.Length; i++){
			Instantiate (enemies[i], positionValues[i], Quaternion.identity);
			yield return new WaitForSeconds (timeUntilNextEnemy[i]);
		}
	}
}
