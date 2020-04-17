using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree2Animator : MonoBehaviour
{

    Animator animator;
    Animation anim;
    float distance;
    public GameObject Orange, OrangeTree;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        anim = GetComponent<Animation>();
        Orange = GameObject.FindGameObjectWithTag("OrangeSpirit");
        OrangeTree = GameObject.FindGameObjectWithTag("Tree1");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (OrangeTree.transform.position - Orange.transform.position).magnitude;
        if (dist < 20)
        {
            animator.SetTrigger("Touched");
            Debug.Log("Triggered by distance");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OrangeSpirit")
        {
            animator.SetTrigger("Touched");
            Debug.Log("Triggered");
        }
    }
}
