using UnityEngine;
using System.Collections;

public class LadderScript : MonoBehaviour
{
	Rigidbody2D rigid;


	void OnTriggerStay2D (Collider2D col)
	{
		if (col.name == "MainChar") {
			col.attachedRigidbody.isKinematic = true;
		
			rigid = col.attachedRigidbody;
		}

		if (Input.GetButton ("MoveUp") && col.name == "MainChar") {
			col.transform.Translate (TransformFormat.getTransVel (Vector3.up * 0.04f));

		}
		if (Input.GetButton ("MoveDown") && col.name == "LadderCollider") {
			col.transform.parent.transform.Translate (TransformFormat.getTransVel (Vector3.down * 0.04f));
		
		
		}


	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.name == "MainChar")
		rigid.isKinematic = false;


	}
}
