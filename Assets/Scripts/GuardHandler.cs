using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GuardHandler : OpenMainMenu
{

	[System.NonSerialized]
	public GameObject
		bustedUI;
	LifeManager lManager;
	AudioClip clip;

	new protected void Awake ()
	{
		bustedUI = transform.Find ("LoseMenu").gameObject;
		lManager = this.transform.Find ("BottomMenu").GetComponent<LifeManager> ();
		clip=Resources.Load("Music/432400_SOUNDDOGS__sc") as AudioClip;
		base.Awake ();
	}

	void Update ()
	{
		//clear double call from base class
		//print (base.UIelements.Length);
	}

	new public void Enable ()
	{
		blockRaycasts.SetActive (true); //pur estetic
		StartCoroutine ("EnableIt");
	}

	new public void Disable ()
	{
		bustedUI.SetActive(false);
		StopCoroutine("EnableIt");
		blockRaycasts.SetActive (false);
		base.Disable ();
	}

	IEnumerator EnableIt ()
	{
		yield return new WaitForSeconds (0.2f);
		AudioSource.PlayClipAtPoint(clip, this.transform.position, 0.7f);
		lManager.LoseLife ();
	

		if (LifeManager.livesLeft == 0) {
			bustedUI.transform.Find ("Text").GetComponent<Text> ().text = "GAME OVER!";
			bustedUI.transform.Find ("Panel/StartOver").gameObject.SetActive (true);
			bustedUI.transform.Find ("Panel/Retry").gameObject.SetActive (false);
			LifeManager.livesLeft = 3;
			PlayerPrefs.SetInt ("SavedGame", 0);
		} else if (LifeManager.livesLeft > 0) {
			bustedUI.transform.Find ("Text").GetComponent<Text> ().text = "BUSTED!";
			bustedUI.transform.Find ("Panel/StartOver").gameObject.SetActive (false);
			bustedUI.transform.Find ("Panel/Retry").gameObject.SetActive (true);
		
			saveScript.SaveGame();
			PlayerPrefs.SetString("Command", "load");
			PlayerPrefs.SetString("Position", "begin");
		}


		base.Enable ();
		bustedUI.SetActive (true);

		GameObject.Find ("UI/RaycastBlocker/Exit").gameObject.SetActive(false);
	}

	public void Retry ()
	{
		Disable ();
		Application.LoadLevel(Application.loadedLevel);
	}

	public void StartOver ()
	{
		Disable ();
		Application.LoadLevel (0);
	}
}
