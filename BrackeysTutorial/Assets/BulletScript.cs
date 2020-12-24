using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float expiryTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, expiryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            ScoreScript.scoreValue += 10;
            Destroy(gameObject);
        }

    }

}
