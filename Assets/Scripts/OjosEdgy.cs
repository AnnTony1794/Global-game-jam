using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjosEdgy : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float edgy = SanityManager.sharedInstance.playerSanity / 60.0f;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, edgy);
    }
}
