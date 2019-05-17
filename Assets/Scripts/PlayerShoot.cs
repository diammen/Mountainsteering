using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerShoot : MonoBehaviour {

    public GameObject[] bullets;
    public Transform firePosition;
    public string triggerAxis;
    public ParticleSystem muzzleFlash;
    public float timeToFire, timeStamp;
    public float bulletSpeed;
    public PlayerIndex index;
    private AudioSource shootSound;
    GamePadState state;

	// Use this for initialization
	void Start () {
        var bul = Resources.Load<GameObject>("bullet");

        // create object pool
        for (int i = 0; i < bullets.Length; i++)
        {
            var temp = Instantiate(bul, transform.position, transform.rotation);

            bullets[i] = temp;
        }

        shootSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        GamePadState state = GamePad.GetState(index);
        //float triggerRaw = Input.GetAxis(triggerAxis);
        float triggerRaw = state.Buttons.RightShoulder == ButtonState.Pressed ? 1f : 0f;
        // if there's input
        if (triggerRaw != 0)
        {
            // if it's time to fire
            if (Time.time - timeStamp > timeToFire)
            {
                FireBullet();
                shootSound.Play();
                timeStamp = Time.time;
            }
        }
	}

    // fire bullet
    void FireBullet()
    {
        foreach (GameObject bul in bullets)
        {
            // search for first available bullet in pool
            if (!bul.activeSelf)
            {
                bul.SetActive(true);
                bul.GetComponent<TrailRenderer>().Clear();
                bul.transform.position = firePosition.position;
                bul.transform.rotation = firePosition.rotation;
                bul.GetComponent<Rigidbody>().AddForce(bul.transform.forward * bulletSpeed, ForceMode.Impulse);
                muzzleFlash.Play();
                break;
            }
        }
    }
}
