using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrders : MonoBehaviour
{

    public SOSceneManager _SoSceneManager;

    public GameObject ticket;
    void Update()
    {
        Debug.Log(_SoSceneManager.isThereAPizzaOrder);
        if (_SoSceneManager.isThereAPizzaOrder)
        {
            Debug.Log("Spawn Ticket");
            _SoSceneManager.isThereAPizzaOrder = false;
            Instantiate(ticket,transform);
        }

    }
}
