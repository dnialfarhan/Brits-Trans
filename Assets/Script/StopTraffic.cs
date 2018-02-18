/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTraffic : MonoBehaviour {

	public CarController CC;

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			CC.Stop();

			Debug.Log("Hit red light!");
		}
	}
}
