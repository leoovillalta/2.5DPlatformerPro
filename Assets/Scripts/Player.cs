using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
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
        Vector3 velocity = direction * _speed;
        //MOVE based on direction

        //if grounded
        //do nothing
        //else
        //appply gravity
        if(_controller.isGrounded == true)
        {
            //do nothing maybe jump later
        }
        else
        {
            velocity.y -= _gravity;
        }


        _controller.Move(velocity * Time.deltaTime);
    }
}
