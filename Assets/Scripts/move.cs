using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    [SerializeField] float speed = 5f;
    public bool HasFlag { get; set; }

	// Update is called once per frame
	void Update () {
        float yRaw = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxis("Horizontal");

        transform.position = new Vector3(transform.position.x + xRaw * speed * Time.deltaTime, transform.position.y, transform.position.z + yRaw * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") && HasFlag == true)
        {
            DropFlag();
        }

    }


    public void PickUpFlag()
    {
        HasFlag = true;
    }
    
    //Drops the flag behind the player
    public void DropFlag()
    {
        transform.Find("FlagPoll").position = transform.position - transform.forward;
        transform.Find("FlagPoll").transform.parent = null;
        HasFlag = false;
    }
}
