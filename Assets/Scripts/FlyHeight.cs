using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyHeight : MonoBehaviour
{
    public float maxAlt = 2.0f;
    RaycastHit rhInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out rhInfo, maxAlt))
        {
            transform.position = rhInfo.point + maxAlt * Vector3.up;
        }
    }
}
