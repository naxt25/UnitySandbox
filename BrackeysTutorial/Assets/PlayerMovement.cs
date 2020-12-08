using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public bool jumpQueued = false;
    public bool jumpLock = false;
    public bool doubleJumpLock = false; 

   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Added and Update() -- it seems like Update has a much faster run time, so things will be caught faster in update. I imagine dense mathematics go in fixed update and quicker commands go in update. I think, lol.
    void Update()
    {
        if(Input.GetButtonDown("Jump") && (jumpLock == false || doubleJumpLock == false))
        {
            jumpQueued = true;
        }
    }
 // FixedUpdate used in Unity for physics.
    void FixedUpdate()
    {
       
        if (Input.GetKey ("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
       
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
       
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        //able to call the 'Jump' variable because unity has default buttons
        //in unity Edit -> Project Settings -> Input Manager
        
        if (jumpQueued == true && jumpLock == false) //If the players asked to jump, and they haven't jumped yet
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            jumpQueued = false;
            jumpLock = true;
            ScoreScript.scoreValue += 10;
        }
        else if (jumpQueued == true && jumpLock == true && doubleJumpLock == false)//If the players asked to jump, and they have jumped once
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            jumpQueued = false;
            doubleJumpLock = true;
            ScoreScript.scoreValue += 15;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            jumpLock = false;
            doubleJumpLock = false;
        }
    }
}
