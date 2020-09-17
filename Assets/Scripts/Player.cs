using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private int _lives = 3;
    private Vector3 _direction, _velocity;
    private bool _canWallJump = false;
    private Vector3 _wallSurfaceNormal;
    private float _pushPower = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager == null)
        {
            Debug.LogError("UIManager is null");
        }
        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //IF I WANT TO MAKE THAT THE PLAYER CHANGE ITS POSITION AT MID AIR LEAVE IT HERE if I DONT WANT HIM TO CHANGE POSITION USE IT INSIDE THE isGrounded check
        //Define driection based on input
        //Vector3 direction = new Vector3(horizontalInput, 0, 0);
        //Vector3 direction = new Vector3(horizontalInput, 0, 0);
        //Vector3 velocity = direction * _speed;
        //MOVE based on direction

        //if grounded
        //do nothing
        //else
        //appply gravity
        if(_controller.isGrounded == true)
        {
            _canWallJump = true;
            _direction = new Vector3(horizontalInput, 0, 0);
            //Vector3 direction = new Vector3(horizontalInput, 0, 0);
            _velocity = _direction * _speed;
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
            
            
                if (Input.GetKeyDown(KeyCode.Space) && _canWallJump ==false)
                {
                    if (_canDoubleJump)
                    {
                        _yVelocity += _jumpHeight;
                        _canDoubleJump = false;
                    }
                    
                }
                if (Input.GetKeyDown(KeyCode.Space) && _canWallJump == true)
                {
                //velocity == surfacenormal of the wall
                    _yVelocity = _jumpHeight;
                    _velocity = _wallSurfaceNormal*_speed;

                }
            
            //velocity.y -= _gravity;
            _yVelocity -= _gravity;
        }
        _velocity.y = _yVelocity;

        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        //Check for moving box
        if(hit.transform.tag == "Moving Box")
        {
            Rigidbody box = hit.collider.GetComponent<Rigidbody>();
            if(box!= null)
            {
                Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0,0);
                box.velocity = pushDirection * _pushPower;
            }


        }

        //confirm it has a rigidbody

        //pushpower declare variable

        //push direction

        // push direction * push power



        if(_controller.isGrounded ==false && hit.transform.tag == "Wall")
        {
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
            _wallSurfaceNormal = hit.normal;
            _canWallJump = true;
        }
        
    }

    public void AddCoins()
    {
        _coins++;
        _uiManager.UpdateCoinDisplay(_coins);
    }
    public void Damage()
    {
        _lives--;
        _uiManager.UpdateLivesDisplay(_lives);
        if (_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
    public int GetCoins()
    {
        return _coins;
    }
}
