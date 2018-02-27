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

	public float Rotator = 200f;


	public void Update()
	{
		transform.Rotate(new Vector3(0, 0, Rotator) * Time.deltaTime);
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
            //Instantiate Object
            Instantiate(pickupEffect, transform.position, transform.rotation);
            

			//Add effect
			PlayerStat.GetComponent<PlayerStat>().StarRating();

			FindObjectOfType<AudioManager>().Play("StarRating");


			//Destroy Object
			Destroy(gameObject);
		}

	}

	
}

