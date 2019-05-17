using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRoll : MonoBehaviour
{

    public Rigidbody rb;
    public WheelCollider leftWheel, rightWheel;
    public float antiRoll;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WheelHit hit = new WheelHit();
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = leftWheel.GetGroundHit(out hit);
        if (groundedL)
        {
            travelL = (-leftWheel.transform.InverseTransformPoint(hit.point).y - leftWheel.radius) / leftWheel.suspensionDistance;
        }

        bool groundedR = rightWheel.GetGroundHit(out hit);
        if (groundedR)
        {
            travelR = (-rightWheel.transform.InverseTransformPoint(hit.point).y - rightWheel.radius) / rightWheel.suspensionDistance;
        }

        float antiRollForce = (travelL - travelR) * antiRoll;

        if (groundedL)
        {
            rb.AddForceAtPosition(leftWheel.transform.up * -antiRollForce, leftWheel.transform.position);
        }
        if (groundedR)
        {
            rb.AddForceAtPosition(rightWheel.transform.up * -antiRollForce, rightWheel.transform.position);
        }
    }
}