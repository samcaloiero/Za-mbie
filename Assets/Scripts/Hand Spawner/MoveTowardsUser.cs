using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveTowardsUser : MonoBehaviour
{
    [SerializeField] private Camera player;
    [SerializeField]private float speed = .2f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Camera>();
        if (player == null)
        {
            Debug.LogError("No GameObject named 'Center Attract' was found in the scene!");
        }

        speed = Random.Range(.2f, .6f);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed *Time.deltaTime);
        transform.forward = player.transform.position - transform.position;
    }

    
}
