using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float time = 0;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, time);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
