/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleList : MonoBehaviour {

	private GameObject[] vehicleList;

	public int index;

	// Use this for initialization
	void Start () 
	{
		vehicleList = new GameObject[transform.childCount];

		// Fill the array with our models
		for (int i = 0; i < transform.childCount; i++)
		{
			vehicleList[i] = transform.GetChild(i).gameObject;
		}

		// We toggle off their renderer
		foreach (GameObject go in vehicleList)
		{
			go.SetActive(false);
		}

		// We toggle on the first
		if (vehicleList[0])
		{
			vehicleList[0].SetActive(true);
		}
		
	}
	
	public void ToggleLeft()
	{
		// Toggle on current model
		vehicleList[index].SetActive(false);

		index--;
		if(index < 0)
		{
			index = vehicleList.Length - 1;
		}

		// Toggle on the new model
		vehicleList[index].SetActive(true);
	}

	public void ToggleRight()
	{
		// Toggle on current model
		vehicleList[index].SetActive(false);

		index++;
		if (index == vehicleList.Length)
		{
			index = 0;
		}

		// Toggle on the new model
		vehicleList[index].SetActive(true);
	}

}
