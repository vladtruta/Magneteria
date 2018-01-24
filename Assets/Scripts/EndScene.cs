using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour {

	public static bool hasEvidence;
	public string button;
	public int levelToLoad;
	public bool isEndGame;

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.name=="MainChar"&&Input.GetButtonDown(button)&&hasEvidence)
		{
			EndIt ();
		}
	}

	void EndIt()
	{
		if (isEndGame)
		{
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("GameFinished", 1);
		
		}
		else 
			PlayerPrefs.SetString("Command", "save");

		Application.LoadLevel(levelToLoad);
	}

void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
			EndIt();
	}
}