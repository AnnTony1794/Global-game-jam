using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixerSnapshot Fogata;
    public AudioMixerSnapshot Fondo;
    public AudioMixerSnapshot Cordura;
    public AudioMixerSnapshot Credits;
    private bool fogataza = false;
    private bool cordu = false;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "FogataFondo"){
            Fogata.TransitionTo(1.2f);
            fogataza = true;
            cordu = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "FogataFondo"){
            Fondo.TransitionTo(1.2f);
            fogataza = false;
            cordu = false;
        }
    }

    private void Update() {
        if(SanityManager.sharedInstance.playerSanity > 50 && !fogataza && !cordu){
            Cordura.TransitionTo(0.01f);
            cordu = true;
        }
    }
}
