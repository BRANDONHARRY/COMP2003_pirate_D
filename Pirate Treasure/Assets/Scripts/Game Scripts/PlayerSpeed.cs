using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    public delegate void UpdateSpeed(string newSpeed);
    public static event UpdateSpeed OnUpdateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSpeed(string Speed)
    {
        //Debug.Log("Changing Speed to " + Speed);
        if(OnUpdateSpeed != null)
        {
            OnUpdateSpeed(Speed);
        }
    }
}
