using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string xAxis, yAxis;
    public float movSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float yRaw = Input.GetAxis(yAxis);
        float xRaw = Input.GetAxis(xAxis);

        transform.position = new Vector3(transform.position.x + xRaw * movSpeed * Time.deltaTime, transform.position.y, transform.position.z + yRaw * movSpeed * Time.deltaTime);
    }
}
