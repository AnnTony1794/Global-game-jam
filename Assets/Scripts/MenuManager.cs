using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //=========================================================================
    //Variables
    //=========================================================================
    public static MenuManager sharedInstance;
    public Canvas menuCanvas, gameCanvas, 
                  gameOverCanvas, pausedGameCanvas, 
                  victoryCanvas, creditsCanvas;    


    //=========================================================================
    //Unity methods
    //=========================================================================
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }


    //=========================================================================
    //Our methods
    //=========================================================================
    public void showMainMenu(){
        menuCanvas.enabled = true;
    }
    public void hideMainMenu(){
        menuCanvas.enabled = false;
    }

    public void showGameMenu(){
        gameCanvas.enabled = true;
    }
    public void hideGameMenu(){
        gameCanvas.enabled = false;
    }

    public void showGameOverMenu(){
        gameOverCanvas.enabled = true;
    }
    public void hideGameOverMenu(){
        gameOverCanvas.enabled = false;
    }

    public void showPauseMenu(){
        pausedGameCanvas.enabled = true;
    }
    public void hidePauseMenu(){
        pausedGameCanvas.enabled = false;
    }

    public void showVictoryMenu(){
        victoryCanvas.enabled = true;
    }
    public void hideVictoryMenu(){
        victoryCanvas.enabled = false;
    }

    public void showCreditsMenu(){
        creditsCanvas.enabled = true;
    }
    public void hideCreditsMenu(){
        creditsCanvas.enabled = false;
    }

    public void hideNotInGameMenus(){
        hideMainMenu();
        hideGameOverMenu();
        hidePauseMenu();
        hideVictoryMenu();
        showGameMenu();
    }
}