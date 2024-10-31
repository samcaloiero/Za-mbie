using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayOrder : MonoBehaviour
{
    public TextMeshPro orderText;

    private PizzaInfo _pizzaInfo;
    // Start is called before the first frame update
    void Start()
    {
        _pizzaInfo = GetComponent<PizzaInfo>();
    }

    // Update is called once per frame
    void Update()
    {
       SetOrderText(_pizzaInfo); 
    }
    void SetOrderText(PizzaInfo thisPizzaInfo)
    {
        orderText.text = (thisPizzaInfo.armTopping + " Arm Toppings" + "    " + thisPizzaInfo.eyeballTopping + " Eyeball Toppings" + "    " +
                          thisPizzaInfo.legTopping + " Leg Toppings");
    }
}
