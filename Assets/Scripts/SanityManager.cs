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
    public static SanityManager sharedInstance;

    //=========================================================================
    //Unity methods
    //=========================================================================
    // Start is called before the first frame update
    void Start()
    {
        if(sharedInstance == null){
            sharedInstance = this;
        }
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
            GameManager.sharedInstance.die();
        }
    }


    //=========================================================================
    //Our methods
    //=========================================================================
    public void sanityIncrease(int sanity){
        if(GameManager.sharedInstance.currentGameState == GameState.paused){
            return;
        }
        playerSanity += sanity;
        if(playerSanity > MAX_SANITY){
            playerSanity = MAX_SANITY;
        }
    }
    public void sanityDecrease(int sanity){
        if(GameManager.sharedInstance.currentGameState == GameState.paused){
            return;
        }
        playerSanity -= sanity;
        if(playerSanity < MIN_SANITY){
            playerSanity = MIN_SANITY;
        }
    }
}
