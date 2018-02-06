using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassangerManager : MonoBehaviour {

    public GameObject guardIMG;

    public GameObject Destination;

    public void Awake()
    {
        guardIMG.SetActive(false);

        Destination.SetActive(false);
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            guardIMG.SetActive(true);

            Debug.Log("Arep babi!");

            Destroy(gameObject);

            Destination.SetActive(true);
        }

    }
}
