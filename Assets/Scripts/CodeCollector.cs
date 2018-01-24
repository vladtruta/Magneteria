using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CodeCollector : MonoBehaviour
{

	CodeHandler codeHandler;
	[System.NonSerialized]
	public string codeToShow;
	public KeyCodeScript keycodescript;


	void Awake ()
	{
		codeHandler = GameObject.Find ("UI").GetComponent<CodeHandler> ();
		for (int i=1; i<=4; i++)
			codeToShow += Random.Range (0, 10).ToString ();

		keycodescript.correctCode = codeToShow;
	}

	void Start()
	{
		CodeHandler.codeToShow = codeToShow;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.name == "MainChar") {
			//CodeHandler.codeToShow = codeToShow;
			codeHandler.Enable (col);
			CodeHandler.charCol=col;
			Destroy (this.gameObject);
		}
	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.name == "MainChar") {
			if (Input.GetKeyDown (KeyCode.R)) {
				codeHandler.Disable (col);
			}
		}
	}
		
}


