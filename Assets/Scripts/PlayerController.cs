using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    //public string xAxis, yAxis;
    //public string triggerAxis;
    public float movSpeed;
    public float rotSpeed;
    public PlayerIndex index;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GamePadState state = GamePad.GetState(index);

        //float yRaw = Input.GetAxis(yAxis);
        //float xRaw = Input.GetAxis(xAxis);
        //float triggerRaw = Input.GetAxis(triggerAxis) > 0f ? 1f : 0f;
        float yRaw = state.ThumbSticks.Left.Y;
        float xRaw = state.ThumbSticks.Left.X;
        float triggerRaw = state.Buttons.LeftShoulder == ButtonState.Pressed ? 1f : 0f;

        // move player forward
        rb.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * triggerRaw * movSpeed * Time.deltaTime, ForceMode.Impulse);

        if (xRaw != 0 || yRaw != 0)
        {
            Vector3 rotInput = new Vector3(0, Mathf.Atan2(xRaw, yRaw) * Mathf.Rad2Deg, 0);

            Quaternion newRot = Quaternion.Euler(rotInput);

            // turn player towards direction of joystick
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotSpeed * Time.deltaTime);
        }

    }
}
