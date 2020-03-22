using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrangeOn : MonoBehaviour
{
    public GameObject orangeParticle;
    public GameObject orangeSpirit;
    public GameObject greenParticle;
    public GameObject greenSpirit;
    public GameObject redParticle;
    public GameObject redSpirit;
    public GameObject yellowParticle;
    public GameObject yellowSpirit;
    public GameObject blueParticle;
    public GameObject blueSpirit;
    public GameObject purpleParticle;
    public GameObject purpleSpirit;

    void Start()
    {
        orangeSpirit = GameObject.FindGameObjectWithTag("OrangeSpirit");
        orangeParticle = GameObject.Find("/Player/TPOrange");
        greenSpirit = GameObject.FindGameObjectWithTag("GreenSpirit");
        greenParticle = GameObject.Find("/Player/TPGreen");
        redSpirit = GameObject.FindGameObjectWithTag("RedSpirit");
        redParticle = GameObject.Find("/Player/TPRed");        
        yellowSpirit = GameObject.FindGameObjectWithTag("YellowSpirit");
        yellowParticle = GameObject.Find("/Player/TPYellow");
        blueSpirit = GameObject.FindGameObjectWithTag("BlueSpirit");
        blueParticle = GameObject.Find("/Player/TPBlue");
        purpleSpirit = GameObject.FindGameObjectWithTag("PurpleSpirit");
        purpleParticle = GameObject.Find("/Player/TPPurple");
        purpleParticle.SetActive(false);
        blueParticle.SetActive(false);
        yellowParticle.SetActive(false);
        redParticle.SetActive(false);
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

        if (other.tag == "RedSpirit")
        {
            redParticle.SetActive(true);
        }

        if (other.tag == "YellowSpirit")
        {
            yellowParticle.SetActive(true);
        }

        if (other.tag == "BlueSpirit")
        {
            blueParticle.SetActive(true);
        }

        if (other.tag == "PurpleSpirit")
        {
            purpleParticle.SetActive(true);
        }
    }
}
