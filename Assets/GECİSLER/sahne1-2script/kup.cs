using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kup : MonoBehaviour {

	public float x = 0;
	public float y = 0;
	public float z = 0;

	void Start () {
		x = -0.7f; y = -1; z = 0;

		//x = Random.Range (-8.0f,8.0f);
		//y = Random.Range (-4.0f,4.0f);
		transform.position = new Vector3 (x,y,z);
		karakter_hareket kh = new karakter_hareket ();

	}

	// Update is called once per frame
	void Update () { 
	}
}
