using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1Animator : MonoBehaviour
{

    Animator animator;
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "OrangeSpirit")
        {
            animator.SetTrigger("Touched");
            Debug.Log("Triggered");
        }
    }
}
