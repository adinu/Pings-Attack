using UnityEngine;
using System.Collections;

public class CreateEnemies : MonoBehaviour {
	public GameObject[] enemies;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private Vector3 spawnPosition = new Vector3(1,1,0);
	
	void Start (){
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++){
				int j = Random.Range(0,enemies.Length);

				Movment movment = enemies[j].GetComponent<EnemyMovment>().getMovmentType();

				switch (movment) {
				case Movment.Horizontal:
					spawnPosition = new Vector3(-4f,3.3f,0f);
					break;
				case Movment.Vertical:
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					break;
				case Movment.Wave:
					spawnPosition = new Vector3(-3f,3.3f,0f);
					break;
				}

				Instantiate (enemies[j], spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
