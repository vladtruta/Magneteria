using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour {
	public static bool isEnabled=true;

	void Start () {
		if (isEnabled)
			AudioListener.volume=1f;
		else 
			AudioListener.volume=0f;
	}
	
	public void Adjust()
	{
		if (isEnabled)
			AudioListener.volume=1f;
		else 
			AudioListener.volume=0f;
	}
public void Change()
	{
		isEnabled=!isEnabled;

		Adjust();
	}
}
