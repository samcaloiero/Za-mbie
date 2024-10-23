using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BakingTimer : MonoBehaviour
{
    public int countdownTime = 10;
    public TextMeshPro timerText;


    private float growLength;
    void Start()
    {
        timerText.text = "test";
    }
    
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            StartCoroutine(StartTimer(other.gameObject)) ;
        }
    }

    //This could have functionality to start a timer that ticks up whenever pizza is in the ovens
    

    IEnumerator StartTimer(GameObject pizza)
    {
        int currentTime = countdownTime;
        
        //Getting reference to the specific pizzas is baked variable
        PizzaInfo _pizzaInfo = pizza.GetComponent<PizzaInfo>();
        while (currentTime > 0)
        {
            timerText.text = currentTime.ToString();

            yield return new WaitForSeconds(1f);

            currentTime--;
        }
        
        
        if (_pizzaInfo != null)
        {
            //if the pizza has this variable, it gets set to true
            _pizzaInfo.isBaked = true;
            timerText.text = "Pizza Baked";
        }
        

        //timerGameObject.gameObject.transform.localScale = (startingLength.x, startingLength.y, startingLength.z);
        //Get access to pizza info isBaked an

    }
}
