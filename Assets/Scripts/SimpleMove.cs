using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float time = 0.3f;
    public int damage = 20;
    public float RotationSpeed = 2;
    public int gainSanity = 2;

    public float Speed = 1.9f;

    public float gainSanitySpeed = 0.2f;

    public Animator animator;
    private AudioSource[] audios;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        InvokeRepeating("insanity", 1f, time);
        //GetComponent<AudioSource>().Play();
        audios = GetComponents<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        float a = Mathf.Abs(hor) + Mathf.Abs(ver);
        animator.SetFloat("Speed", a);
        Debug.Log(a);

        Vector3 playerMovement = new Vector3(hor, 0, ver) * 10 * Time.deltaTime;
        transform.Translate(playerMovement * Speed, Space.Self);

        

        hor = Input.GetAxis("Horizontal2");
        transform.Rotate(0, hor * 1.2f, 0);

        if(hor*11.0f<=-10.0f)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

        animator.SetFloat("TurnSpeed", hor*11.0f);

       if(ver != 0 || hor != 0){
            if(audios[1].isPlaying){
                return;
            }
            audios[1].Play();
        }else{
            audios[1].Pause();
        }
    }

    private void insanity()
    {
        SanityManager.sharedInstance.sanityIncrease(damage);
    }
    private void sanity()
    {
        SanityManager.sharedInstance.sanityDecrease(gainSanity);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fire")
        {
            InvokeRepeating("sanity", 1f, gainSanitySpeed);
        }
        if (other.tag == "oso"){
            GameManager.sharedInstance.osoide = true;
            other.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (other.tag == "house" && GameManager.sharedInstance.osoide){
            GameManager.sharedInstance.win();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "fire")
        {
            CancelInvoke("sanity");
        }
    }
}
