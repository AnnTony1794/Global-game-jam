using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixerSnapshot Fogata;
    public AudioMixerSnapshot Fondo;
    

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "FogataFondo"){
            Fogata.TransitionTo(1.2f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "FogataFondo"){
            Fondo.TransitionTo(1.2f);
        }
    }
}
