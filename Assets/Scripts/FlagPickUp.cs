using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPickUp : MonoBehaviour {

    public bool hasFlag = false;
    public int playerId;


    public void PickUpFlag()
    {
        hasFlag = true;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (playerId == 1)
        {
            if (other.CompareTag("P2Bullet") || other.CompareTag("P3Bullet") || other.CompareTag("P4Bullet"))
            {
                if (hasFlag)
                {
                    DropFlag();
                }
            }
        } else if (playerId == 2)
        {
            if (other.CompareTag("P1Bullet") || other.CompareTag("P3Bullet") || other.CompareTag("P4Bullet"))
            {
                if (hasFlag)
                {
                    DropFlag();
                }
            }
        }
        else if (playerId == 3)
        {
            if (other.CompareTag("P1Bullet") || other.CompareTag("P2Bullet") || other.CompareTag("P4Bullet"))
            {
                if (hasFlag)
                {
                    DropFlag();
                }
            }
        }
        else if (playerId == 4)
        {
            if (other.CompareTag("P1Bullet") || other.CompareTag("P2Bullet") || other.CompareTag("P3Bullet"))
            {
                if (hasFlag)
                {
                    DropFlag();
                }
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
