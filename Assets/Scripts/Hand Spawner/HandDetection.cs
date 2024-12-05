using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDetection : MonoBehaviour
{
    public BakingTimer _bakingTimer;
    public int timeReduction = 2;
    public GameObject clapFX;
    private void Awake()
    {
        _bakingTimer = FindObjectOfType<BakingTimer>();
        if (_bakingTimer == null)
        {
            Debug.LogError("BakingTimer not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
        {
            Debug.Log("Hands Collide!");
            if (_bakingTimer != null)
            {
                StartCoroutine(ChangeTextColorTemporarily(Color.green, .1f));
                _bakingTimer.DecreaseCurrentTime(timeReduction);
            }

            clapFX.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator ChangeTextColorTemporarily(Color color, float duration)
    {
        Color originalColor = _bakingTimer.timerText.color;

        _bakingTimer.timerText.color = color;

        yield return new WaitForSeconds(duration);

        _bakingTimer.timerText.color = originalColor;

    }
    private void ChangeTimes()
    {
        //decrease pizza wait time
        
    }
}
