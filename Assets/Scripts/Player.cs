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
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    [SerializeField]
    private int _coins;
    private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager == null)
        {
            Debug.LogError("UIManager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        //Define driection based on input
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        //Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;
        //MOVE based on direction

        //if grounded
        //do nothing
        //else
        //appply gravity
        if(_controller.isGrounded == true)
        {
            //do nothing maybe jump later
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //velocity.y += _jumpHeight; Este al cambiar la direccion en el siguiente frame se regresa a 0, por eso es el error
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
           
        }
        else
        {
            if (_canDoubleJump)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }
            //velocity.y -= _gravity;
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }
    public void AddCoins()
    {
        _coins++;
        _uiManager.UpdateCoinDisplay(_coins);
    }
}
