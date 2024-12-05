using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPizza : MonoBehaviour
{
    private AudioSource trashAudio;

    private void Awake()
    {
        trashAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            trashAudio.Play();
            Destroy(other.gameObject);
        }
    }
}
