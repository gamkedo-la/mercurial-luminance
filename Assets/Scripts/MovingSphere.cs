﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;

    [SerializeField]
    Rect allowedArea = new Rect(-50f, -50f, 50f, 0f);

    [SerializeField, Range(0f, 1f)]
    float bounciness = 0.5f;

    Vector3 velocity;
    Vector3 acceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");

        Vector3 desiredVelocity = 
            new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x =
            Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z =
            Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        Vector3 displacement = velocity * Time.deltaTime;

        Vector3 newPosition = transform.localPosition + displacement;
        /*if(!allowedArea.Contains(new Vector2(newPosition.x, newPosition.z)))
        {
            newPosition.x =
                Mathf.Clamp(newPosition.x, allowedArea.xMin, allowedArea.xMax);
            newPosition.z =
                Mathf.Clamp(newPosition.z, allowedArea.yMin, allowedArea.yMax);
        }*/
        if(newPosition.x < allowedArea.xMin)
        {
            newPosition.x = allowedArea.xMin;
            //bounce off the edges, probably remove later on
            //place = 0f; in place of -velocity.x;  Do for z also, 4 locations
            velocity.x = -velocity.x * bounciness;
        }
        else if (newPosition.x > allowedArea.xMax)
        {
            newPosition.x = allowedArea.xMax;
            velocity.x = -velocity.x * bounciness;
        }

        if(newPosition.z < allowedArea.yMin)
        {
            newPosition.z = allowedArea.yMin;
            velocity.z = -velocity.z * bounciness;
        }
        else if(newPosition.z > allowedArea.yMax)
        {
            newPosition.z = allowedArea.yMax;
            velocity.z = -velocity.z * bounciness;
        }

        transform.localPosition = newPosition;
    }
}
