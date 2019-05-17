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
            print("got hit by " + other.name);
            if (hasFlag)
            {
                DropFlag();
            }
        }
    }

    //Drops the flag behind the player
    public void DropFlag()
    {
        Transform flag = transform.Find("Flag");
        if(flag == null) {
            flag = transform.Find("Flag(Clone)");
        }
        flag.position = transform.position - transform.forward*3;
        flag.rotation = Quaternion.Euler(new Vector3(30, 0, 0));
        flag.GetComponent<BoxCollider>().enabled = true;
        flag.transform.parent = null;
        hasFlag = false;
    }
}
