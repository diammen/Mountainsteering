using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : MonoBehaviour
{

    public string xAxis, yAxis;
    public float rotSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xRaw = Input.GetAxis(xAxis);
        float yRaw = Input.GetAxis(yAxis);

        Vector3 rotInput = new Vector3(0, Mathf.Atan2(xRaw, yRaw) * Mathf.Rad2Deg, 0);

        Quaternion newRot = Quaternion.Euler(rotInput);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotSpeed * Time.deltaTime);
    }
}
