using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TicketSnap : MonoBehaviour
{
    public GameObject ticketPlaced;
    public TextMeshPro orderText;
    public SOSceneManager _SoSceneManager;
    public GeneratePizzaOrders _GeneratePizzaOrders;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ticket"))
        {
            
            //Transfer pizza variables
            
           //Generate pizza
            PizzaInfo pizzaInfo = other.gameObject.GetComponent<PizzaInfo>();
            _GeneratePizzaOrders.GeneratePizza(pizzaInfo);
            ticketPlaced.SetActive(true);
            SetOrderText(pizzaInfo);
            Destroy(other.gameObject); 
        }  
    }

    private void Update()
    {
        if (_SoSceneManager.isThereAPizzaOrder == false)
        {
            ticketPlaced.SetActive(false);   
        }
    }
    void SetOrderText(PizzaInfo thisPizzaInfo)
    {
        orderText.text = (thisPizzaInfo.armTopping + " Arm Toppings" + "    " + thisPizzaInfo.eyeballTopping + " Eyeball Toppings" + "    " +
                          thisPizzaInfo.legTopping + " Leg Toppings");
    }
}
