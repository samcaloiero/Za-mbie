using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneManager : MonoBehaviour
{   
    //Attach this script to the hat
    
    //Attach next level scene name here
    public string nextLevel;
    public SOSceneManager _SoSceneManager;
    // Start is called before the first frame update
    void Start()
    {
        _SoSceneManager.leftHand = true;
        _SoSceneManager.rightHand = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand"))
        {
            _SoSceneManager.rightHand = false;
        }
        else if (other.gameObject.CompareTag("rightHand"))
        {
            _SoSceneManager.leftHand = false;
        }

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextLevel);
    }
}
