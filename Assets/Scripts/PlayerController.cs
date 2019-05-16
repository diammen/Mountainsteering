using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public string xAxis, yAxis;
    public string triggerAxis;
    public float movSpeed;
    public float rotSpeed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yRaw = Input.GetAxis(yAxis);
        float xRaw = Input.GetAxis(xAxis);
        float triggerRaw = Input.GetAxis(triggerAxis);


        rb.AddForce(transform.forward * triggerRaw * movSpeed * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetAxis(xAxis) != 0 || Input.GetAxis(yAxis) != 0)
        {
            Vector3 rotInput = new Vector3(0, Mathf.Atan2(xRaw, yRaw) * Mathf.Rad2Deg, 0);

            Quaternion newRot = Quaternion.Euler(rotInput);

            rb.rotation = Quaternion.Lerp(transform.rotation, newRot, rotSpeed * Time.deltaTime);
        }
    }
}
