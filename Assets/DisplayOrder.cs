using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DisplayOrder : MonoBehaviour
{
    public TextMeshPro orderText;

    [FormerlySerializedAs("_pizzaInfo")] public PizzaInfo orderPizzaInfo;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       SetOrderText(orderPizzaInfo); 
    }
    void SetOrderText(PizzaInfo thisPizzaInfo)
    {
        if (thisPizzaInfo != false)
        {
            orderText.text = (thisPizzaInfo.armTopping + " Arm Toppings\n" + thisPizzaInfo.eyeballTopping + " Eyeball Toppings\n" +
                              thisPizzaInfo.legTopping + " Leg Toppings\n");
        }
        
    }
}
