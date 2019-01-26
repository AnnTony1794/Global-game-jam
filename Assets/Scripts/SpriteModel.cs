using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteModel : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.rotation = mainCamera.transform.rotation;
        // transform.rotation = Quaternion.LookRotation(-mainCamera.transform.forward);
        // transform.eulerAngles = new Vector3(90.0f, transform.eulerAngles.y, transform.eulerAngles.z);
        // print(transform.rotation);
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(-mainCamera.transform.forward);
        // transform.eulerAngles = new Vector3(90.0f, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
