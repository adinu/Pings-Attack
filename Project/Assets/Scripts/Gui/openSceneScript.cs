using UnityEngine;
using System.Collections;

public class openSceneScript : MonoBehaviour {

	public AudioSource bearSleeping;
	public int TimeInSecondsBeforNExtSceneStarts;

	// Use this for initialization
	void Start () {
		bearSleeping.Play ();


	}
	
	IEnumerator suspendNextScene()
	{
		yield return new WaitForSeconds(TimeInSecondsBeforNExtSceneStarts);
		Application.LoadLevel(1);
	}

	
	// Update is called once per frame
	void Update () {
		suspendNextScene ();
	
	}
}
