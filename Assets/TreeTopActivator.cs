using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTopActivator : MonoBehaviour
{
    public GameObject[] ListToEnable;
    public GameObject glowToMatch;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ListToEnable.Length; i++)
        {
            ListToEnable[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (transform.position - glowToMatch.transform.position).magnitude;
        if (dist < 50)
        {
            for (int i = 0; i < ListToEnable.Length; i++)
            {
                ListToEnable[i].SetActive(true);
            }
            SoundPlayer.PlayClipByName(SoundNames.tree_branches, Random.Range(0.9f, 1.0f));
            LookAtMe myLookScript = gameObject.GetComponent<LookAtMe>();
            myLookScript.WatchMeNow();
            //Debug.Log("Triggered by distance");
            this.enabled = false;
        }
    }
}
