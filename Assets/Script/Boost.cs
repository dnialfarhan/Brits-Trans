/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine;

public class Boost : MonoBehaviour {

	public CarController carControl;

	public void Awake()
	{
		carControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CarController>();
	}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			carControl.Boost();
		}
	}
}
