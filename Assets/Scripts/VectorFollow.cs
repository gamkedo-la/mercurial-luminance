using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFollow : MonoBehaviour
{
    public GameObject player, Orange, OrangeTree;
    public bool Activated;
    public bool TreeActivated;
    public ParticleSystem.EmissionModule particles;

    float fastSpeed = 5.0f;
    float mediumSpeed = 1.0f;
    float orbitSpeed;
    float ai_ActivateRange = 2.0f;
    float fastRange;
    float orbitRange;
    float tree_ActivateRange = 10.0f;
    float tFastSpeed = 5.0f;
    float tMediumSpeed = 1.0f;
    float tOrbitSpeed;



    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem pfx = gameObject.GetComponent<ParticleSystem>();
        particles = pfx.emission;
        player = GameObject.FindGameObjectWithTag("Player");
        Orange = GameObject.FindGameObjectWithTag("OrangeSpirit");
        OrangeTree = GameObject.FindGameObjectWithTag("Tree1");
        Activated = false;
        orbitRange = Random.Range(0.8f, 3.0f);
        fastRange = orbitRange + Random.Range(1.0f, 2.5f);
        orbitSpeed = Random.Range(0.4f, 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (TreeActivated == false)
        {
            Vector3 mLookDirection = (player.transform.position - transform.position);
            float dist = (player.transform.position - transform.position).magnitude;
            float distTree = (player.transform.position - OrangeTree.transform.position).magnitude;
            //print("Distance to other: " + dist);
            if (Activated == true)
            {
                if (distTree < tree_ActivateRange)
                {
                    TreeActivated = true;
                }
                else
                {
                    float turnRate = 0.1f;
                    float speedNow;
                    float angleOffset = 0.0f;

                    if (dist < orbitRange)
                    {
                        particles.rateOverTime = 4;
                        speedNow = orbitSpeed;
                        turnRate = 0.05f;
                        angleOffset = 90.0f;
                    }
                    else if (dist > fastRange)
                    {
                        speedNow = fastSpeed;
                    }
                    else
                    {
                        speedNow = mediumSpeed;
                    }
                    transform.Translate(0.0f, 0.0f, speedNow * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.LookRotation(mLookDirection) * Quaternion.AngleAxis(angleOffset, Vector3.up),
                        turnRate);
                }
            }
            else
            {
                if (Activated == false)
                {
                    if (dist < ai_ActivateRange)
                    {
                        Activated = true;
                    }
                }
            }
        }
        else
        {
            Vector3 mLookDirection = (OrangeTree.transform.position - transform.position);
            float distTree = (OrangeTree.transform.position - transform.position).magnitude;

            float tTurnRate = 0.1f;
            float tSpeedNow = .2f;
            float tAngleOffset = 0.0f;

            if (distTree < orbitRange)
            {
                particles.rateOverTime = 100;
                tSpeedNow = orbitSpeed;
                tTurnRate = 0.05f;
                //angleOffset = 90.0f;
            }
            else if (distTree > fastRange)
            {
                tSpeedNow = tFastSpeed;
            }
            else
            {
                tSpeedNow = tMediumSpeed;
            }
            transform.Translate(0.0f, 0.0f, tSpeedNow * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(mLookDirection) * Quaternion.AngleAxis(tAngleOffset, Vector3.up),
                tTurnRate);
        }
    }
}
