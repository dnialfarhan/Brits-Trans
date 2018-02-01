using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTest : MonoBehaviour {

    // Use this for initialization
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy();
        }


    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
