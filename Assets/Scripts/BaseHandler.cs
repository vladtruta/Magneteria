using UnityEngine;
using System.Collections;

public abstract class BaseHandler : MonoBehaviour {
	protected GameObject blockRaycasts;
	protected SaveScript saveScript;

	protected void Awake()
	{
		blockRaycasts=transform.Find("RaycastBlocker").gameObject;
		saveScript=gameObject.GetComponent<SaveScript>();
	}

	public virtual void Enable (Collider2D col)
	{
		blockRaycasts.SetActive (true);
		col.GetComponent<CharacterController> ().enabled = false;
		Animator anim = col.GetComponent<Animator> ();
		anim.SetBool ("MoveLeft", false);
		anim.SetBool ("MoveRight", false);
		anim.SetBool ("onLadder", true);
		GameObject.Find ("UI/RaycastBlocker/Exit").gameObject.SetActive(true);
	}
	
	public virtual void Disable (Collider2D col)
	{
		blockRaycasts.SetActive (false);
		col.GetComponent<CharacterController> ().enabled = true;
		col.GetComponent<Animator> ().SetBool ("onLadder", false);
	}
}
