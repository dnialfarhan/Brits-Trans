/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class CarController_Manager : System.Object
{

	public WheelCollider leftWheel;
	public GameObject leftWheelMesh;
	public WheelCollider rightWheel;
	public GameObject rightWheelMesh;
	public bool motor;
	public bool steering;
	public bool reverseTurn;
}

public class CarController : MonoBehaviour
{

	Rigidbody rb;
	public float maxMotorTorque;
	public float maxSteeringAngle;
	public List<CarController_Manager> truck_Infos;

	public float boostSpeed = 5.0f;
	private float lastBoost;
	public float boostCooldown = 2.0f;


	private void Start()
	{
		rb = this.GetComponent<Rigidbody>();
	}

	public void VisualizeWheel(CarController_Manager wheelPair)
	{
		Quaternion rot;
		Vector3 pos;
		wheelPair.leftWheel.GetWorldPose(out pos, out rot);
		wheelPair.leftWheelMesh.transform.position = pos;
		wheelPair.leftWheelMesh.transform.rotation = rot;
		wheelPair.rightWheel.GetWorldPose(out pos, out rot);
		wheelPair.rightWheelMesh.transform.position = pos;
		wheelPair.rightWheelMesh.transform.rotation = rot;
	}

	public void Update()
	{

		float motor = maxMotorTorque * CrossPlatformInputManager.GetAxis("Vertical");
		float steering = maxSteeringAngle * CrossPlatformInputManager.GetAxis("Horizontal");
		float brakeTorque = Mathf.Abs(CrossPlatformInputManager.GetAxis("Jump"));

		if (brakeTorque > 0.001)
		{
			brakeTorque = maxMotorTorque;
			motor = 0;
			rb.drag = 2.5f;
		}
		else
		{
			brakeTorque = 0;
			rb.drag = 0.1f;
		}

		SpeedoMeter.ShowSpeedo(rb.velocity.magnitude, 0, 100);

		foreach (CarController_Manager truck_Info in truck_Infos)
		{
			if (truck_Info.steering == true)
			{
				truck_Info.leftWheel.steerAngle = truck_Info.rightWheel.steerAngle = ((truck_Info.reverseTurn) ? -1 : 1) * steering;
			}

			if (truck_Info.motor == true)
			{
				truck_Info.leftWheel.motorTorque = motor;
				truck_Info.rightWheel.motorTorque = motor;
			}

			truck_Info.leftWheel.brakeTorque = brakeTorque;
			truck_Info.rightWheel.brakeTorque = brakeTorque;

			VisualizeWheel(truck_Info);
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Boost")
		{
			if (Time.time - lastBoost > boostCooldown)
			{
				rb.AddForce(rb.velocity.normalized * boostSpeed, ForceMode.VelocityChange);
				lastBoost = Time.time;
			}

		}

		if (other.gameObject.tag == "TrafficLight")
		{
			if (maxMotorTorque > 0f)
			{
				rb.isKinematic = true;

				StartCoroutine("Continue");
			}
		}

		/*if (other.gameObject.tag == "SlowCollider")
		{
			maxMotorTorque = 25f;
		}*/
	}

	/*public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "SlowCollider")
		{
			maxMotorTorque = 50f;
		}
	}*/


	IEnumerator Continue()
	{
		yield return new WaitForSeconds(3);

		rb.isKinematic = false;
	}

	
}
