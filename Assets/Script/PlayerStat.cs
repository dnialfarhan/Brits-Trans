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

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI passangerText;

	private float starRating;
	private float passangerScore;

	public void Awake()
	{
		starRating = 0;
	}

	public void StarRating()
	{
		starRating = starRating + 1;
		scoreText.text = starRating + "/3";
	}

	public void PassangerScore()
	{
		passangerScore = passangerScore + 1;
		passangerText.text = passangerScore + "/3";
	}
}
