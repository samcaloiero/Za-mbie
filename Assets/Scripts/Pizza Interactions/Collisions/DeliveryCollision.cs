using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCollision : MonoBehaviour
{
    //This script needs applied to the area where pizzas need delivered to
    private void OnTriggerExit(Collider other)
    {   
        //Checking to see if the object passing through trigger is a pizza
        if (other.gameObject.CompareTag("Pizza"))
        {
            if (other.gameObject.CompareTag("Pizza"))
            {
                ExecuteDelivery(other.gameObject);
            }  
        }
    }

    //
    void ExecuteDelivery(GameObject pizza)
    {
        // Getting access to the pizza info on the pizza collided w/ this box
        PizzaInfo _pizzaInfo = pizza.GetComponent<PizzaInfo>();
        //Checking to see if pizza has proper toppings on it (Idk how to do this)
        CheckToppings(pizza);
        //Checking to see if pizza is baked
        if (_pizzaInfo.isBaked)
        {
            Debug.Log("Pizza Baked and Delivered");
        }
        else if (_pizzaInfo.isBaked = false)
        {
            Debug.Log("Pizza not baked!");
        }

    }

    void CheckToppings(GameObject pizza)
    {
        
    }
    
}
