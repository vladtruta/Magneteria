using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ClickSound : MonoBehaviour {

	AudioClip clip;
	Button btn;

	void Awake () {
		clip=Resources.Load("Music/mouse-doubleclick-02") as AudioClip;
		if (this.gameObject.GetComponent<Button>())
		btn=this.gameObject.GetComponent<Button>();
	}
	
	void Start()
	{
		btn.onClick.AddListener(()=>{AudioSource.PlayClipAtPoint(clip, this.transform.position, 0.7f);});
	}
public void Click()
	{
		AudioSource.PlayClipAtPoint(clip, this.transform.position, 0.7f);
	}
}
