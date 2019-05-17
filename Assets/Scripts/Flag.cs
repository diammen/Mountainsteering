using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        //attatch Flag to flag poll on the player
        if (other.CompareTag("Player")) {
            transform.parent = other.transform;
            transform.localPosition = other.transform.Find("FlagPole").transform.localPosition;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            other.GetComponent<FlagPickUp>().PickUpFlag();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
