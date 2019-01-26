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
    public void ShowMainMenu(){
        menuCanvas.enabled = true;
    }
    public void HideMainMenu(){
        menuCanvas.enabled = false;
    }

    public void ShowGameMenu(){
        gameCanvas.enabled = true;
    }
    public void HideGameMenu(){
        gameCanvas.enabled = false;
    }

    public void ShowGameOverMenu(){
        gameOverCanvas.enabled = true;
    }
    public void HideGameOverMenu(){
        gameOverCanvas.enabled = false;
    }
}
