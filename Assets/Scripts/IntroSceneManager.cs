using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneManager : MonoBehaviour
{   
    
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
    }
}
