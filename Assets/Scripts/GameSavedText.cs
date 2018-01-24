using UnityEngine;
using System.Collections;

public class GameSavedText : MonoBehaviour {

	public GameObject savedText;

	public void DisblayIt()
	{
		StopCoroutine("Display");
		savedText.SetActive(true);
		StartCoroutine("Display");
	}
	public IEnumerator Display()
	{
		Time.timeScale=1;
		yield return new WaitForSeconds (0.6f);
		savedText.SetActive(false);
		Time.timeScale=0;
	}
}
