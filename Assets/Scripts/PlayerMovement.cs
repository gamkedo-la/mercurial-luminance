using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float turnSpeed = 1.0f;
    private float driveSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float kValue = 0.3f;
        turnSpeed = Input.GetAxisRaw("Horizontal") * (1.0f - kValue) + turnSpeed * kValue;

        kValue = 0.9f;
        driveSpeed = Input.GetAxisRaw("Vertical") * (1.0f - kValue) + driveSpeed * kValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 5.0f * driveSpeed;

        //spin with our keys
        transform.Rotate(Vector3.up, turnSpeed * 40.0f * Time.deltaTime);
    }
}
