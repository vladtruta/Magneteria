using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PadlockHandler : BaseHandler
{
	public Image[] leftLocks;
	public Image[] rightLocks;
	public static bool lockLeft;
	public static bool lockRight;
	public GameObject padlockOpener;
	public Image[] finalPanels;




	public void DeactivateLocks (string dir)
	{
		if (dir == "left") {
			for (int i=0; i<leftLocks.Length; i++)
				leftLocks [i].enabled = false;
		} else if (dir == "right") {
			for (int i=0; i<rightLocks.Length; i++)
				rightLocks [i].enabled = false;
		}
	}

	public void ActivateLocks (string dir)
	{
		if (dir == "left") {
			for (int i=0; i<leftLocks.Length; i++)
				leftLocks [i].enabled = true;
		} else if (dir == "right") {
			for (int i=0; i<rightLocks.Length; i++)
				rightLocks [i].enabled = true;
		}
	}

	public void CheckLocks ()
	{
		if (lockLeft && lockRight)
		{
			MoveLockUp.ableToMove=true;
			finalPanels[0].color=new Color(0,1, 0, 0.5f);
			finalPanels[1].color=new Color(0,1, 0, 0.5f);
		}
	}

	public override void Enable (Collider2D col)
	{
		OpenMainMenu.exitButton+=Disable;
		OpenMainMenu.exitColl=col;
		padlockOpener.SetActive (true);
		base.Enable(col);
	}

	public override void Disable(Collider2D col)
	{
		OpenMainMenu.exitButton-=Disable;
		OpenMainMenu.exitColl=null;		

		padlockOpener.SetActive (false);
		base.Disable(col);
		padlockOpener.transform.Find ("magnet1").GetComponent<Animator>().enabled=true;
		padlockOpener.transform.Find ("magnet2").GetComponent<Animator>().enabled=true;
		lockLeft=false;
		lockRight=false;
		PadlockMove.moveLeft1=true;
		PadlockMove.moveLeft2=true;
		PadlockMove.moveRight1=true;
		PadlockMove.moveRight2=true;
		padlockOpener.transform.Find ("magnet1/mid").GetComponent<BoxCollider2D>().enabled=false;
		padlockOpener.transform.Find ("magnet2/mid").GetComponent<BoxCollider2D>().enabled=false;
		ActivateLocks ("left");
		ActivateLocks ("right");
		MoveLockUp.ableToMove=false;
		padlockOpener.transform.Find ("midsection").GetComponent<MoveLockUp>().Reset();
		finalPanels[0].color=new Color(1,0, 0, 0.5f);
		finalPanels[1].color=new Color(1,0, 0, 0.5f);
		MoveLockUp.lockToUnlock=null;
		MoveLockUp.coll=null;

	}
}
