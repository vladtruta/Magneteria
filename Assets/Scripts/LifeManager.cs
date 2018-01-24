using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{

	GameObject[] lifeGO = new GameObject[3];
	public static int livesLeft = 3;

	void Awake ()
	{
		//testNumber--;
		for (int i=0; i<3; i++)
			lifeGO [i] = this.transform.Find ("Life" + (i + 1).ToString ()).gameObject;
	}

	void Start ()
	{
		ChangeLife (livesLeft);
	}


	public void LoseLife ()
	{
		livesLeft--;
		ChangeLife (livesLeft);
	}
	public void ChangeLife (int livesLeft)
	{
		int i;
		if (livesLeft >= 0&&livesLeft<3)
			for (i=livesLeft; i<3; i++)
				lifeGO [i].GetComponent<Image> ().color = new Color(1,1,1,0.2f);
	}
}
