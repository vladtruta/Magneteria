using UnityEngine;
using System.Collections;

public class GuardsAI : MonoBehaviour
{

	public float speed;
	public float orientation;
	public float waitTimetoTurn;
	Vector3 dir = Vector3.left;
	RaycastHit2D hit;
	RaycastHit2D spot;
	bool isHit;
	Animator anim;
	GuardHandler guardHandler;


	void Awake()
	{
		guardHandler=GameObject.Find ("UI").GetComponent<GuardHandler>();

	}

	void Start ()
	{
		anim = gameObject.GetComponent<Animator> ();
		anim.SetFloat ("IdleAnim", orientation);
		this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = TransformFormat.getYVel (1f);
	
		CheckMove();
		
	}
	public void CheckMove()
	{
		StopCoroutine("MoveLeft");
		StopCoroutine("MoveRight");

		if (orientation==0)
		{
			dir = Vector3.left;
			StartCoroutine("MoveLeft", 0.6f);
		
		}
			else if (orientation==1)
		{
			dir = Vector3.right;
			StartCoroutine("MoveRight", 0.6f);
		}
	}
	void Update ()
	{
		Debug.DrawRay(transform.position, dir*Mathf.Infinity, Color.red, 0f);
		hit = Physics2D.Raycast (transform.position, dir, TransformFormat.getXVel (1f));
		spot = Physics2D.Raycast (transform.position, dir, Mathf.Infinity);

		if (hit && (hit.collider.tag == "wall" /*|| hit.collider.tag == "doorway"*/||hit.collider.name=="MainChar"))
			isHit = true;
		else 
			isHit = false;

		if (spot&&spot.collider.name=="MainChar")
		{
			guardHandler.Enable();
		}
	
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name=="MainChar")
			Physics2D.IgnoreCollision(col.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
	}

	public IEnumerator MoveLeft (float waitT)
	{
		orientation=0;
		yield return new WaitForSeconds (waitT);
		dir = Vector3.left;
		isHit=false;

		while (!isHit) {
			transform.Translate (TransformFormat.getTransVel (Vector3.left * speed));
			anim.SetBool ("MoveLeft", true);
			yield return null;
		}

		if (isHit) {
			StopCoroutine ("MoveLeft");
			anim.SetBool ("MoveLeft", false);
			anim.SetFloat ("IdleAnim", 0f);

			StartCoroutine ("MoveRight", waitTimetoTurn);
		}

	}

	public IEnumerator MoveRight (float waitT)
	{
		yield return new WaitForSeconds (waitT);
		orientation=1;
		dir = Vector3.right;
		isHit=false;

		while (!isHit) {

			transform.Translate (TransformFormat.getTransVel (Vector3.right * speed));
			anim.SetBool ("MoveRight", true);
			yield return null;
		}

		if (isHit) {
			StopCoroutine ("MoveRight");
			anim.SetBool ("MoveRight", false);
			anim.SetFloat ("IdleAnim", 1f);

			StartCoroutine ("MoveLeft", waitTimetoTurn);
		}
	}

}
