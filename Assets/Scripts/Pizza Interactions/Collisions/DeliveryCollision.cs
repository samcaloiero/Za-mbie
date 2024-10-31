using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryCollision : MonoBehaviour
{

    private PizzaInfo thisPizzaInfo;
    public TextMeshPro orderText;
    public PizzaInfo orderPizzaInfo;
    public TextMeshPro deliveryText;
    public SOSceneManager _SoSceneManager;
    private void Awake()
    {
        thisPizzaInfo = GetComponent<PizzaInfo>();
    }

    //This script needs applied to the area where pizzas need delivered to
    private void OnTriggerExit(Collider other)
    {   
        //Checking to see if the object passing through trigger is a pizza
        if (other.gameObject.CompareTag("Pizza"))
        {
            if (other.gameObject.CompareTag("Pizza"))
            {
                CheckToppings(other.gameObject);
            }  
        }
    }

    private void Update()
    {
        thisPizzaInfo = orderPizzaInfo;
    }

    //
    void CheckToppings(GameObject pizza)
    {
        // Getting access to the pizza info on the pizza collided w/ this box
        PizzaInfo _pizzaInfo = pizza.GetComponent<PizzaInfo>();
        //Checking to see if pizza has proper toppings on it (Idk how to do this)
        //Checking to see if pizza is baked
        if (_pizzaInfo.isBaked == false)
        {
            return;
        }
        if (_pizzaInfo.armTopping == thisPizzaInfo.armTopping && _pizzaInfo.eyeballTopping == thisPizzaInfo.eyeballTopping && _pizzaInfo.legTopping == thisPizzaInfo.legTopping)
        {
            Debug.Log("Pizza Baked, cooked properly, and Delivered");
            deliveryText.text = "Order Complete!";
        }
        Destroy(pizza);
        GiveNextOrder();
    }
    
    
    // void SetOrderText()
    // {
    //     orderText.text = (thisPizzaInfo.armTopping + " Arm Toppings" + "    " + thisPizzaInfo.eyeballTopping + " Eyeball Toppings" + "    " +
    //                       thisPizzaInfo.legTopping + " Leg Toppings");
    // }

    public void GiveNextOrder()
    {
        _SoSceneManager.isThereAPizzaOrder = true;
    }

}
