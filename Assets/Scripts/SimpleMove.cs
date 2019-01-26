using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{

    float mouseX, mouseY;
    public float RotationSpeed = 1;
    void Start()
    {
        
    }
    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, -ver, 0.0f) * 10 * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * -RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -30f, 60f);
        transform.Rotate(mouseX, mouseY, 0);
        /*
        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
        */

    }
}
