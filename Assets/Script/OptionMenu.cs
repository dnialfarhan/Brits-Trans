/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void DownloadMaker()
	{
		Application.OpenURL("https://drive.google.com/file/d/1A_XKzfv6gWCt8K2W38YEAD6o03QGlrOK/view?usp=sharing");
	}
}
