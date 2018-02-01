/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRating : MonoBehaviour {

	public GameObject pickupEffect;

	public GameObject PlayerStat;


	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//Instantiate Object
			Instantiate(pickupEffect, transform.position, transform.rotation);

			//Add effect
			PlayerStat.GetComponent<PlayerStat>().AddScore();


			//Destroy Object
			Destroy(gameObject);
		}

	}

	
}

