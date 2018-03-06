/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public float countTimer = 90f;
	public GameObject gameOver;

	[SerializeField]
	private TextMeshProUGUI CountDown;

	private void Start()
	{
		CountDown = GetComponent<TextMeshProUGUI>();	
	}

	private void Update()
	{
		countTimer -= Time.deltaTime;

		string minute = ((int) countTimer / 60).ToString();

		string second = (countTimer % 60).ToString("f0");

		CountDown.text = minute + ":" + second;

		if (countTimer <= 0f){

			gameOver.SetActive(true);
			Time.timeScale = 0f;
		}
	}


}
