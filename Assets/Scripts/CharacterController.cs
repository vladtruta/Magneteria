using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
	public float speed;
	public float orientation;
	Vector3 dir = Vector3.left;
	RaycastHit2D hit;
	bool isHit;
	Animator anim;
	SaveScript saveScript;

	void Awake ()
	{
		saveScript = GameObject.Find ("UI").GetComponent<SaveScript> ();
		anim = gameObject.GetComponent<Animator> ();
	}

	void Start ()
	{
		anim.SetFloat ("IdleAnim", orientation);
		this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = TransformFormat.getYVel (1f);

		if (PlayerPrefs.GetString ("Command") == "save")
			saveScript.SaveGame ();
		 if (PlayerPrefs.GetString ("Command") == "load")
			saveScript.LoadGame ();

		if (PlayerPrefs.GetString("Position")=="begin"||PlayerPrefs.GetString("Command")!="load")
			this.transform.position = GameObject.Find ("SpawnPosition").transform.position;

		PlayerPrefs.DeleteKey("Position");
		PlayerPrefs.DeleteKey("Command");
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.B))
			saveScript.SaveGame();

		Debug.DrawRay (transform.position, dir * TransformFormat.getXVel (1f), Color.red, 0f);
		hit = Physics2D.Raycast (transform.position, dir, TransformFormat.getXVel (1f), 13);

		

		if (hit && (hit.collider.tag == "wall" /*|| hit.collider.tag == "doorway"*/))
			isHit = true;
		else 
			isHit = false;
		Move ();
	
	}

	void Move ()
	{
		if (Input.GetButton ("MoveLeft")) {
			if (!isHit) {
				transform.Translate (TransformFormat.getTransVel (Vector3.left * speed));
				anim.SetBool ("MoveLeft", true);
			}
			dir = Vector3.left;
		}
		if (Input.GetButton ("MoveRight")) {
			if (!isHit) {
				transform.Translate (TransformFormat.getTransVel (Vector3.right * speed));
				anim.SetBool ("MoveRight", true);
			}
			dir = Vector3.right;
		}
		if (Input.GetButton ("MoveLeft") && Input.GetButton ("MoveRight")) {
			anim.SetBool ("MoveLeft", false);
			anim.SetBool ("MoveRight", false);
		}
		
		if (Input.GetButtonUp ("MoveLeft") || isHit) {
			anim.SetBool ("MoveLeft", false);
			if (dir == Vector3.left)
				anim.SetFloat ("IdleAnim", 0f);
		}
		
		if (Input.GetButtonUp ("MoveRight") || isHit) {
			anim.SetBool ("MoveRight", false);
			if (dir == Vector3.right)
				anim.SetFloat ("IdleAnim", 1f);
		}
	}
}
