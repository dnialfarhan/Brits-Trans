/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine;

public class Boost : MonoBehaviour {

	public CarController carControl;

	// Update is called once per frame
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			carControl.Boost();
		}
	}
}
