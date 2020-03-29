using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFollow : MonoBehaviour
{
    public GameObject player;
    public bool Activated;

    float mSpeed = 5.0f;
    float cSpeed = 1.0f;
    float sSpeed = 0.5f;

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
        if (dist < 2.0f && Activated == false)
            {
                Activated = true;
                transform.Translate(0.0f, 0.0f, cSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mLookDirection), 0.1f);
            }
        else if (dist < 1.0f && Activated)
        {
            transform.Translate(0.0f, 0.0f, sSpeed * Time.deltaTime);
            //transform.LookAt(player.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mLookDirection), 0.1f);
        }

        else if (dist > 2.0f && Activated)
        {
            transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
            //transform.LookAt(player.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mLookDirection), 0.1f);
        }

        else if (dist < 2.0f && Activated)
        {
            transform.Translate(0.0f, 0.0f, cSpeed * Time.deltaTime);   
            //transform.LookAt(player.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mLookDirection), 0.1f);           
        }


    }
}
