using UnityEngine;
using System.Collections;

public class Again : MonoBehaviour {


	public void Load(int level)
	{
		Application.LoadLevel(level);
	}
public void Exit()
	{
		Application.Quit();
	}
}
