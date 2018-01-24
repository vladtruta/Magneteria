using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
	
	GameObject menuPanel;
	GameObject levelPanel;
	GameObject startAgain;
	GameObject playButton;
	GameObject continueButton;
	Button levelsButton;

	void Awake ()
	{
		menuPanel = transform.Find ("PauseMenu/MenuButtons").gameObject;
		levelPanel = transform.Find ("PauseMenu/Levels").gameObject;
		startAgain = transform.Find ("PauseMenu/MenuButtons/StartAgain").gameObject;
		playButton = menuPanel.transform.Find ("Play!").gameObject;
		continueButton = menuPanel.transform.Find ("Continue!").gameObject;
		levelsButton=menuPanel.transform.Find("LevelsButton").GetComponent<Button>();
	}

	void Start ()
	{
		
		StartAgainCheck ();
	
		if (PlayerPrefs.GetInt ("GameFinished") == 1) 
			levelsButton.interactable=true;
		else 
			levelsButton.interactable=false;
	}

	public void StartAgainCheck ()
	{
		if (PlayerPrefs.GetInt ("SavedGame") == 1) {
			playButton.SetActive (false);
			continueButton.SetActive (true);
			startAgain.SetActive (true);
		} else {
			playButton.SetActive (true);
			continueButton.SetActive (false);
			startAgain.SetActive (false);
		}
	}

	public void Load (int level)
	{
		Application.LoadLevel (level);
		PlayerPrefs.SetString ("Command", "save");
	}

	public void LoadSaved ()
	{
		Application.LoadLevel (PlayerPrefs.GetInt ("SavedLevel"));
		PlayerPrefs.SetString ("Command", "load");
	}

	public void PlayFirst ()
	{
		Load (1);
		PlayerPrefs.SetString ("Command", "save");
	}
	public void LevelPanel()
	{
		menuPanel.SetActive (false);
		levelPanel.SetActive (true);
	}
	public void Back ()
	{
		levelPanel.SetActive (false);
		menuPanel.SetActive (true);	
	}

	public void Exit ()
	{
		Application.Quit ();
	}
public void DeleteSaves()
	{
		PlayerPrefs.DeleteAll();
		Application.LoadLevel(0);
	}
}
