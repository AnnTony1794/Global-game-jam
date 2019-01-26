using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2do : MonoBehaviour
{
    public CharacterController _controller;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(v * Time.deltaTime * Speed);
    }
}
