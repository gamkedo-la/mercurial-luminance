using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHover : MonoBehaviour
{
    public float minAlt = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rhInfo;
        LayerMask cameraMask = ~LayerMask.GetMask("Player", "NPC"); // ~ for "everything but"
        if (Physics.Raycast(transform.position, Vector3.down, out rhInfo, minAlt, cameraMask))
        {
            transform.position = rhInfo.point + minAlt * Vector3.up;
        }

    }
}
