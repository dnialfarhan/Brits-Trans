/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {

	// Use this for initialization
	public void Start () 
	{
		
	}
	
	
	public void ReturnNetworkMenu ()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
