using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool _goingDown = false;
    [SerializeField]
    private Transform _origin, _target;
    [SerializeField]
    private float _speed = 1.0f;
    public void CallElevator()
    {
        _goingDown = !_goingDown;
        //know current position of the elevator
        //
    }
    private void FixedUpdate()
    {
        //going down == true
        //take current position = move towards target pos
        //else
        //take current position move towards target
        if (_goingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(transform.position, )
        }
        else if(_goingDown==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _origin.position, _speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
