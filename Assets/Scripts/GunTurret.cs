using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GunTurret : MonoBehaviour
{

    //public string xAxis, yAxis;
    public float rotSpeed;
    public PlayerIndex index;

    // Update is called once per frame
    void FixedUpdate()
    {
        GamePadState state = GamePad.GetState(index);
        //float xRaw = Input.GetAxis(xAxis);
        //float yRaw = Input.GetAxis(yAxis);
        float yRaw = state.ThumbSticks.Right.Y;
        float xRaw = state.ThumbSticks.Right.X;

        if (xRaw != 0 || yRaw != 0)
        {
            Vector3 rotInput = new Vector3(0, Mathf.Atan2(xRaw, yRaw) * Mathf.Rad2Deg, 0);

            Quaternion newRot = Quaternion.Euler(rotInput);

            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotSpeed * Time.deltaTime);
        }
    }
}
