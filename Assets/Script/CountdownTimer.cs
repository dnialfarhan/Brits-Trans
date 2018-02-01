/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public Image fillImg;
	public float timeAmt = 10f;
	public float time;

	public GameObject GameOver;

	private void Awake()
	{
		GameOver.SetActive(false);
	}

	// Use this for initialization
	void Start () 
	{
		fillImg = this.GetComponent<Image>();
		time = timeAmt;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(time > 0)
		{
			time -= Time.deltaTime;
			fillImg.fillAmount = time / timeAmt;
		}

		if(time < 0)
		{
			GameOver.SetActive(true);
		}
	}
}
