using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _moveSpeed = 1.0f;
    private bool _right = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(transform.position == _targetB.position)
        {
            _right = false;
        }else if(transform.position == _targetA.position)
        {
            _right = true;
        }
        if (_right)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _moveSpeed * Time.deltaTime);
        }
        //go to point b
        //if at point b
        //go to point a
        //if at point a
        //go to point b

    }
}
