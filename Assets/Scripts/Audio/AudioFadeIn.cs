using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeIn : MonoBehaviour
{
    public float fadeInDurationSecs = 4.0f;

    private AudioSource audio;
    private float targetEndTime;
    private float targetVolume; // We have this to allow setting the audio source to a specific volume and the fade-in will not change it.

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        targetVolume = audio.volume;
        audio.volume = 0.0f;
        targetEndTime = Time.time + fadeInDurationSecs;
    }

    // Update is called once per frame
    void Update()
    {
        float position = 1.0f - (targetEndTime - Time.time) / fadeInDurationSecs;
        position = Mathf.Log(position + 1) * Mathf.Pow(position, 2); // Don't ask me...
        audio.volume = Mathf.Lerp(0.0f, targetVolume, position);
    }
}
