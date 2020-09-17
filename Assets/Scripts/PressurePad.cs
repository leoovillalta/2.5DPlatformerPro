using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    //detect moving box
    //when close to center
    //disable the box rigidbody or set to kinematic
    //change color of pressure pad to blue

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Moving Box")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Distance: " + distance);
            if (distance < 0.1 )
            {
                Rigidbody box = other.GetComponent<Rigidbody>();
                if(box != null)
                {
                    box.isKinematic = true;
                }
                //other.GetComponent<Rigidbody>().isKinematic = true;
                MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.blue;
                }
               // GetComponent<MeshRenderer>().material.color = Color.blue;
                Destroy(this);
            }
        }
    }
}
