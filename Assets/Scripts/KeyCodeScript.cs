using UnityEngine;
using System.Collections;

public class KeyCodeScript : MonoBehaviour
{
	ActivateKeyCode keyCode;
	[System.NonSerialized]
	public string correctCode;
	public GameObject doorToDisable;

	void Awake()
	{
		keyCode=GameObject.Find("UI").GetComponent<ActivateKeyCode>();
	}
	void OnTriggerStay2D (Collider2D col)
	{
		if (col.name == "MainChar") {
			if (Input.GetButtonDown ("Interact"))
			{
				RegisterNumbers.doorToDisable=doorToDisable;
				RegisterNumbers.correctCode=correctCode;
				RegisterNumbers.col=col;
				RegisterNumbers.currentKeyCode=this.gameObject.GetComponent<BoxCollider2D>();
				keyCode.Enable(col);
			}
			if (Input.GetKeyDown(KeyCode.R))
				keyCode.Disable(col);
		}
	}

}
