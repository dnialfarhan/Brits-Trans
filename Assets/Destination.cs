using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {

    public GameObject desCollider;
    public GameObject Guard;

	// Use this for initialization
	void Awake ()
    {
        desCollider.SetActive(true);
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
