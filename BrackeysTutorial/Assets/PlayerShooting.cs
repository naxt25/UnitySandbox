using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float moveForce = 0f;
    private Rigidbody rb;
    public GameObject bullet;
    public Transform gun;
    public float shootRate = 0f;
    public float shootForce = 0f;
    private float shootRateTimeStamp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            if(Time.time > shootRateTimeStamp && PauseMenu.isPaused == false)
            {
                GameObject go = (GameObject)Instantiate(
                    bullet, gun.position, gun.rotation);
                go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
                shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }
}
