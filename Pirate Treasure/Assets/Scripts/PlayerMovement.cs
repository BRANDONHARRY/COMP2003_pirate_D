using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D rigidbody2D;

    public float y = 0.0f;
    bool cooloff = false;
    int waitFrames = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //This allows for the 'stages' of speed to function, rather than just jumping to the maximum value.
        if (cooloff = true)
        {
            waitFrames--;
            if (waitFrames < 0) 
            {
                cooloff = false;
            }
        }

        if (Input.GetKey(KeyCode.W) == true && cooloff == false)
        {
            y = y + 0.5f;

            cooloff = true;
            waitFrames = 15;
            

        }
        else if (Input.GetKey(KeyCode.S) == true && cooloff == false)
        {
            y = y - 0.5f;

            cooloff = true;
            waitFrames = 15;

        }


        if(y > 1)
        {
            y = 1;
        }
        else if (y < -1)
        {
            y = -1;
        }

        rigidbody2D.velocity = transform.up * (y*speed);
        rigidbody2D.angularVelocity = 0.0f;
    }
}
