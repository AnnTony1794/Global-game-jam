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
    private RawImage gameCanvasColor, gameOverImage, victoryImage, osoImage;
    private float gameOverAlpha, victoryAlpha, osoAlpha;


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
        gameOverImage = gameOverCanvas.GetComponentInChildren<RawImage>();
        victoryImage = victoryCanvas.GetComponentInChildren<RawImage>();
        osoImage = GameObject.FindGameObjectWithTag("osoInGame").GetComponent<RawImage>();
    }

    private void Start() {
        gameOverAlpha = 0;
        victoryAlpha = 0;
        osoAlpha = 0;
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
        gameOverAlpha = 0;
        gameOverImage.color = new Vector4(1f, 1f, 1f, 0f);
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

    public void setGameOverImageAlpha(float alpha){
        if (gameOverAlpha >= 100.0f){
            return;
        }
        gameOverAlpha += alpha;
        gameOverImage.color = new Vector4(1f, 1f, 1f, gameOverAlpha/100.0f);
    }

    public void setVictoryAlpha(float alpha){
        if (victoryAlpha >= 100.0f){
            return;
        }
        victoryAlpha += alpha;
        victoryImage.color = new Vector4(1f, 1f, 1f, victoryAlpha/100.0f);
    
    }

    public void setOsoInGameAlpha(float alpha){
        if (osoAlpha >= 100.0f){
            return;
        }
        osoAlpha += alpha;
        osoImage.color = new Vector4(1f, 1f, 1f, osoAlpha/100.0f);
    
    }
}