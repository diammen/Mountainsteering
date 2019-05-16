using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            if (other.GetComponent<FlagPickUp>().hasFlag == true)
            {
                print(other.name + " wins");
            }
        }
    }
}
