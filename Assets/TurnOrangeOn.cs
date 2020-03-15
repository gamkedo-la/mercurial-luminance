using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrangeOn : MonoBehaviour
{
    public GameObject orangeParticle;
    public GameObject orangeSpirit;

    void Start()
    {
        orangeSpirit = GameObject.FindGameObjectWithTag("OrangeSpirit");
        orangeParticle = GameObject.Find("/Player/TPOrange");
        orangeParticle.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OrangeSpirit")
        {
            orangeParticle.SetActive(true);
        }
    }
}
