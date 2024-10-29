using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BakingTimer : MonoBehaviour
{
    public int countdownTime = 10;
    public TextMeshPro timerText;
    public GameObject flamesPS;

    private float growLength;
    void Start()
    {
        flamesPS.SetActive(false);
        timerText.text = "Baking Timer";
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
       
        PizzaInfo _pizzaInfo = pizza.GetComponent<PizzaInfo>();
        if (_pizzaInfo.isBaked)
        {
            yield break;
        }
        int currentTime = countdownTime;
        flamesPS.SetActive(true);
        //Getting reference to the specific pizzas is baked variable
        
        while (currentTime > 0)
        {
            timerText.text = currentTime.ToString();

            yield return new WaitForSeconds(1f);

            currentTime--;
        }

        if (currentTime == 0)
        {
            if (_pizzaInfo != null)
            {
                //if the pizza has this variable, it gets set to true
                _pizzaInfo.isBaked = true;
                timerText.text = "Pizza Baked";
                flamesPS.SetActive(false);
            }  
        }
     
        
        //timerGameObject.gameObject.transform.localScale = (startingLength.x, startingLength.y, startingLength.z);
        //Get access to pizza info isBaked an

    }
}
