using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSnap : MonoBehaviour
{
    public GameObject ticketToGrab;
    public GameObject ticketPlaced;
    public SOSceneManager _SoSceneManager;
    public GeneratePizzaOrders _GeneratePizzaOrders;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ticket"))
        {
            Destroy(other.gameObject); 
            //Transfer pizza variables
            
           //Generate pizza
            PizzaInfo pizzaInfo = other.gameObject.GetComponent<PizzaInfo>();
            _GeneratePizzaOrders.GeneratePizza(pizzaInfo);
            ticketPlaced.SetActive(true);
        }  
    }

    private void Update()
    {
        if (_SoSceneManager.isThereAPizzaOrder == false)
        {
            ticketPlaced.SetActive(false);   
        }
    }
}
