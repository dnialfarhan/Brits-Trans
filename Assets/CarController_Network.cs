/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CarController_Network : MonoBehaviour
{

	Rigidbody rb;

	public float moveSpeed = 250f;
	public float rotSpeed = 500f;

	public float boostSpeed = 5.0f;
	private float lastBoost;
	public float boostCooldown = 2.0f;

	// Use this for initialization
	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		float translation = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
		float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotSpeed;
		float brake = Mathf.Abs(CrossPlatformInputManager.GetAxis("Jump"));
		translation *= Time.deltaTime;
		//rotation *= Time.deltaTime;

		rb.AddForce(this.transform.forward * translation * 400);
		rb.AddTorque(this.transform.up * rotation * 50);

		if (brake > 0.001)
		{
			brake = moveSpeed;
			translation = 0;
			rb.drag = 10f;
		}
		else
		{
			brake = 0;
			rb.drag = 2.5f;
		}

		SpeedoMeter.ShowSpeedo(rb.velocity.magnitude, 0, 200);

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Boost")
		{
			if (Time.time - lastBoost > boostCooldown)
			{
				rb.AddForce(rb.velocity.normalized * boostSpeed, ForceMode.VelocityChange);


				FindObjectOfType<AudioManager>().Play("Boost");

				lastBoost = Time.time;
			}

		}

		if (other.gameObject.tag == "TrafficLight")
		{
			if (moveSpeed > 0f)
			{
				rb.isKinematic = true;

				StartCoroutine("Continue");
			}
		}
	}

	IEnumerator Continue()
	{
		yield return new WaitForSeconds(3);

		rb.isKinematic = false;
	}

}