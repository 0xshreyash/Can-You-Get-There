using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour 
{

	public Transform[] boundaries;
	public float speed; 
	private int currentpos;


	// Use this for initialization
	void Start () 
	{
		transform.position = boundaries[0].position;
		currentpos = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position == boundaries[currentpos].position)		
		{
			currentpos++;

		}

		if (currentpos == boundaries.Length) 
		{
			currentpos = 0;
		}

		transform.position = Vector3.MoveTowards (transform.position, boundaries [currentpos].position, speed * Time.deltaTime);
	}
}
