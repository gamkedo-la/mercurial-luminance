using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrangeOn : MonoBehaviour
{
    public GameObject orangeParticle;
    public GameObject orangeSpirit;
    public GameObject greenParticle;
    public GameObject greenSpirit;
    void Start()
    {
        orangeSpirit = GameObject.FindGameObjectWithTag("OrangeSpirit");
        orangeParticle = GameObject.Find("/Player/TPOrange");
        greenSpirit = GameObject.FindGameObjectWithTag("GreenSpirit");
        greenParticle = GameObject.Find("/Player/TPGreen");
        orangeParticle.SetActive(false);
        greenParticle.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OrangeSpirit")
        {
            orangeParticle.SetActive(true);
        }

        if(other.tag == "GreenSpirit")
        {
            greenParticle.SetActive(true);
        }
    }
}
