using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RegisterNumbers : MonoBehaviour
{

	public static string correctCode;
	public static Collider2D col;
	public static GameObject doorToDisable;
	public static BoxCollider2D currentKeyCode;

	[System.NonSerialized]
	public string
		code;
	public GameObject digitBlocker;
	public Text[] digits = new Text[4];
	public Image wrongRight;
	AudioClip clip;
	AudioClip clip2;
	AudioClip clip3;

	void Awake()
	{
		clip=Resources.Load("Music/beep-03") as AudioClip;
		clip2=Resources.Load("Music/door-shut-04") as AudioClip;
		clip3=Resources.Load("Music/beep-01") as AudioClip;
	}

	public void RegisterCode (int number)
	{
		AudioSource.PlayClipAtPoint(clip, this.transform.position);

		code += number.ToString ();

		digits [code.Length - 1].text = number.ToString ();

		if (code.Length == 4) {
			if (code == correctCode) {
				AudioSource.PlayClipAtPoint(clip2, this.transform.position);
				doorToDisable.GetComponent<SpriteRenderer>().enabled=false;
				doorToDisable.GetComponent<BoxCollider2D>().enabled=true;
				currentKeyCode.enabled=false;

				StartCoroutine ("RemoveDigits", true);
				wrongRight.color = new Color (0, 1, 0, 0.5f);
			} else {
				AudioSource.PlayClipAtPoint(clip3, this.transform.position);
				wrongRight.color = new Color (1, 0, 0, 0.5f);
				StartCoroutine ("RemoveDigits", false);
			}

			digitBlocker.SetActive (true);

		}
		
	}

	public void RemoveDigits2 ()
	{
		code = null;
		for (int i=0; i<4; i++)
			digits [i].text = null;
		digitBlocker.SetActive (false);
		wrongRight.color = new Color (0, 0, 0, 0);
	}

	IEnumerator RemoveDigits (bool correct)
	{
		code = null;
		yield return new WaitForSeconds (1f);
		for (int i=0; i<4; i++)
			digits [i].text = null;
		digitBlocker.SetActive (false);
		wrongRight.color = new Color (0, 0, 0, 0);

		if (correct) {
			this.gameObject.transform.parent.GetComponent<ActivateKeyCode>().Disable(col);
		}
	}


}
