using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnCollision : MonoBehaviour
{
    public bool played = false;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider collider)
    {
        if(!played && collider.gameObject.tag == "Player")
        {
            played = true;
            audio.Play();
        }
    }

}
