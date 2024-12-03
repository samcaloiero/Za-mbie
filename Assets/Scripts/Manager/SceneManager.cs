using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [Header("Round Values")]
    [Tooltip("Amount of time for the round")]
    public float roundTime = 120;
    [Tooltip("The number of pizzas required to get right to advance")]
    public int numPizzasRequired;
    //Add Toppings Logic here to
    [Header("Scenes")]
    public string sceneToAdvTo;
    public string losingScene;
    [Header("")]
    [Tooltip("Attach the Scene Manager Scriptable Object here")]
    public SOSceneManager _SoSceneManager;

    public TextMeshPro minutesTimer;
    public TextMeshPro ordersLeft;
    
    private float minutes;
    private float seconds;

    [Header("Left and Right VR Hands")]
    public GameObject leftHand;

    public GameObject rightHand;
   
    [Header("Number of Topping Type Permitted")] 
    public int eyeBalls;

    public int arms;

    public int legs;

    [Tooltip("The amount of toppings on each pizza")]
    public int toppingsAmount;

    private PizzaInfo orderPizzaInfo;
    // Start is called before the first frame update
    void Start()
    {
        orderPizzaInfo = GetComponent<PizzaInfo>();
        _SoSceneManager.isThereAPizzaOrder = true;

        _SoSceneManager.grabbingToppings = false;
        
        _SoSceneManager.correctPizzasMade = 0;
        
        //Find out which hand to activate to true
        if (_SoSceneManager.leftHand == false)
        {
            leftHand.SetActive(false);
        }
        else if (_SoSceneManager.rightHand == false)
        {
            rightHand.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayOrdersLeft();
        //change round if user makes enough pizzas
        if (numPizzasRequired == _SoSceneManager.correctPizzasMade)
        {
            //Putting UnityEngine here bc of the name of the script
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneToAdvTo);
        }
        //Count Down Timer
        //Make player lose if run out of time
        CountDownTimer();
        if (roundTime < 0)
        {
            PlayLosingSequence();
        }
        //generating a pizza order here
        if (_SoSceneManager.isThereAPizzaOrder)
        {
            GeneratePizza(orderPizzaInfo);
            _SoSceneManager.isThereAPizzaOrder = false;
            
        }
        
    }

    private void PlayLosingSequence()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(losingScene);
    }

    private void CountDownTimer()
    {
       minutes = Mathf.FloorToInt(roundTime / 60);
       seconds = Mathf.FloorToInt(roundTime % 60);
       if (roundTime > 0)
       {
           roundTime -= Time.deltaTime;
           if (seconds < 10)
           {
               minutesTimer.text = (minutes + ":" + "0" +seconds);   
           }
           else
           {
               minutesTimer.text = (minutes + ":" + seconds);
           }
       }
       else
       {
           PlayLosingSequence();
       }
    }
    
    public void GeneratePizza(PizzaInfo pizzaInfo)
    {
        // Reset toppings
        pizzaInfo.eyeballTopping = 0;
        pizzaInfo.armTopping = 0;
        pizzaInfo.legTopping = 0;

        int remainingToppings = toppingsAmount;

        while (remainingToppings > 0)
        {
            // Decide which topping to add
            int toppingType = Random.Range(0, 3); // 0: eyeball, 1: arm, 2: leg

            switch (toppingType)
            {
                case 0: // Eyeball Topping
                    if (pizzaInfo.eyeballTopping < eyeBalls)
                    {
                        pizzaInfo.eyeballTopping++;
                        remainingToppings--;
                    }
                    break;
                case 1: // Arm Topping
                    if (pizzaInfo.armTopping < arms)
                    {
                        pizzaInfo.armTopping++;
                        remainingToppings--;
                    }
                    break;
                case 2: // Leg Topping
                    if (pizzaInfo.legTopping < legs)
                    {
                        pizzaInfo.legTopping++;
                        remainingToppings--;
                    }
                    break;
            }

            // Prevent infinite loop if no toppings can be added
            if (!CanAddMoreToppings(pizzaInfo))
            {
                break;
            }
        }

        Debug.Log($"Pizza Generated: Eyeballs={pizzaInfo.eyeballTopping}, Arms={pizzaInfo.armTopping}, Legs={pizzaInfo.legTopping}");
    }

    private bool CanAddMoreToppings(PizzaInfo pizzaInfo)
    {
        return (pizzaInfo.eyeballTopping < eyeBalls) ||
               (pizzaInfo.armTopping < arms) ||
               (pizzaInfo.legTopping < legs);
    }

    void DisplayOrdersLeft()
    {
        ordersLeft.text = ("Orders Left: " + (numPizzasRequired - _SoSceneManager.correctPizzasMade));
    }
}
