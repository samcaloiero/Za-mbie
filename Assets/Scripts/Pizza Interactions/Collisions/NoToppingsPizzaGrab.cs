using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NoToppingsPizzaGrab : MonoBehaviour
{
    public SOSceneManager _SoSceneManager;

    private XRGrabInteractable _xrGrabInteractable;
    // Start is called before the first frame update
    void Start()
    {
        _xrGrabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        //if toppings are being grabbed disable the pizzas grab interact
        if (_SoSceneManager.grabbingToppings)
        {
            _xrGrabInteractable.enabled = false;
        }
        //if toppings are not being grabbed enable the pizzas grab interact
        if (_SoSceneManager.grabbingToppings == false)
        {
            _xrGrabInteractable.enabled = true;
        }
    }

    public void DisablePizza()
    {
        Debug.Log("Pizza is detecting grab");
    }
}
