using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingsCollision : MonoBehaviour
{
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            //Disable Rigid Body
            Debug.Log("Collision Succesful");

            _rigidbody.detectCollisions = false;
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
            //Make topping child of pizza
            transform.SetParent(other.gameObject.transform);
        }
    }
    
}
