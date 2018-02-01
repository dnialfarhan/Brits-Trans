/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStat : MonoBehaviour {

	public Text scoreText;

	public float scoreValue;

	public void Awake()
	{
		scoreValue = 0;
	}

	public void AddScore()
	{
		scoreValue = scoreValue + 1;
		scoreText.text = "Star Rating: " + scoreValue;

	}
}
