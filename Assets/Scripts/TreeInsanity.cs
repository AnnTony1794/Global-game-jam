using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInsanity : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        /*
        
            1(A) -> 100(B)
            insanity(C) -> (x)


         */

        // float x = SanityManager.sharedInstance.playerSanity / 100;
        // animator.SetFloat("Insanity", x);
        animator.SetFloat("Insanity", SanityManager.sharedInstance.playerSanity);
    }
}
