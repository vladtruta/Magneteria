using UnityEngine;
using System.Collections;

public class PadlockMove : MonoBehaviour
{

	GameObject magnet1;
	GameObject magnet2;
	[System.NonSerialized]
	public BoxCollider2D
		mid1;
	[System.NonSerialized]
	public BoxCollider2D
		mid2;
	Animator anim1;
	Animator anim2;
	public static bool moveLeft1 = true;
	public static bool moveRight1 = true;
	public static bool moveLeft2 = true;
	public static bool moveRight2 = true;

	void Awake ()
	{
		magnet1 = transform.Find ("magnet1").gameObject;
		magnet2 = transform.Find ("magnet2").gameObject;
		mid1 = magnet1.transform.Find ("mid").GetComponent<BoxCollider2D> ();
		mid2 = magnet2.transform.Find ("mid").GetComponent<BoxCollider2D> ();
		anim1 = magnet1.GetComponent<Animator> ();
		anim2 = magnet2.GetComponent<Animator> ();
		mid1.enabled = false;
		mid2.enabled = false;
	}

	void Update ()
	{
		if (!OpenMainMenu.pauseMenuActive) {
			if (Input.GetKey (KeyCode.A) && moveLeft1) {
				magnet1.transform.Translate (Vector3.left * 0.9f);
				mid1.enabled = true;
				anim1.enabled = false;
			}
			if (Input.GetKey (KeyCode.D) && moveRight1) {
				magnet1.transform.Translate (Vector3.right * 0.9f);
				mid1.enabled = true;
				anim1.enabled = false;
			}
			if (Input.GetKey (KeyCode.LeftArrow) && moveLeft2) {
				magnet2.transform.Translate (Vector3.left * 0.9f);
				mid2.enabled = true;
				anim2.enabled = false;
			}
			if (Input.GetKey (KeyCode.RightArrow) && moveRight2) {
				magnet2.transform.Translate (Vector3.right * 0.9f);
				mid2.enabled = true;
				anim2.enabled = false;
			}
		}
	}

}
