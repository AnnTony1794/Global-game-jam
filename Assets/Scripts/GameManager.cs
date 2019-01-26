using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    inGame,
    menu,
    gameOver,
    paused,
    victory,
    credits
}

public class GameManager : MonoBehaviour
{
    //=========================================================================
    //Variables
    //=========================================================================
    public static GameManager sharedInstance; //Singleton
    public GameState currentGameState; //GameState


    private void Awake() {
        //Instanciate singleton
        if(sharedInstance == null){
            sharedInstance = this;
        }    
    }


    //=========================================================================
    //Unity methods
    //=========================================================================
    // Start is called before the first frame update
    void Start()
    {
        currentGameState  = GameState.menu;
    }

    // Update is called once per frame
    void Update()
    {
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
        //Esconder todos los demás menus.
        MenuManager.sharedInstance.hideNotInGameMenus();
        //Poner el estado del juego inGame.
        currentGameState = GameState.inGame;
    }
    public void pauseGame(){
        MenuManager.sharedInstance.showPauseMenu();
        currentGameState = GameState.paused;
    }
    public void die(){
        MenuManager.sharedInstance.showGameOverMenu();
        currentGameState = GameState.gameOver;
    }
    public void win(){
        MenuManager.sharedInstance.showVictoryMenu();
        currentGameState = GameState.victory;
    }
    public void restartGame(){
        startGame();
        //Resetear al personaje y regresarlo al punto de inicio.
        //Resetear el nivel si es que hay cambios a lo largo de la partida.
    }

}
