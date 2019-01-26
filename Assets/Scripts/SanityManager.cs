using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SanityState{
    sane,
    halfway,
    insane
}

public class SanityManager : MonoBehaviour
{
    //=========================================================================
    //Constantes
    //=========================================================================
    const int MIN_SANITY = 0, 
              MAX_SANITY = 100;

    //=========================================================================
    //Variables
    //=========================================================================
    public int playerSanity;
    public SanityState currentSanityState;

    //=========================================================================
    //Unity methods
    //=========================================================================
    // Start is called before the first frame update
    void Start()
    {
        playerSanity = 0;
        currentSanityState = SanityState.sane;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSanity < 33){
            currentSanityState = SanityState.sane;
        }
        else if(playerSanity >= 33 && playerSanity < 66){
            currentSanityState = SanityState.halfway;
        }
        else if(playerSanity >= 66 && playerSanity > 100){
            currentSanityState = SanityState.insane;
        }
        else if (playerSanity == 100)
        {
            //Lógica de muerte del personaje.
        }
    }


    //=========================================================================
    //Our methods
    //=========================================================================
    public void sanityIncrease(int sanity){
        if(playerSanity > MAX_SANITY){
            playerSanity = MAX_SANITY;
        }
        playerSanity += sanity;
    }
    public void sanityDecrease(int sanity){
        if(playerSanity < MIN_SANITY){
            playerSanity = MIN_SANITY;
        }
        playerSanity += sanity;
    }
}
