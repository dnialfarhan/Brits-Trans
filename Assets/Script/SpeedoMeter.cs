/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine;

public class SpeedoMeter : MonoBehaviour {

	static float minAngle = 190f;
	static float maxAngle = -99f;
	static SpeedoMeter thisSpeedo;

	// Use this for initialization
	void Start () 
	{
		thisSpeedo = this;
	}

	public static void ShowSpeedo(float speed, float min, float max)
	{
		float ang = Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(min, max, speed));
		thisSpeedo.transform.eulerAngles = new Vector3(0, 0, ang);
	}
	
}
