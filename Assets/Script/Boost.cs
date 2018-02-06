/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {

	public CarController CC;

	public void Awake()
	{
		CC = GameObject.FindGameObjectWithTag("Player").GetComponent<CarController>();
	}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			CC.Boost();
		}
	}
}
