using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject[] enemies;
	public Vector3 spawnValues;
	//public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private Vector3 spawnPosition = new Vector3(1,1,0);
	private int[] hazardCount = {3,1};

	
	void Start (){
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		for (int k = 0; k < 2; k++)//Make two waves for the tutorial part.
		{
			for (int i = 0; i < hazardCount[k]; i++){
				
				Movment movment = enemies[k].GetComponent<EnemyMovment>().getMovmentType();
				
				switch (movment) {
				case Movment.Horizontal:
					spawnPosition = new Vector3(-4f,3.3f,0f);
					break;
				case Movment.Vertical:
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					break;
				case Movment.Wave:
					spawnPosition = new Vector3(-5f,3.3f,0f);
					break;
				}
				
				Instantiate (enemies[k], spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
