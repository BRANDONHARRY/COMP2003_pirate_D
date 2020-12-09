using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMonsterCollide : MonoBehaviour
{
    int damage = 2;
    bool cooloff = false;
    int waitFrames = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Will prevent the monster for damaging the player for cooloff period
        if (cooloff == true)
        {
            waitFrames--;
            if (waitFrames < 0)
            {
                cooloff = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (cooloff == false)
        {
            other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            cooloff = true;
            //Makes cooloff period 1 second
            waitFrames = 30;
        }

    }
}
