﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D rigidbody2D;
    public GameObject player;
    public float y = 0.0f;
    bool cooloff = false;
    int waitFrames = 0;
    int seconds = 0;
    int framecounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(framecounter == 30)
        {
            seconds++;
            framecounter = 0;
        }
        framecounter++;


        //This allows for the 'stages' of speed to function, rather than just jumping to the maximum value.
        if (cooloff == true)
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
            //Gives a wait time of half a second
            waitFrames = 15;

            //forcing the y value to equal 1 or -1 if it's in exess
            if (y > 1)
            {
                y = 1;
            }
            else if (y < -1)
            {
                y = -1;
            }

            switch (y)
            {
                case 0.5f:
                    player.transform.SendMessage("ChangeSpeed", "Half", SendMessageOptions.DontRequireReceiver);
                    break;
                case 1f:
                    player.transform.SendMessage("ChangeSpeed", "Full", SendMessageOptions.DontRequireReceiver);
                    break;
                case -0.5f:
                    player.transform.SendMessage("ChangeSpeed", "R-Half", SendMessageOptions.DontRequireReceiver);
                    break;
                default:
                    player.transform.SendMessage("ChangeSpeed", "Stop", SendMessageOptions.DontRequireReceiver);
                    break;

            }
            

        }
        else if (Input.GetKey(KeyCode.S) == true && cooloff == false)
        {
            y = y - 0.5f;

            cooloff = true;
            waitFrames = 15;

            //forcing the y value to equal 1 or -1 if it's in exess
            if (y > 1)
            {
                y = 1;
            }
            else if (y < -1)
            {
                y = -1;
            }

            switch (y)
            {
                case 0.5f:
                    player.transform.SendMessage("ChangeSpeed", "Half", SendMessageOptions.DontRequireReceiver);
                    break;
                case -1f:
                    player.transform.SendMessage("ChangeSpeed", "R-Full", SendMessageOptions.DontRequireReceiver);
                    break;
                case -0.5f:
                    player.transform.SendMessage("ChangeSpeed", "R-Half", SendMessageOptions.DontRequireReceiver);
                    break;
                default:
                    player.transform.SendMessage("ChangeSpeed", "Stop", SendMessageOptions.DontRequireReceiver);
                    break;

            }

        }


        

        rigidbody2D.velocity = transform.up * (y*speed);
        rigidbody2D.angularVelocity = 0.0f;
    }

    public void TimeSet()
    {
        DataHandler.setTime(seconds);
    }
}
