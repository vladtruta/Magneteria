using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenMainMenu : MonoBehaviour
{

	protected GameObject PauseMenu;
	public static bool pauseMenuActive;
	protected CharacterController mainChar;
	protected GameObject[] guardsObj;
	List<GuardsAI> guardsAI = new List<GuardsAI> ();
	public GameObject[] UIelements;
	Animator anim;
	GuardHandler gHandler;
	protected GameObject blockRaycasts;
	protected SaveScript saveScript;

	public static Collider2D exitColl;
	public delegate void ExitDelegate(Collider2D col);
	public static event ExitDelegate exitButton;
	

	protected void Awake ()
	{
		PauseMenu = this.gameObject.transform.Find ("PauseMenu").gameObject;
		mainChar = GameObject.Find ("MainChar").GetComponent<CharacterController> ();
		anim = mainChar.GetComponent<Animator> ();
		guardsObj = GameObject.FindGameObjectsWithTag ("Guard");
		gHandler = this.gameObject.GetComponent<GuardHandler> ();
		blockRaycasts = transform.Find ("RaycastBlocker").gameObject;

		if (guardsObj.Length > 0) {
			for (int i=0; i<guardsObj.Length; i++)
				guardsAI.Add (guardsObj [i].gameObject.GetComponent<GuardsAI> ());
		}

		saveScript=gameObject.GetComponent<SaveScript>();
	}
	void Start()
	{
		this.transform.Find ("RaycastBlocker/Exit").gameObject.SetActive(true);
	}
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			print (111);

		if (Input.GetKeyDown (KeyCode.Escape) && !gHandler.bustedUI.gameObject.activeSelf) {
			pauseMenuActive = !pauseMenuActive;
			if (pauseMenuActive)
				Enable ();
			else
				Disable ();

			PauseMenu.SetActive (pauseMenuActive);
		}
	
	}

	public void Enable ()
	{

		pauseMenuActive = true;
		Time.timeScale = 0;
		mainChar.enabled = false;
		foreach (GuardsAI gAI in guardsAI) {
			gAI.StopCoroutine ("MoveLeft");
			gAI.StopCoroutine ("MoveRight");
			gAI.enabled = false;	
		}
	}

	public void Disable ()
	{
		pauseMenuActive = false;
		bool activeGO = false;

		Time.timeScale = 1;


		foreach (GameObject uiEl in UIelements) {
			if (uiEl.activeSelf) {
				activeGO = true;
				break;
			} else
				activeGO = false;
		}


		if (!activeGO) {
			mainChar.enabled = true;
			anim.SetBool ("MoveLeft", false);
			anim.SetBool ("MoveRight", false);
			anim.SetBool ("onLadder", false);
		}

		PauseMenu.SetActive (false);


		foreach (GuardsAI gAI in guardsAI) {
			gAI.enabled = true;
			gAI.CheckMove ();

			Animator localAnim = gAI.gameObject.GetComponent<Animator> ();
			localAnim.SetBool ("MoveLeft", false);
			localAnim.SetBool ("MoveRight", false);
		}	
	}

	public void DisableAllObjects()
	{
		foreach (GameObject uiEl in UIelements)
			if (uiEl.activeSelf)
				uiEl.SetActive(false);
	}

	public void Exit ()
	{
		gHandler.Disable ();
		saveScript.SaveGame();
		Application.LoadLevel(0);
	}
	public void ExitNoSave()
	{
		gHandler.Disable ();
		Application.LoadLevel(0);
	}

	public void ExitButton()
	{
		exitButton(exitColl);
		CircuitHandler.isEnabled=false;
	}
	
}
