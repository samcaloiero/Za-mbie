using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGroupSpawn : MonoBehaviour
{
    public GameObject clapHandGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("ClapHand").Length <= 0)
        {
            Instantiate(clapHandGroup);
            this.gameObject.SetActive(false);
        }
    }

    void SpawnHands()
    {
        
    }
    
}
