using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFollow : MonoBehaviour
{
    public GameObject player;

    float mSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (dist < 5.0f)
        {
            transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);   
            //transform.LookAt(player.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mLookDirection), 0.1f);
        }


    }
}
