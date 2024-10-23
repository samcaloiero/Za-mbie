using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PizzaInfo : MonoBehaviour
{
    //This script goes onto a pizza
    
    //Bool for documenting bake status of pizza
    public bool isBaked = false;
    public int armTopping;
    public int eyeballTopping;
    public int legTopping;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Eyeball"))
        {
            eyeballTopping++;
            DisableGrab(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Arm"))
        {
            armTopping++;
            DisableGrab(other.gameObject);
        } 
        else if (other.gameObject.CompareTag("Leg"))
        {
            legTopping++;
            DisableGrab(other.gameObject);
        }
        
    }

     void DisableGrab(GameObject topping)
    {
       XRGrabInteractable grabInt = topping.gameObject.GetComponent<XRGrabInteractable>();
       if (grabInt != false)
       {
           grabInt.enabled = false;
       }
        
    }
}
