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
    
    private float minutes;
    private float seconds;

    [Header("Left and Right VR Hands")]
    public GameObject leftHand;

    public GameObject rightHand;
   
    // Start is called before the first frame update
    void Start()
    {
        _SoSceneManager.isThereAPizzaOrder = true;
        
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
        //change round if user makes enough pizzas
        if (numPizzasRequired == _SoSceneManager.correctPizzasMade)
        {
            Debug.Log("Advance to Next Round");
            //Putting UnityEngine here bc of the name of your script
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneToAdvTo);
        }
        //Count Down Timer
        //Make player lose if run out of time
        CountDownTimer();
        if (roundTime < 0)
        {
            PlayLosingSequence();
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
}
