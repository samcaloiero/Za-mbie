using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketSnap : MonoBehaviour
{
    public GameObject ticketToGrab;
    public GameObject ticketPlaced;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ticket"))
        {
            ticketToGrab.SetActive(false);
            ticketPlaced.SetActive(true);
        }  
    }
    

}
