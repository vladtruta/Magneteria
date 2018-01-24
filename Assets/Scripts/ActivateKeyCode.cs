using UnityEngine;
using System.Collections;

public class ActivateKeyCode : BaseHandler
{

	public GameObject codeUI;




	public override void Enable (Collider2D col)
	{
		codeUI.SetActive (true);
		base.Enable(col);
		OpenMainMenu.exitButton+=Disable;
		OpenMainMenu.exitColl=col;
	}

	public override void Disable (Collider2D col)
	{
		codeUI.SetActive (false);
		base.Disable(col);
		codeUI.GetComponent<RegisterNumbers> ().RemoveDigits2 ();
		RegisterNumbers.doorToDisable=null;
		RegisterNumbers.correctCode=null;
		RegisterNumbers.col=null;
		RegisterNumbers.currentKeyCode=null;	

		OpenMainMenu.exitButton-=Disable;
		OpenMainMenu.exitColl=null;

	}
}
