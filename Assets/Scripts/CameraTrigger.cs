using UnityEngine;
using System.Collections;


public class CameraTrigger : MonoBehaviour
{
	GuardHandler gHandler;
	AudioClip clip;

	void Awake ()
	{
		gHandler = GameObject.Find ("UI").GetComponent<GuardHandler> ();
		clip = Resources.Load ("Music/siren-03") as AudioClip;

	}

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.name == "PolygonCollider") {
			gHandler.Enable ();
			AudioSource.PlayClipAtPoint (clip, this.transform.position, 0.5f);
		}
	}
}
