using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject player;
    public Transform pTransform;

    public float speed = 10.0f;

    const float space = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(pTransform.position);
        
        if((transform.position - pTransform.position).magnitude > space)
        transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, 1.0f);
        }

    }
}
