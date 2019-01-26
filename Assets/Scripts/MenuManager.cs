using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //=========================================================================
    //Variables
    //=========================================================================
    public static MenuManager sharedInstance;
    public Canvas menuCanvas, gameCanvas, 
                  gameOverCanvas, pausedGameCanvas, 
                  victoryCanvas, creditsCanvas;    
    private RawImage gameCanvasColor;


    //=========================================================================
    //Unity methods
    //=========================================================================
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        gameCanvasColor = gameCanvas.GetComponentInChildren<RawImage>();
    }

    private void Start() {
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

    public void setGameCanvasState(float alpha){
        gameCanvasColor.color = new Vector4(0f, 0f, 0f, alpha/100);
    }
}