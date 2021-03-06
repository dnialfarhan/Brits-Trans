/*
* Copyright (c) Danial Farhan
* http://twitter.com/dfkh_/
*/

using UnityEngine;

public class PassangerManager : MonoBehaviour {

    public GameObject PassangerIMG;
    public GameObject Destination;
	public GameObject PassangerChar;
	public GameObject Indicator;

    public void Awake()
    {
        PassangerIMG.SetActive(false);
        Destination.SetActive(false);
        PassangerChar.SetActive(true);
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
			FindObjectOfType<AudioManager>().Play("PickUp");

			PassangerIMG.SetActive(true);
            PassangerChar.SetActive(false);
            Destroy(gameObject);
			Destroy(Indicator);
            Destination.SetActive(true);
        }

    }
}
