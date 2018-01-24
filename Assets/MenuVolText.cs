using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuVolText : MonoBehaviour {

	Text text;

	void Awake () {
		text=gameObject.GetComponent<Text>();
		Check ();
	}
	
	public void Check()
	{
		if (VolumeControl.isEnabled)
			text.text="Sound: On";
		else 
			text.text="Sound: Off";
	}
}
