using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public SOSceneManager _SoSceneManager;
    
    void Start()
    {
        _SoSceneManager.isThereAPizzaOrder = false;
    }
    
    void Update()
    {
        if (_SoSceneManager.isThereAPizzaOrder)
        {
            _SoSceneManager.isThereAPizzaOrder = false;
            CreateNewOrder();
        }
    }

    void CreateNewOrder()
    {
        
    }
}
