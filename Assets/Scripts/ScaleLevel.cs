using UnityEngine;
using System.Collections;

public class ScaleLevel : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Vector3 tmpPos = Camera.main.WorldToScreenPoint (transform.position);

		this.transform.localScale=tmpPos;
	}
	

}
