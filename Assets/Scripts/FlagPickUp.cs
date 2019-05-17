using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPickUp : MonoBehaviour {

    public bool hasFlag = false;

    public void PickUpFlag()
    {
        hasFlag = true;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (hasFlag)
            {
                DropFlag();
            }
        }
    }

    //Drops the flag behind the player
    public void DropFlag()
    {

        transform.Find("Flag").position = transform.position - transform.forward*3;
        transform.Find("Flag").GetComponent<BoxCollider>().enabled = true;
        transform.Find("Flag").transform.parent = null;
        hasFlag = false;
    }
}
