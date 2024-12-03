using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToppingsCollision : MonoBehaviour
{
    public SOSceneManager _SoSceneManager;
    private Rigidbody _rigidbody;
    private bool isPizzaGrabDisabled = false;
    public float pizzaWaitTime = 2.0f;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            //Disable Rigid Body
            Debug.Log("Collision Succesful");
            StartCoroutine(DisablePizzaGrab(other.gameObject)); 
            _rigidbody.detectCollisions = false;
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
            //Make topping child of pizza
            transform.SetParent(other.gameObject.transform);
            //disable pizza grab int for five seconds
        }
    }

    public IEnumerator DisablePizzaGrab(GameObject pizza)
    {
        if (isPizzaGrabDisabled) yield break;

        XRGrabInteractable xrGrab = pizza.GetComponent<XRGrabInteractable>();
        if (xrGrab != null)
        {
            isPizzaGrabDisabled = true;
            Debug.Log("Disabling pizza grab");
            xrGrab.enabled = false;
            yield return new WaitForSeconds(pizzaWaitTime);
            xrGrab.enabled = true;
            isPizzaGrabDisabled = false;
        }
        else
        {
            Debug.LogError("XRGrabInteractable not found on the Pizza object.");
        }
    }

    public void SetGrabbingToppingsTrue()
    {
        Debug.Log("Topping Getting Grabbed");
        _SoSceneManager.grabbingToppings = true;
    }

    public void SetGrabbingToppingsFalse()
    {
        Debug.Log("Topping Let Go");
        _SoSceneManager.grabbingToppings = false;
    }
}
