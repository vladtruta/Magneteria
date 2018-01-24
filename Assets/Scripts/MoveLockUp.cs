using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveLockUp : MonoBehaviour
{

	public static bool ableToMove;
	public static Collider2D coll;
	public static GameObject lockToUnlock; //usa sau lacat
	public GameObject originalpos;
	PadlockHandler handler;
	AudioClip clip;

	void Awake ()
	{
		//	originalpos=this.transform.localPosition;
		//	originalpos2=this.transform.parent.localPosition;
		handler = transform.parent.parent.GetComponent<PadlockHandler> ();
		clip = Resources.Load ("Music/door-shut-03") as AudioClip;
	}

	void Update ()
	{
		if (ableToMove) {
			if (Input.GetButton ("MoveUp"))
				this.transform.Translate (Vector3.up);
		}
	
	}

	public void Reset ()
	{
		this.transform.position = originalpos.transform.position;
	
	}

	void OnTriggerEnter2D ()
	{
		//print("mere");
		AudioSource.PlayClipAtPoint (clip, this.transform.position);
		lockToUnlock.transform.Find ("lock").gameObject.SetActive (false);

		lockToUnlock.GetComponent<DoorScript> ().locked = false;
		handler.Disable (coll);
	}
}
