using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScore : MonoBehaviour
{
    int TreasureValue;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TreasureValue = rand.Next(1, 10);
        other.transform.SendMessage("AddScore", TreasureValue, SendMessageOptions.DontRequireReceiver);
        Die();
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}

