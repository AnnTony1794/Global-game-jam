using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera m_Camera;
    void Start () {
        m_Camera = Camera.main;
     }

    void LateUpdate() 
    {
        
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
        m_Camera.transform.rotation * Vector3.up);
        
        //transform.rotation = Quaternion.LookRotation(-m_Camera.transform.forward);
    }

}
