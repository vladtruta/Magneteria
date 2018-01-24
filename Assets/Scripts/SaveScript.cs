using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SaveScript : MonoBehaviour
{
	
	CodeHandler cHandler;
	GameObject mainChar;
	GameObject[] doorObj;
	List<DoorScript> doorScript = new List<DoorScript> ();
	GameObject laser;
	GameObject blastDoor;
	BoxCollider2D keyCode;
	BoxCollider2D circuitBoard;

	void Awake ()
	{
		cHandler = gameObject.GetComponent<CodeHandler> ();
		mainChar = GameObject.Find ("MainChar").gameObject;
		doorObj = GameObject.FindGameObjectsWithTag ("doorway");
		laser = GameObject.Find ("laser");
		blastDoor=GameObject.Find ("blastDoor");
		circuitBoard=GameObject.Find ("circuitBoard").GetComponent<BoxCollider2D>();
		keyCode=GameObject.Find ("keyCode").GetComponent<BoxCollider2D>();

		if (doorObj.Length > 0) {
			int i;

			for (i=0; i<doorObj.Length; i++)
				doorScript.Add (doorObj [i].GetComponent<DoorScript> ());
		}
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.M))
			PlayerPrefs.DeleteAll();
	}
	public void SaveGame () //SAVE
	{
		PlayerPrefs.SetInt ("SavedGame", 1);

		PlayerPrefs.SetInt ("SavedLevel", Application.loadedLevel);


		PlayerPrefs.SetFloat ("posX", mainChar.transform.position.x);
		PlayerPrefs.SetFloat ("posY", mainChar.transform.position.y);

		if (EndScene.hasEvidence == true)    //evidenceu
			PlayerPrefs.SetInt ("HasEvidence", 1);
		else 
			PlayerPrefs.SetInt ("HasEvidence", 0);


		if (cHandler.codeStore.IsInteractable ()) //o gasit codu? (CODU RAMANE TOT RANDOM! E VORBA DOAR DE BUTON)
			PlayerPrefs.SetInt ("CodeStoreInteractable", 1);
		else 
			PlayerPrefs.SetInt ("CodeStoreInteractable", 0);
	

		int i = 0;
		foreach (DoorScript dSC in doorScript) { //usile deschise sau inchise!
			if (dSC.locked)
				PlayerPrefs.SetInt ("DoorLocked" + i.ToString (), 1);
			else 
				PlayerPrefs.SetInt ("DoorLocked" + i.ToString (), 0);
			i++;
		}


		if (laser.activeSelf)//laseru
			PlayerPrefs.SetInt ("LaserActive", 1);
		else 
			PlayerPrefs.SetInt ("LaserActive", 0);


		if (blastDoor.GetComponent<SpriteRenderer>().enabled==true) //blast door
			PlayerPrefs.SetInt("BlastDoorEnabled", 1);
		else 
			PlayerPrefs.SetInt("BlastDoorEnabled", 0);

		if (circuitBoard.enabled==true)
			PlayerPrefs.SetInt("CircuitBoardEnabled", 1); //circuit board;
		else 
			PlayerPrefs.SetInt("CircuitBoardEnabled", 0);

		PlayerPrefs.SetInt ("LivesLeft", LifeManager.livesLeft);
	}

	public void LoadGame () //LOAD
	{

		mainChar.transform.position = new Vector2 (PlayerPrefs.GetFloat ("posX"), PlayerPrefs.GetFloat ("posY"));

		if (PlayerPrefs.GetInt ("HasEvidence") == 1) { //evidenceu
			EndScene.hasEvidence = true;
			cHandler.evidenceSquare.GetComponent<Image> ().sprite = cHandler.evidenceIcon;
		} else {
			EndScene.hasEvidence = false;
		}


		if (PlayerPrefs.GetInt ("CodeStoreInteractable") == 1) {  //o gasit codu? (CODU RAMANE TOT RANDOM! E VORBA DOAR DE BUTON)
			CodeHandler.charCol=mainChar.GetComponent<BoxCollider2D>();
			cHandler.codeStore.interactable = true;
			cHandler.codeStore.transform.Find ("Image").GetComponent<Image> ().color=new Color(1,1,1,1);
			cHandler.codeStore.transform.Find ("Image").GetComponent<Image> ().sprite=cHandler.smallFile;
			Destroy(GameObject.Find ("code generator"));
		} else {
			cHandler.codeStore.interactable = false;
			cHandler.codeStore.transform.Find ("Image").GetComponent<Image> ().color=new Color(1,1,1,0);
			cHandler.codeStore.transform.Find ("Image").GetComponent<Image> ().sprite=null;
		}


		int i = 0;

		foreach (DoorScript dSC in doorScript) { //usile deschise sau inchise!
			if (PlayerPrefs.GetInt ("DoorLocked" + i.ToString ()) == 1) {
				dSC.locked = true;

				if (dSC.gameObject.transform.Find ("lock"))
					dSC.gameObject.transform.Find ("lock").gameObject.SetActive (true);
			} else { 
				dSC.locked = false;

				if (dSC.gameObject.transform.Find ("lock"))
					dSC.gameObject.transform.Find ("lock").gameObject.SetActive (false);
			}
			i++;
		}

		if (PlayerPrefs.GetInt ("LaserActive") == 1)//laseru
			laser.SetActive (true);
		else 
			laser.SetActive (false);


		if (PlayerPrefs.GetInt("BlastDoorEnabled")==1) //blast door
		{
			blastDoor.GetComponent<SpriteRenderer>().enabled=true;
			blastDoor.GetComponent<BoxCollider2D>().enabled=false;
			keyCode.enabled=true;
		}
		else {
			blastDoor.GetComponent<SpriteRenderer>().enabled=false;
			blastDoor.GetComponent<BoxCollider2D>().enabled=true;
			keyCode.enabled=false;
		}

		if (PlayerPrefs.GetInt("CircuitBoardEnabled")==1) //circuit board
			circuitBoard.enabled=true;
		else 
			circuitBoard.enabled=false;
	

		LifeManager.livesLeft = PlayerPrefs.GetInt ("LivesLeft");
		//print (PlayerPrefs.GetInt("LivesLeft"));
//		lManager.ChangeLife (PlayerPrefs.GetInt ("LivesLeft"));
	}
}
