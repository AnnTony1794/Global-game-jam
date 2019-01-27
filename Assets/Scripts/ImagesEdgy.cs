using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesEdgy : MonoBehaviour
{
    public SpriteRenderer img_normal;
    public SpriteRenderer img_edgy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //float edgy = SanityManager.sharedInstance.playerSanity / 100; //rememeber kids, do not divide by a int number of you are expecting
        //float results

        float edgy = SanityManager.sharedInstance.playerSanity / 60.0f;
        float normal = ((SanityManager.sharedInstance.playerSanity * -1.0f) + 100.0f) / 100.0f; //Number * negative + max value, implying min is 0
        img_edgy.color = new Color(img_edgy.color.r, img_edgy.color.g, img_edgy.color.b, edgy);

        /*
            x = bc / a;
            100 -> 1
            50 -> x
        */

        //float aaa = 100.0*Mathf.Abs(SanityManager.sharedInstance.playerSanity - 0)/(double)Mathf.Max(SanityManager.sharedInstance.playerSanity, 0)
        img_normal.color = new Color(img_normal.color.r, img_normal.color.g, img_normal.color.b, normal);


    }
}
