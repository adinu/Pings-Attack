using UnityEngine;
using System.Collections;

public class openSceneScript : MonoBehaviour {

	public AudioSource bearSleeping;
	public int TimeInSecondsBeforNExtSceneStarts;

	// Use this for initialization
	void Start () {
		bearSleeping.Play ();
		Invoke("suspendNextScene", TimeInSecondsBeforNExtSceneStarts);
		
	}
	
	void suspendNextScene()
	{

		Application.LoadLevel(1);
	}

	
	// Update is called once per frame
	void Update () {

	
	}
}
