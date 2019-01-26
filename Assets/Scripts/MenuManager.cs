using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //=========================================================================
    //Variables
    //=========================================================================
    public static MenuManager sharedInstance;
    public Canvas menuCanvas, gameCanvas, gameOverCanvas;    


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
}
