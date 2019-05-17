using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public string playerName;

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == playerName){
            if (other.GetComponent<FlagPickUp>().hasFlag == true)
            {
                print(other.name + " wins");
            }
        }
    }
}
