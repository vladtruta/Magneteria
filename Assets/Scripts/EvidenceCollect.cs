using UnityEngine;
using System.Collections;

public class EvidenceCollect : MonoBehaviour
{

	CodeHandler codeHandler;

	void Awake ()
	{
		codeHandler = GameObject.Find ("UI").GetComponent<CodeHandler> ();
	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.name == "MainChar" && Input.GetButtonDown ("Interact")) {
			codeHandler.CollectEvidence ();
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}
	}

}
