/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSound : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		FindObjectOfType<AudioManager>().Play("InGame");
	}
	
	
}
