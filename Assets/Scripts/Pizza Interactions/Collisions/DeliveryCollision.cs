using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryCollision : MonoBehaviour
{

    private PizzaInfo thisPizzaInfo;
    public PizzaInfo orderPizzaInfo;
    public SOSceneManager _SoSceneManager;
    
    public ParticleSystem correctPizzaFX;
    public ParticleSystem incorrectPizzaFX;
    public AudioSource zombieEating;
    public AudioSource madZombie;
    public AudioSource morePizza;

    private void Awake()
    {
        thisPizzaInfo = GetComponent<PizzaInfo>();
    }

    private void OnTriggerEnter(Collider other)
    {   
        //Checking to see if the object passing through trigger is a pizza
        if (other.gameObject.CompareTag("Pizza"))
        {
            if (other.gameObject.CompareTag("Pizza"))
            {
                CheckToppings(other.gameObject);
            }  
        }
    }

    private void Update()
    {
        thisPizzaInfo = orderPizzaInfo;
        Debug.Log("The required pizza needs this many arm toppings: " + thisPizzaInfo.armTopping);
    }

    //
    void CheckToppings(GameObject pizza)
    {
        // Getting access to the pizza info on the pizza collided w/ this box
        PizzaInfo _pizzaInfo = pizza.GetComponent<PizzaInfo>();
        Debug.Log("This is the pizza made's amount of arm toppings" +_pizzaInfo.armTopping);
        //Checking to see if pizza has proper toppings on it (Idk how to do this)
        //Checking to see if pizza is baked
        if (_pizzaInfo.isBaked == false)
        {
            return;
        }
        if (_pizzaInfo.armTopping == thisPizzaInfo.armTopping && _pizzaInfo.eyeballTopping == thisPizzaInfo.eyeballTopping && _pizzaInfo.legTopping == thisPizzaInfo.legTopping)
        {
            Debug.Log("Correct Pizza Made");
            correctPizzaFX.Play();
            zombieEating.Play();
            morePizza.Play();
            GiveNextOrder();
            
        }
        else
        {
            Debug.Log("Incorrect Pizza Made :/");
            madZombie.Play();
            incorrectPizzaFX.Play();
        }
        Destroy(pizza);
        
    }
    
    
    // void SetOrderText()
    // {
    //     orderText.text = (thisPizzaInfo.armTopping + " Arm Toppings" + "    " + thisPizzaInfo.eyeballTopping + " Eyeball Toppings" + "    " +
    //                       thisPizzaInfo.legTopping + " Leg Toppings");
    // }

    public void GiveNextOrder()
    {
        _SoSceneManager.correctPizzasMade++;
        _SoSceneManager.isThereAPizzaOrder = true;
    }

}
