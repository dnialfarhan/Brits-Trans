/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine;

public class Star : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(new Vector3(0, 0, 200) * Time.deltaTime);
	}
}
