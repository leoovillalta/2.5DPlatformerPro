using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        //Define driection based on input
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        //MOVE based on direction
        _controller.Move(direction * Time.deltaTime);
    }
}
