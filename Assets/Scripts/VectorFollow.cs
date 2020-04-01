using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFollow : MonoBehaviour
{
    public GameObject player;
    public bool Activated;

    float fastSpeed = 5.0f;
    float mediumSpeed = 1.0f;
    float orbitSpeed;
    float ai_ActivateRange = 2.0f;
    float fastRange;
    float orbitRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Activated = false;
        orbitRange = Random.Range(0.8f, 3.0f);
        fastRange = orbitRange + Random.Range(1.0f, 2.5f);
        orbitSpeed = Random.Range(0.4f, 1.4f);
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
            float angleOffset = 0.0f;

            if (dist < orbitRange)
            {
                speedNow = orbitSpeed;
                turnRate = 0.05f;
                angleOffset = 90.0f;
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
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(mLookDirection) * Quaternion.AngleAxis(angleOffset, Vector3.up), 
                turnRate);
        }   
    }
}
