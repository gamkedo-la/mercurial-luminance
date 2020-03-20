using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerachase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camOffSet = -transform.forward * 5.0f;
        camOffSet.y = 0.0f;
        camOffSet = camOffSet.normalized * 5.0f;
        camOffSet += Vector3.up * 3.0f;

        RaycastHit rhInfo;
        LayerMask cameraMask = ~LayerMask.GetMask("Player", "NPC"); // ~ for "everything but"
        float scaledBackBy = 1.0f;
        float camOffsetLength = camOffSet.magnitude;
        if (Physics.Raycast(transform.position, camOffSet, out rhInfo, camOffsetLength, cameraMask))
        {
            Debug.Log(rhInfo.collider.gameObject.name);
            camOffSet = rhInfo.point - transform.position;
            scaledBackBy = camOffSet.magnitude / camOffsetLength;
        }

        Camera.main.transform.position = transform.position + camOffSet;
        Camera.main.transform.LookAt(transform.position + Vector3.up * 2.0f * scaledBackBy);


        
        
    }
}
