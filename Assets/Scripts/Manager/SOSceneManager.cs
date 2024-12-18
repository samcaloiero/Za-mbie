using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SOSceneManager", menuName = "ScriptableObjects/SOSceneManager")]
public class SOSceneManager : ScriptableObject
{
    [Tooltip("This should always start at 0")]
    public int correctPizzasMade;

    public bool leftHand;

    public bool rightHand;

    public bool isThereAPizzaOrder;

    public bool grabbingToppings;

    public bool pizzaBaking;

}
