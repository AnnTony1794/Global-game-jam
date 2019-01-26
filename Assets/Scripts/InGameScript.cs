using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScript : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Sanity: " + SanityManager.sharedInstance.playerSanity;
        MenuManager.sharedInstance.setGameCanvasState(
            SanityManager.sharedInstance.playerSanity
        );
    }
}
