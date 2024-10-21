using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingTimer : MonoBehaviour
{
    public Vector3 startingLength;

    public GameObject timerGameObject;


    private float growLength;
    void Start()
    {
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            StartTimer(other.gameObject);
        }
    }

    //This could have functionality to start a timer that ticks up whenever pizza is in the ovens
    void StartTimer(GameObject pizza)
    {
        //Getting reference to the specific pizzas is baked variable
       PizzaInfo _pizzaInfo = pizza.GetComponent<PizzaInfo>();

       if (_pizzaInfo != null)
       {
           //if the pizza has this variable, it gets set to true
           _pizzaInfo.isBaked = true;
       }
        
        //timerGameObject.gameObject.transform.localScale = (startingLength.x, startingLength.y, startingLength.z);
        //Get access to pizza info isBaked an

    }
}
