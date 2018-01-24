using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{

	public Transform waypoint;
	public string button;
	public bool locked;

	void OnTriggerStay2D (Collider2D col)
	{	
		if (col.name == "MainChar") {
			if (!locked) {
				if (Input.GetButtonDown (button))
					col.transform.position = waypoint.transform.position;
			} else {

				PadlockHandler handler=GameObject.Find("UI").GetComponent<PadlockHandler>();

				if (Input.GetButtonDown ("Interact"))
				{
					MoveLockUp.lockToUnlock=this.gameObject;
					MoveLockUp.coll=col;
					handler.Enable(col);
				}
				if (Input.GetKeyDown(KeyCode.R))
				{
					handler.Disable(col);
				}
			}
		}
	}
}
