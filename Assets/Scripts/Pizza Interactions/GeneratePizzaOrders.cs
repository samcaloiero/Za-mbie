using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshPro orderText;
    public PizzaInfo thisPizzaInfo;
    
    private void Awake()
    {

        thisPizzaInfo = gameObject.GetComponent<PizzaInfo>();
        GeneratePizza(thisPizzaInfo);
    }
    

    

    private void Update()
    {
        Debug.Log(_SoSceneManager.isThereAPizzaOrder);
        if (_SoSceneManager.isThereAPizzaOrder)
        {
            _SoSceneManager.isThereAPizzaOrder = false;
           GeneratePizza(thisPizzaInfo);
           SetOrderText(thisPizzaInfo);
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Ticket"))
    //     {
    //         PizzaInfo pizzaInfo = other.gameObject.GetComponent<PizzaInfo>();
    //         GeneratePizza(pizzaInfo);
    //         thisPizzaInfo = pizzaInfo;
    //     }
    //     
    // }
    void SetOrderText(PizzaInfo _pizzaInfo)
    {
        orderText.text = (_pizzaInfo.armTopping + " Arm Toppings" + "    " + _pizzaInfo.eyeballTopping + " Eyeball Toppings" + "    " +
                          _pizzaInfo.legTopping + " Leg Toppings");
    }
    // public void GeneratePizza(PizzaInfo pizzaInfo)
    // {
    //     int currentToppings = 0;
    //     //Rotate through toppings
    //
    //     while (currentToppings < toppingsAmount)
    //     {
    //         //Add Toppings into list here
    //         pizzaInfo.eyeballTopping += Random.Range(0, eyeBalls);
    //         currentToppings += pizzaInfo.eyeballTopping;
    //         pizzaInfo.armTopping += Random.Range(0, arms);
    //         currentToppings += pizzaInfo.armTopping;
    //         pizzaInfo.legTopping += Random.Range(0, legs);
    //         currentToppings += pizzaInfo.legTopping;
    //     }
    // }
    
    public void GeneratePizza(PizzaInfo pizzaInfo)
    {
        // Reset topping values to prevent accumulation across multiple calls
        pizzaInfo.eyeballTopping = 0;
        pizzaInfo.armTopping = 0;
        pizzaInfo.legTopping = 0;

        int currentToppings = 0;

        while (currentToppings < toppingsAmount)
        {
            int eyeballToppingToAdd = Random.Range(0, eyeBalls);
            int armToppingToAdd = Random.Range(0, arms);
            int legToppingToAdd = Random.Range(0, legs);

            // Check if adding these toppings would exceed the limit
            if (currentToppings + eyeballToppingToAdd + armToppingToAdd + legToppingToAdd > toppingsAmount)
                break;

            // Add toppings if within the limit
            pizzaInfo.eyeballTopping += eyeballToppingToAdd;
            pizzaInfo.armTopping += armToppingToAdd;
            pizzaInfo.legTopping += legToppingToAdd;

            // Update current topping count
            currentToppings += eyeballToppingToAdd + armToppingToAdd + legToppingToAdd;
        }
    }
}
