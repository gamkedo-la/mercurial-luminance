using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rhInfo;
        float minAlt = 1.0f;
        if (Physics.Raycast(transform.position, Vector3.down, out rhInfo, minAlt))
        {
            transform.position = rhInfo.point + minAlt * Vector3.up;
        }
    }
}
