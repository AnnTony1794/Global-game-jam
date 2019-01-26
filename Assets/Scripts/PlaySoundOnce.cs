using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnce : MonoBehaviour
{
    public AudioClip clip;
    public float volumen;
    AudioSource source;
    private bool wasPlayed = false;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void onTriggerEnter()
    {
        if (!wasPlayed)
        {
            source.PlayOneShot(clip, volumen);
            wasPlayed = true;
        }
    }
}
