using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingsCollision : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Topping"))
        {
            //Disable Rigid Body
            //Make topping child of pizza
        }
    }
    
}
