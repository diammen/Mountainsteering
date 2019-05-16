using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPickUp : MonoBehaviour {

    public bool hasFlag = false;
    public string dropFlag;

	// Update is called once per frame
	void Update () {
        //float yRaw = Input.GetAxis("Vertical");
        //float xRaw = Input.GetAxis("Horizontal");

        //transform.position = new Vector3(transform.position.x + xRaw * speed * Time.deltaTime, transform.position.y, transform.position.z + yRaw * speed * Time.deltaTime);

        if (Input.GetButtonDown(dropFlag) && hasFlag == true)
        {
            DropFlag();
        }

    }


    public void PickUpFlag()
    {
        hasFlag = true;
    }
    
    //Drops the flag behind the player
    public void DropFlag()
    {
        transform.Find("Flag").position = transform.position - transform.forward*3;
        transform.Find("Flag").transform.parent = null;
        hasFlag = false;
    }
}
