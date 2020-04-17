using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrabber : MonoBehaviour
{
    public GameObject player;
    VectorFollow Activated;
    public GameObject Orange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Orange = GameObject.FindGameObjectWithTag("OrangeSpirit");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
