using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassangerManager : MonoBehaviour {

    public GameObject guardIMG;

    public GameObject Destination;

    public GameObject Passanger;

    public void Awake()
    {
        guardIMG.SetActive(false);

        Destination.SetActive(false);

        Passanger.SetActive(true);
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            guardIMG.SetActive(true);

            Passanger.SetActive(false);

            Destroy(gameObject);

            Destination.SetActive(true);
        }

    }
}
