/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startscript : MonoBehaviour {

	public GameObject StartPoint1;

	public GameObject StartPoint2;
	

	void Start()
	{
		Invoke("SetUp", 2.0f);
	}

	public void SetUp() {

		GameObject character1 = GameObject.Find("TaxiCab_Multiplayer(Clone)");

		GameObject character2 = GameObject.Find("TaxiCab_Multiplayer(Clone)");
	

		GameObject characterParent = GameObject.Find("ImageTarget");

		character1.transform.parent = characterParent.transform;
		character1.transform.position = StartPoint1.transform.position;
		character1.transform.rotation = StartPoint1.transform.rotation;

		character2.transform.parent = characterParent.transform;
		character2.transform.position = StartPoint2.transform.position;
		character2.transform.rotation = StartPoint2.transform.rotation;
	
	}
}
