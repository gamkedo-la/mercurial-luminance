using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFollow : MonoBehaviour
{
    public GameObject player;
    public bool Activated;

    float fastSpeed = 5.0f;
    float mediumSpeed = 1.0f;
    float slowSpeed = 0.5f;
    float ai_ActivateRange = 2.0f;
    float fastRange = 2.0f;
    float slowRange = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 mLookDirection = (player.transform.position - transform.position);
        float dist = (player.transform.position - transform.position).magnitude;
        //print("Distance to other: " + dist);
        if(Activated == false)
        {
            if (dist < ai_ActivateRange)
            {
                Activated = true;
            }
        }
        else
        {
            float turnRate = 0.1f;
            float speedNow;
            if (dist < slowRange)
            {
                speedNow = slowSpeed;
                turnRate = 0.05f;
            }
            else if (dist > fastRange)
            {
                speedNow = fastSpeed;
            }
            else
            {
                speedNow = mediumSpeed;   
            }
            transform.Translate(0.0f, 0.0f, speedNow * Time.deltaTime);   
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mLookDirection), turnRate);
        }   
    }
}
