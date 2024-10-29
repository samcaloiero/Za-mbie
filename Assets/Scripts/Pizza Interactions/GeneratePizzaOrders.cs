using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePizzaOrders : MonoBehaviour
{
    [Header("Number of Topping Type Permitted")] 
    public int eyeBalls;

    public int arms;

    public int legs;

    [Tooltip("The amount of toppings on each pizza")]
    public int toppingsAmount;
    
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
}
