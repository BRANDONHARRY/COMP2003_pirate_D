using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballRight : MonoBehaviour
{
    public float movespeed = 10.0f;
    public int damage = 1;
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * movespeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        Die();

    }

    private void OnBecameInvisible() 
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
