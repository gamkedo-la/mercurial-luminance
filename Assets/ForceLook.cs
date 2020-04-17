using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLook : MonoBehaviour
{
    public Transform lookAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(lookAt != null)
        {
            Camera.main.transform.LookAt(lookAt);
        }
    }
}
