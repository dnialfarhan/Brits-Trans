/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Carmove : MonoBehaviour {

	public float MotorForce, SteerForce, BreakForce;
	public WheelCollider wheelfrontleft, wheelfrontrightSphere, wheelbackleft, wheelbackright;

	void Start()
	{

	}

	void Update()
	{

		float v = CrossPlatformInputManager.GetAxis("Vertical") * MotorForce;
		float h = CrossPlatformInputManager.GetAxis("Horizontal") * SteerForce;

		wheelbackleft.motorTorque = v;
		wheelbackright.motorTorque = v;

		wheelfrontleft.motorTorque = h;
		wheelfrontrightSphere.motorTorque = h;

		if (CrossPlatformInputManager.GetButton("Jump"))
		{
			wheelbackleft.brakeTorque = BreakForce;
			wheelbackright.brakeTorque = BreakForce;
		}
		if (CrossPlatformInputManager.GetButtonUp("Jump"))
		{
			wheelbackleft.brakeTorque = 0;
			wheelbackright.brakeTorque = 0;
		}

		if (CrossPlatformInputManager.GetAxis("Vertical") == 0)
		{
			wheelbackleft.brakeTorque = BreakForce;
			wheelbackright.brakeTorque = BreakForce;
		}
		else
		{
			wheelbackleft.brakeTorque = 0;
			wheelbackright.brakeTorque = 0;
		}
	}
}
