using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BottomVolText : MonoBehaviour {

	Image image;


	void Awake () {
		image=this.transform.Find ("Image2").GetComponent<Image>();
		Check ();
	}
	
	public void Check()
	{
		if (VolumeControl.isEnabled)
			image.enabled=false;
		else 
			image.enabled=true;
	}
}
