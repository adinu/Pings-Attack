using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
	private bool isSoundOn=false;

	
	public void SoundToggle()
	{
		if (isSoundOn) {
			AudioListener.volume = 0;
			isSoundOn=false;
		} else {
			AudioListener.volume = 1;
			isSoundOn=true;
		}
	}
}
