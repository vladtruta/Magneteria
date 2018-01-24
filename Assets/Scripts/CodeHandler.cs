using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CodeHandler : BaseHandler
{
	
	public GameObject codeFileUI;
	public static string codeToShow;
	public Button codeStore;
	public Sprite smallFile;
	public static Collider2D charCol;
	public GameObject evidenceSquare;
	public Sprite evidenceIcon;
	Collider2D temporaryCol;

	public override void Enable (Collider2D col)
	{
		codeFileUI.SetActive (true);
		base.Enable (col);
		codeFileUI.transform.Find ("CodeText").GetComponent<Text> ().text = codeToShow;
		codeStore.interactable = true;
		codeStore.transform.Find ("Image").GetComponent<Image> ().color = new Color (1, 1, 1, 1);
		codeStore.transform.Find ("Image").GetComponent<Image> ().sprite = smallFile;
		OpenMainMenu.exitButton+=Disable;
		OpenMainMenu.exitColl=col;

	}

	public override void Disable (Collider2D col)
	{
		temporaryCol=col;
		codeFileUI.SetActive (false);
		base.Disable (col);
		OpenMainMenu.exitButton-=Disable;
		OpenMainMenu.exitColl=null;
	}

	public void EnableSimple ()
	{
		OpenMainMenu.exitButton+=Disable;
		OpenMainMenu.exitColl=temporaryCol;

		codeFileUI.transform.Find ("CodeText").GetComponent<Text> ().text = codeToShow;
		blockRaycasts.SetActive (true);
		codeFileUI.SetActive (true);
		charCol.GetComponent<CharacterController> ().enabled = false;
		Animator anim = charCol.GetComponent<Animator> ();
		anim.SetBool ("MoveLeft", false);
		anim.SetBool ("MoveRight", false);
		anim.SetBool ("onLadder", true);

	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R) && codeFileUI.activeSelf)
			Disable (charCol);

	}

	public void CollectEvidence ()
	{
		EndScene.hasEvidence = true;
		evidenceSquare.GetComponent<Image> ().sprite = evidenceIcon;
	}
}
