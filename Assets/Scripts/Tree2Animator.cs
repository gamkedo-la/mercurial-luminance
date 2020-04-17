using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree2Animator : MonoBehaviour
{

    Animator animator;
    Animation anim;
    float distance;
    public GameObject Purple, PurpleTree, purpleLeaves;
    bool didHappen = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        anim = GetComponent<Animation>();
        Purple = GameObject.FindGameObjectWithTag("PurpleSpirit");
        PurpleTree = GameObject.FindGameObjectWithTag("Tree2");
        purpleLeaves = GameObject.FindGameObjectWithTag("PurpleLeaves");
        purpleLeaves.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (didHappen) {
            return;
        }
        float dist = (PurpleTree.transform.position - Purple.transform.position).magnitude;
        if (dist < 50)
        {
            didHappen = true;
            SoundPlayer.PlayClipByName("tree_branches", Random.Range(0.9f, 1.0f));
            animator.SetTrigger("Touched");
            purpleLeaves.SetActive(true);
            Debug.Log("Triggered by distance");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PurpleSpirit")
        {
            animator.SetTrigger("Touched");
            Debug.Log("Triggered");
        }
    }
}
