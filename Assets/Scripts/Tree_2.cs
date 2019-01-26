using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_2 : MonoBehaviour
{
    public SpriteRenderer tree_normal;
    public SpriteRenderer tree_edgy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //float edgy = SanityManager.sharedInstance.playerSanity / 100; //rememeber kids, do not divide by a int number of you are expecting
        //float results

        float edgy = SanityManager.sharedInstance.playerSanity / 100.0f;
        float normal = ((SanityManager.sharedInstance.playerSanity * -1.0f) + 100.0f)/100.0f; //Number * negative + max value, implying min is 0
        tree_edgy.color = new Color(tree_edgy.color.r, tree_edgy.color.g, tree_edgy.color.b, edgy);

        /*
            x = bc / a;
            100 -> 1
            50 -> x
        */

        //float aaa = 100.0*Mathf.Abs(SanityManager.sharedInstance.playerSanity - 0)/(double)Mathf.Max(SanityManager.sharedInstance.playerSanity, 0)
        tree_normal.color = new Color(tree_normal.color.r, tree_normal.color.g, tree_normal.color.b, normal);


    }
}
