using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float time = 1f;
    public int damage = 1;
    public float RotationSpeed = 1;
    void Start()
    {
        InvokeRepeating("insanity", 1f, time);
    }
    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0, ver) * 10 * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        hor = Input.GetAxis("Horizontal2");
        transform.Rotate(0, hor*1.2f, 0);
    }

    private void insanity(){
        SanityManager.sharedInstance.sanityIncrease(damage);
    }
}
