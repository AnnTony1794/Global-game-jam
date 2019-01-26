using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    inGame,
    menu,
    gameOver,
    paused
}

public class GameManager : MonoBehaviour
{
    //=========================================================================
    //Variables
    //=========================================================================
    public static GameManager sharedInstance; //Singleton
    public GameState currentGameState = GameState.menu; //GameState


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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    //=========================================================================
    //Our methods
    //=========================================================================
    
    private void SetGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.inGame:
            //TODO: Iniciar o reiniciar la escena.
            break;
            case GameState.menu:
            startGame();
            break;
            case GameState.gameOver:
            //TODO: Lógica de muerte.
            break;
        }
    }
    public void startGame(){
        MenuManager.sharedInstance.hideMainMenu();
        currentGameState = GameState.inGame;
    }
}
