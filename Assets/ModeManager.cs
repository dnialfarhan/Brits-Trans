/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour {

	public void SinglePlayer()
	{
		SceneManager.LoadScene("Level1(Nottingham)_SinglePlayer");
	}

	public void MultiPlayer()
	{
		SceneManager.LoadScene("NetworkMenu");
	}
}
