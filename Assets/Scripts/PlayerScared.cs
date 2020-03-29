using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScared : MonoBehaviour
{
    public GameObject playerOk;
    public GameObject playerTrailParticle;
    public GameObject playerScaredMoment;
    public GameObject playerScared;
    public float fearTime;

    // Start is called before the first frame update
    void Start()
    {
        playerOk = GameObject.FindGameObjectWithTag("PlayerOk");
        playerTrailParticle = GameObject.FindGameObjectWithTag("PlayerTrailParticle");
        playerScaredMoment = GameObject.FindGameObjectWithTag("ScaredMoment");        
        playerScared = GameObject.FindGameObjectWithTag("Scared");
        playerOk.SetActive(true);
        playerTrailParticle.SetActive(true);
        playerScaredMoment.SetActive(false);
        playerScared.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "fearMonster")
        {
            /*transform.position = Random.insideUnitCircle * 0.5f;
            transform.position = Random.insideUnitCircle * 0.5f;
            transform.position = Random.insideUnitCircle * 0.5f;*/
            Fear();
                      
        }
    }

    void Fear()
    {
            playerOk.SetActive(false);
            playerTrailParticle.SetActive(false);
            playerScaredMoment.SetActive(true);
            playerScared.SetActive(true);
            StartCoroutine(WaitforFear());  
    }

    void Ok()
    {
            playerOk.SetActive(true);
            playerTrailParticle.SetActive(true);
            playerScaredMoment.SetActive(false);
            playerScared.SetActive(false);
    }
    IEnumerator WaitforFear()
    {
        yield return new WaitForSeconds(fearTime);
        Ok();
    }
}
