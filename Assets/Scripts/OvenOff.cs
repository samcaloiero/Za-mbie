using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenOff : MonoBehaviour
{
    public Material grateMaterial;
    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            Color color = grateMaterial.color;
            
            color.a = 0;
            
            grateMaterial.color = color;
        }  
    }
}
