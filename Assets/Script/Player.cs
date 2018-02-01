using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

	[SerializeField]
	Transform _destination;

	NavMeshAgent _navmeshAgent;

	// Use this for initialization
	void Start () {

		_navmeshAgent = this.GetComponent<NavMeshAgent> ();

		if (_navmeshAgent == null) {
		
			Debug.Log ("Not attached");
		
		}
		else 
		{

			SetDestination ();

		}

	}
	
	// Update is called once per frame
	void SetDestination () {

		if (_destination != null) 
		{
		
			Vector3 targetVector = _destination.transform.position;
			_navmeshAgent.SetDestination (targetVector);
		
		}

	}
}
