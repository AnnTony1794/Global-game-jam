using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    /*
    ===========================================================================
    Variables.
    ===========================================================================
    */ 
    
    //Enum
    public GameState currentGameState = GameState.menu;
    //Player controller
    private PlayerController controller;
    //Singleton
    public static GameManager sharedInstance;


    /*
    ===========================================================================
    Unity methods.
    ===========================================================================
    */

    // Initialize variables here.
    private void Awake()
    {
        if (sharedInstance == null){
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    // Set initial state here.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Este metodo es llamado el mismo numero de veces cada segundo. Siempre.
    void private void FixedUpdate() 
    {
        
    }

    // Cuando ocurre una colisión
    void private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "")
        {
            
        }
    }

    /*
    ===========================================================================
    Our methods.
    ===========================================================================
    */
}
