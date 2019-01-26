using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnce : MonoBehaviour
{
    AudioSource source;
    public float volumen;
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

    // void OnCollisionEnter(Collision collision)
    // {
    //     print(collision.gameObject.tag);
    //     if (collision.gameObject.tag == "Player")
    //         if (!wasPlayed)
    //         {
    //             source.Play();
    //             wasPlayed = true;
    //         }
    // }


    void OnTriggerEnter(Collider other)
    {
        print("collision");
        if (!wasPlayed)
        {
            if (other.gameObject.tag == "Player")
            {
                source.Play();
                wasPlayed = true;
            }
        }
    }


}
