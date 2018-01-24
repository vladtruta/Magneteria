using UnityEngine;
using System.Collections;


public class CircuitScript : MonoBehaviour
{

	CircuitHandler circuitHandler;
	public GameObject laserToRemove;
	AudioClip clip;

	void Awake ()
	{
		circuitHandler = GameObject.Find ("UI").GetComponent<CircuitHandler> ();
		clip = Resources.Load ("Music/hit-02") as AudioClip;
	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.name == "MainChar") {
			if (Input.GetButtonDown ("Interact")) {
				CircuitHandler.laserToRemove = laserToRemove;
				CircuitHandler.coll = this.gameObject.GetComponent<BoxCollider2D> ();
				CircuitHandler.charcoll = col;
				if (CircuitHandler.isEnabled == false) {
					AudioSource.PlayClipAtPoint (clip, this.transform.position);
					circuitHandler.Enable (col);
					CircuitHandler.isEnabled = true;
				}
			}
			if (Input.GetKeyDown (KeyCode.R)) {
				circuitHandler.Disable (col);
				CircuitHandler.isEnabled = false;
			}
		}
	}

}
