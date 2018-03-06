/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine;
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

	public void Start()
	{
		
	}

	public void Update()
	{
		if (passangerScore >= 3f)
		{
			Time.timeScale = 0f;
		}
	}

	public void StarRating()
	{
		starRating = starRating + 1;
		scoreText.text = starRating + "/5";
	}


	public void PassangerScore()
	{
		passangerScore = passangerScore + 1;
		passangerText.text = passangerScore + "/3";
	}

	
}
