using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _callButton;
    [SerializeField]
    private int _requiredCoins = 8;
    private Elevator _elevator;
    private bool _elevatorCalled = false;

    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
        if (_elevator == null)
        {
            Debug.LogError("Elevator is null");
        }
    }
    // private bool _requirementsMet = false;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            //_requirementsMet = other.GetComponent<Player>().GetCoins() >= _requiredCoins;
            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().GetCoins() >= _requiredCoins)
            {
                if (_elevatorCalled == true)
                {
                    _callButton.material.color = Color.red;
                }
                else
                {
                    _callButton.material.color = Color.green;
                    _elevatorCalled = true;
                }
                
                _elevator.CallElevator();
               //call elevator

            }
            //else if(Input.GetKeyDown(KeyCode.E) && !_requirementsMet)
            //{
            //    Debug.Log("Error Sound");
            //    //error sound
            //}

        }
       
    }
}
