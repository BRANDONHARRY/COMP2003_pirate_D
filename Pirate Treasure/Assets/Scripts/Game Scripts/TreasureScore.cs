using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScore : MonoBehaviour
{
    public int TreasureValue;
    System.Random rand;
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
        rand = new System.Random();
        TreasureValue = rand.Next(1, 10);
        DataHandler.addTreasure();
        other.transform.SendMessage("AddScore", TreasureValue, SendMessageOptions.DontRequireReceiver);
        Die();
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}

