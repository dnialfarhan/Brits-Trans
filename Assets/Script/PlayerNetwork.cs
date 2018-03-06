/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour {


	public override void OnStartLocalPlayer()
	{
		GetComponent<CarController_Network>().enabled = true;
	}
}
