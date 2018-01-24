using UnityEngine;
using System.Collections;

public class MagnetCollider : MonoBehaviour
{

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.name == "wallLeft1")
			PadlockMove.moveLeft1 = false;
		if (col.name == "wallLeft2")
			PadlockMove.moveLeft2 = false;
		if (col.name == "wallRight1")
			PadlockMove.moveRight1 = false;
		if (col.name == "wallRight2")
			PadlockMove.moveRight2 = false;

	}

	void OnTriggerExit2D ()
	{
		if (this.gameObject.name == "magnet1") {
			PadlockMove.moveLeft1 = true;
			PadlockMove.moveRight1 = true;

		} 
		else if (this.gameObject.name == "magnet2") {
			PadlockMove.moveLeft2 = true;
			PadlockMove.moveRight2 = true;
		}
	}
}
