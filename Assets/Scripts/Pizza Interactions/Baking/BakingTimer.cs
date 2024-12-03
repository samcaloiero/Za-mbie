using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BakingTimer : MonoBehaviour
{
    public SOSceneManager _SoSceneManager;
    public int currentTime;
    public int countdownTime = 15;
    public TextMeshPro timerText;
    public GameObject flamesPS;
    public Material grateMaterial;


    private float growLength;
    void Start()
    {
        flamesPS.SetActive(false);
        timerText.text = "Baking Timer";
        
        //alpha of grate off
        Color color = grateMaterial.color;
        color.a = 0;
        grateMaterial.color = color;
    }
    
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            StartCoroutine(StartTimer(other.gameObject)) ; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            StartCoroutine(StartTimer(other.gameObject)) ; 
        }
        
    }

    //This could have functionality to start a timer that ticks up whenever pizza is in the ovens
    

    IEnumerator StartTimer(GameObject pizza)
    {
        _SoSceneManager.pizzaBaking = true;
        PizzaInfo _pizzaInfo = pizza.GetComponent<PizzaInfo>();
        if (_pizzaInfo.isBaked)
        {
            yield break;
        }
        currentTime = countdownTime;
        flamesPS.SetActive(true);
        Color color = grateMaterial.color;
        color.a = 1;
        grateMaterial.color = color;
        
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
                _SoSceneManager.pizzaBaking = false;
                //if the pizza has this variable, it gets set to true
                _pizzaInfo.isBaked = true;
                timerText.text = "Pizza Baked";
                flamesPS.SetActive(false);
                color.a = 0;
                grateMaterial.color = color;
            }  
        }
     
        
        //timerGameObject.gameObject.transform.localScale = (startingLength.x, startingLength.y, startingLength.z);
        //Get access to pizza info isBaked an

    }
    public void DecreaseCurrentTime(int amount)
    {
        currentTime = Mathf.Max(0, currentTime - amount); // Ensure timer doesn't go below 0
    }
}
