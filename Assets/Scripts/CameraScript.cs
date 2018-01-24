using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

	public int orientation;
	public bool isMoving;
	public float waitTimetoTurn;
	Animator anim;
	bool invoke = false;

	void Awake ()
	{
		anim = this.gameObject.GetComponent<Animator> ();
	}

	void Start ()
	{

		if (orientation == 0) {
			this.transform.Find ("CamRight").GetComponent<PolygonCollider2D> ().enabled = true;
			invoke = true;
		} else if (orientation == 1) {
			this.transform.Find ("CamLeft").GetComponent<PolygonCollider2D> ().enabled = true;
			invoke = true;
		}

		if (isMoving && invoke) {
			Invoke ("CheckCameraMove", 0.3f);
		}
	}

	public void CheckCameraMove ()
	{
		StopCoroutine ("MoveLeft");
		StopCoroutine ("MoveRight");

		if (orientation == 1)
			StartCoroutine ("MoveRight", waitTimetoTurn);
		else if (orientation == 0)
			StartCoroutine ("MoveLeft", waitTimetoTurn);

	}

	public IEnumerator MoveLeft (float waitT)
	{
		yield return new WaitForSeconds (waitT);
		orientation = 0;
		anim.SetTrigger ("MoveLeft");
		StartCoroutine ("MoveRight", waitTimetoTurn);
	}

	public IEnumerator MoveRight (float waitT)
	{
		yield return new WaitForSeconds (waitT);
		orientation = 1;
		anim.SetTrigger ("MoveRight");

		StartCoroutine ("MoveLeft", waitTimetoTurn);
	}
}
