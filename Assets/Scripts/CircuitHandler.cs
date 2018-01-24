using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CircuitHandler : BaseHandler
{
	
	public GameObject circuitBoard;
	public GameObject[] icons;
	public Sprite correctIcon;
	public Sprite wrongIcon;
	int correctAnswer;
	public static Collider2D coll;
	public static Collider2D charcoll;
	public static GameObject laserToRemove;
	public Image[] lightCheck;
	public static bool isEnabled=false;
	AudioClip clip;

	void Start()
	{
		clip=Resources.Load("Music/hit-pipe") as AudioClip;
		isEnabled=false;
	}
	public override void Enable (Collider2D col)
	{
		OpenMainMenu.exitButton+=Disable;
		OpenMainMenu.exitColl=col;
		base.Enable(col);
		circuitBoard.SetActive (true);
		Randomize ();
	}

	public override void Disable (Collider2D col)
	{
		base.Disable(col);
		circuitBoard.SetActive (false);
		correctAnswer = 0;
		coll = null;
		charcoll=null;
		laserToRemove = null;
		StartCoroutine ("Flash", false);
		ChangeLightCheckColor (new Color (0, 0, 0, 0));
		OpenMainMenu.exitButton-=Disable;
		OpenMainMenu.exitColl=null;
	}

	void Randomize ()
	{
		correctAnswer = Random.Range (0, 3);
		int i;

		for (i=0; i<3; i++)
			if (i == correctAnswer)
				icons [i].GetComponent<Image> ().sprite = correctIcon;
			else 
				icons [i].GetComponent<Image> ().sprite = wrongIcon;
	
	}

	public void CheckAnswer (int answered)
	{
		AudioSource.PlayClipAtPoint(clip, transform.position);
		if (answered == correctAnswer) {
			laserToRemove.SetActive (false);
			StartCoroutine ("Flash", true);
			ChangeLightCheckColor (new Color (0, 1, 0, 0.5f));
		} else {
			ChangeLightCheckColor (new Color (1, 0, 0, 0.5f));
			StartCoroutine ("Flash", false);
		}


	}

	IEnumerator Flash (bool correct)
	{
		yield return new WaitForSeconds (1f);
		ChangeLightCheckColor (new Color (0, 0, 0, 0));

		if (correct) {
			coll.enabled=false;
			Disable (charcoll);
		}
	}

	void ChangeLightCheckColor (Color colpam)
	{
		for (int i=0; i<3; i++)
			lightCheck [i].color = colpam;
	}
}
