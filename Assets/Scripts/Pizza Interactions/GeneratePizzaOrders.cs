using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneratePizzaOrders : MonoBehaviour
{
    [Header("Number of Topping Type Permitted")] 
    public int eyeBalls;

    public int arms;

    public int legs;

    [Tooltip("The amount of toppings on each pizza")]
    public int toppingsAmount;

    public GameObject ticket;
    public SOSceneManager _SoSceneManager;
    public void GeneratePizza(PizzaInfo pizzaInfo)
    {
        int currentToppings = 0;
        //Rotate through toppings

        while (currentToppings < toppingsAmount)
        {
            //Add Toppings into list here
            pizzaInfo.eyeballTopping += Random.Range(0, eyeBalls);
            currentToppings += pizzaInfo.eyeballTopping;
            pizzaInfo.armTopping += Random.Range(0, arms);
            currentToppings += pizzaInfo.armTopping;
            pizzaInfo.legTopping += Random.Range(0, legs);
            currentToppings += pizzaInfo.legTopping;
        }
    }

    private void Update()
    {
        if (_SoSceneManager.isThereAPizzaOrder)
        {
            _SoSceneManager.isThereAPizzaOrder = false;
            Instantiate(ticket);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ticket"))
        {
            PizzaInfo pizzaInfo = other.gameObject.GetComponent<PizzaInfo>();
            GeneratePizza(pizzaInfo);
        }
        
    }
}
