using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {
    [SerializeField] move player;

	void OnTriggerEnter(Collider other)
    {
        //attatch Flag to flag poll on the player
        if (other.CompareTag("Player")) {
            transform.parent = other.transform;
            transform.localPosition = other.transform.GetChild(0).transform.localPosition;
            player.PickUpFlag();
        }
    }
}
