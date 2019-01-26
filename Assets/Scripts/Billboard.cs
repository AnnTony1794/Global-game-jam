using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    Vector3 t;
    public Camera m_Camera;
    void Start () {
        t = new Vector3(transform.eulerAngles.x, transform.eulerAngles.x, transform.eulerAngles.z);
     }

    void LateUpdate() 
    {
        //transform.LookAt(Camera.main.transform.position, Vector3.up);
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
        m_Camera.transform.rotation * Vector3.up);
        transform.eulerAngles = new Vector3 (t.x, t.y, transform.eulerAngles.z - t.x);
    }

}
