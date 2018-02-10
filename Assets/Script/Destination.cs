using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {

    public GameObject descollider;
    public GameObject Guard;
	public GameObject indicatorPos;

	public GameObject Indicator;
	// Use this for initialization
	void Start ()
    {
        descollider.SetActive(true);

		Instantiate(Indicator, indicatorPos.transform.position, Quaternion.Euler(90, 0, 0));
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
