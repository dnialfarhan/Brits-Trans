/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Audio : MonoBehaviour {

	private void MainMenuAudio()
	{
		FindObjectOfType<AudioManager>().Play("MainMenu");
	}
}
