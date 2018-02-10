using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {

    public GameObject desCollider;
    public GameObject Guard;
	public GameObject desIndicator;
	
	// Use this for initialization
	void Start ()
    {
        desCollider.SetActive(true);

		desIndicator.SetActive(true);
    }

	

    public void OnTriggerEnter(Collider des)
    {
        if(des.gameObject.tag == "Player")
        {
            desCollider.SetActive(false);
            Guard.SetActive(false);
			
        }
    }


}
