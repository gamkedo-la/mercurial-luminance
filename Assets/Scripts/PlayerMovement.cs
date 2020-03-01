using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float turnSpeed = 1.0f;
    private float driveSpeed = 0.0f;
    private float pitchFacing = 0.0f;
    private float yawFacing = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        //transform.Rotate(Vector3.up, turnSpeed * 40.0f * Time.deltaTime);
        //Mouse
        //transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X") * 40.0f * Time.deltaTime);
        //transform.Rotate(transform.right, Input.GetAxisRaw("Mouse Y") * 40.0f * Time.deltaTime);

        yawFacing += turnSpeed * 40.0f * Time.deltaTime;
        yawFacing += Input.GetAxisRaw("Mouse X") * 40.0f * Time.deltaTime;
        
        pitchFacing -= Input.GetAxisRaw("Mouse Y") * 40.0f * Time.deltaTime;
        pitchFacing = Mathf.Clamp(pitchFacing, -30.0f, 30.0f);

        transform.rotation = Quaternion.AngleAxis(yawFacing, Vector3.up) *
            Quaternion.AngleAxis(pitchFacing, Vector3.right);
    }
}
