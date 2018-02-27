/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startscript : MonoBehaviour {

	public GameObject StartPoint;
	// Use this for initialization
	void Start()
	{
		Invoke("SetUp", 2.0f);
		Debug.Log("AAAA");
	}
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SetUp() {
		Debug.Log("SSSSS");
		GameObject character = GameObject.Find("TaxiCab(Clone)");
		//GameObject character2 = GameObject.Find("TaxiCab(Clone)");

		GameObject characterParent = GameObject.Find("ImageTarget");

		character.transform.parent = characterParent.transform;

		character.transform.position = StartPoint.transform.position;
		character.transform.rotation = StartPoint.transform.rotation;
		//character2.transform.parent = characterParent.transform;
	}
}
