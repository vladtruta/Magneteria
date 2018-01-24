using UnityEngine;
using System.Collections;

public class PadlockOpen : MonoBehaviour
{
	PadlockHandler handler;

	void Awake()
	{
		handler=this.transform.parent.transform.parent.GetComponent<PadlockHandler>();
	}
	void OnTriggerStay2D (Collider2D col)
	{
		if (col.name == "mid") {
			if (col.transform.parent.gameObject.name == "magnet1") {
				PadlockMove.moveLeft1 = false;
				PadlockMove.moveRight1 = false;
				PadlockHandler.lockLeft=true;
				col.enabled=false;  //reactivate
				handler.CheckLocks();
				handler.DeactivateLocks("left");
			}
			if (col.transform.parent.gameObject.name == "magnet2")
			{
				PadlockMove.moveLeft2 = false;
				PadlockMove.moveRight2 = false;
				PadlockHandler.lockRight=true;
				col.enabled=false; //reactivate
				handler.CheckLocks();
				handler.DeactivateLocks("right");
			}
		}
	}
}
