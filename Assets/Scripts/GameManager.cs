﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //=========================================================================
    //Variables
    //=========================================================================
    public static GameManager sharedInstance; //Singleton
    public GameState currentGameState; //GameState
    private AudioSource audio;
    public bool osoide;
    private int randomBear;

    private GameObject osos;

    private void Awake() {
        //Instanciate singleton
        if(sharedInstance == null){
            sharedInstance = this;
        }
        audio = GetComponent<AudioSource>();
        osos = GameObject.Find("Ositos");
    }


    //=========================================================================
    //Unity methods
    //=========================================================================
    // Start is called before the first frame update
    void Start()
    {
        currentGameState  = GameState.menu;
        osoide = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState == GameState.menu){
            if (Input.GetButtonDown("Submit")){
                startGame();
            }
        }
        if(Input.GetButtonDown("Cancel")){
            if(currentGameState == GameState.inGame){
                setGameState(GameState.paused);
            }
            else if(currentGameState == GameState.paused){
                setGameState(GameState.inGame);
            }
            else if(currentGameState == GameState.gameOver){
                restartGame();
            }
            else if(currentGameState == GameState.victory){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if(currentGameState == GameState.menu){
                MenuManager.sharedInstance.showCreditsMenu();
                MenuManager.sharedInstance.hideMainMenu();
                currentGameState = GameState.credits;
            }
            else if(currentGameState == GameState.credits){
                MenuManager.sharedInstance.hideCreditsMenu();
                MenuManager.sharedInstance.showMainMenu();
                currentGameState = GameState.menu;
            }
        }
        if (currentGameState == GameState.gameOver){
            MenuManager.sharedInstance.setGameOverImageAlpha(0.7f);
        }
        if (currentGameState == GameState.victory){
            MenuManager.sharedInstance.setVictoryAlpha(0.7f);
        }
        if (osoide){
            MenuManager.sharedInstance.setOsoInGameAlpha(2f);
        }
    }
    

    //=========================================================================
    //Our methods
    //=========================================================================
    
    private void setGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.inGame:
            startGame();
            break;
            case GameState.menu:
            pauseGame();
            break;
            case GameState.gameOver:
            die();
            break;
            case GameState.paused:
            pauseGame();
            break;
        }
    }
    public void startGame(){
        audio.Play();
        //Esconder todos los demás menus.
        MenuManager.sharedInstance.hideNotInGameMenus();
        ContinueGame();
        if(currentGameState == GameState.paused || currentGameState == GameState.menu){
        }
        if(currentGameState == GameState.gameOver){
                SanityManager.sharedInstance.playerSanity = 0;
        }
        //Poner el estado del juego inGame.
        currentGameState = GameState.inGame;
    }
    public void pauseGame(){
        audio.Pause();
        MenuManager.sharedInstance.showPauseMenu();
        currentGameState = GameState.paused;
        PauseGame();
    }
    public void die(){
        audio.Stop();
        pauseGame();
        MenuManager.sharedInstance.hidePauseMenu();
        MenuManager.sharedInstance.showGameOverMenu();
        currentGameState = GameState.gameOver;
    }
    public void win(){
        audio.Stop();
        PauseGame();
        MenuManager.sharedInstance.showVictoryMenu();
        currentGameState = GameState.victory;
    }
    public void restartGame(){
        startGame();
        //Resetear al personaje y regresarlo al punto de inicio.
        Checkpoint.sharedInstance.restartOnCheckpoint();
        //Resetear el nivel si es que hay cambios a lo largo de la partida.
    }


    private void PauseGame()
    {
        Time.timeScale = 0;
        //Disable scripts that still work while timescale is set to 0
        GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMove>().enabled = false;
        GameObject.Find("InGameCanvas").GetComponent<InGameScript>().enabled = false;
    } 
    private void ContinueGame()
    {
        Time.timeScale = 1;
        //enable the scripts again
        GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleMove>().enabled = true;
        GameObject.Find("InGameCanvas").GetComponent<InGameScript>().enabled = true;
    }
}
public enum GameState
{
    inGame,
    menu,
    gameOver,
    paused,
    victory,
    credits
}
