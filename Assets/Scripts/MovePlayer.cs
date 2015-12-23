using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float speed;
	public GameManager manager;
	public GameObject particles;

	private Vector3 spawn;

	private Vector3 input;
	// Use this for initialization
	public void Start () 
	{
		spawn = transform.position;
		



	
	}
	
	// Update is called once per frame
	public void FixedUpdate () 
	{
		input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")) ;
		if( GetComponent<Rigidbody>().velocity.magnitude < 20f )
			GetComponent<Rigidbody> ().AddForce (input * speed);

		if (transform.position.y < -2) 
		{
			Die ();
		}
	
	}

	public void OnCollisionEnter( Collision other)
	{
		if (other.transform.tag == "Enemy") 
		{
			Die ();
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Enemy")
		{
			
			Die ();
			
		}
		if (other.transform.tag == "Goal")
		{

			GameManager.CompleteLevel();
			Time.timeScale = 0f ;

		}
		if (other.transform.tag == "Token")
		{
			
			GameManager.AddToken();
			Destroy(other.gameObject);
			
		}
	}
	public void Die()
	{
		Instantiate( particles, transform.position, Quaternion.Euler(270, 0, 0));
		transform.position = spawn;
	}



}
