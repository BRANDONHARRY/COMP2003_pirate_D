﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRight : MonoBehaviour
{
    public GameObject CannonballPrefab;
    public Transform CannonballSpawn;
    public float fireTime = 0.5f;

    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        DataHandler.addShot();
        isFiring = true;
        Instantiate(CannonballPrefab, CannonballSpawn.position, CannonballSpawn.rotation);

        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        Invoke("SetFiring", fireTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) 
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}
