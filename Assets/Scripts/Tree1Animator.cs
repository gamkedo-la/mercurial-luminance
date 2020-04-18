using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1Animator : MonoBehaviour
{

    Animator animator;
    Animation anim;
    float distance;
    public GameObject Orange, OrangeTree;
    bool didHappen = false;

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
        if (didHappen) {
            return;
        }
        float dist = (OrangeTree.transform.position - Orange.transform.position).magnitude;
        if (dist < 10)
        {
            didHappen = true;
            SoundPlayer.PlayClipByName(SoundNames.tree_branches, Random.Range(0.9f, 1.0f));
            animator.SetTrigger("Touched");
            LookAtMe myLookScript = gameObject.GetComponent<LookAtMe>();
            myLookScript.WatchMeNow();
            Debug.Log("Triggered by distance");
        }
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
