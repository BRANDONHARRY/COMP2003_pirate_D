using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurning : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    public float smoothing = 5.0f;
    //float x = 0.0f;
    //float y = 0.0f;
    //public float adjustmentAngle = 270.0f;

    public float turnSpeed = 50.0f;

    //float angle = 360.0f;
    //float time = 1.0f;
    //Vector3 axis = Vector3.forward;
    //Vector3 backaxis = Vector3.back;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) == true)

        {
            //x = 1;
            //float rotZ = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            //Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
            //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);

            rigidbody2D.MoveRotation(rigidbody2D.rotation + -turnSpeed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            //x = -1;
            //float rotZ = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            //Quaternion newRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
            //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * smoothing);

            rigidbody2D.MoveRotation(rigidbody2D.rotation + turnSpeed * Time.fixedDeltaTime);
        }

        //if (Input.GetKey(KeyCode.D) == false)
        //{
            //x = 0;
        //}
        //if (Input.GetKey(KeyCode.A) == false)
        //{
            //x = 0;
        //}

    }
}
