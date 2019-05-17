using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject[] bullets;
    public Transform firePosition;
    public string triggerAxis;
    public float timeToFire, timeStamp;
    public float bulletSpeed;

	// Use this for initialization
	void Start () {
        var bul = Resources.Load<GameObject>("bullet");

        // create object pool
        for (int i = 0; i < bullets.Length; i++)
        {
            var temp = Instantiate(bul, transform.position, transform.rotation);

            bullets[i] = temp;
        }
	}
	
	// Update is called once per frame
	void Update () {
        float triggerRaw = Input.GetAxis(triggerAxis);

        // if there's input
        if (triggerRaw != 0)
        {
            // if it's time to fire
            if (Time.time - timeStamp > timeToFire)
            {
                FireBullet();
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
                break;
            }
        }
    }
}
