using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {

    public GameObject descollider;
    public GameObject Guard;

	// Use this for initialization
	void Awake ()
    {
        descollider.SetActive(true);
    }

    public void OnTriggerEnter(Collider des)
    {
        if(des.gameObject.tag == "Player")
        {
            descollider.SetActive(false);
            Guard.SetActive(false);
        }
    }
}
