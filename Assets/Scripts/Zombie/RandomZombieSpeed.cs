using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomZombieSpeed : MonoBehaviour
{
    private Animator thisAnimator;

    public float minSpeed = .25f;

    public float maxSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (thisAnimator == null)
        {
            thisAnimator = GetComponent<Animator>();
        }
        if (thisAnimator != null)
        {thisAnimator.speed = Random.Range(minSpeed, maxSpeed);}
        else
        {
            Debug.Log("No Zombie Animator!");
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
