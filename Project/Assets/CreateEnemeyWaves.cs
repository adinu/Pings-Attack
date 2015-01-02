using UnityEngine;
using System.Collections;

public class CreateEnemeyWaves : MonoBehaviour {
	public GameObject[] waves;
	public float TimeUntilNextWave;
	public float TimeUntilFirstWave;
	public float TimeUntilNextRoundOfWaves;
	
	void Start (){
		StartCoroutine (CreateWaves ());
	}
	
	IEnumerator CreateWaves ()
	{
		yield return new WaitForSeconds (TimeUntilFirstWave);
		while (true)
		{
			for (int i = 0; i < waves.Length; i++){
				Instantiate (waves[i], this.gameObject.transform.position, Quaternion.identity);
				yield return new WaitForSeconds (TimeUntilNextWave);
			}
			yield return new WaitForSeconds (TimeUntilNextRoundOfWaves);
		}
	}
}
