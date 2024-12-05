using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject xrRig;
    // Start is called before the first frame update
    void Start()
    {
        if (xrRig == null)
        {
            Debug.LogError("XR Rig not assigned. Please assign the XR Rig in the Inspector.");
            return;
        }

        // Move the XR Rig to this GameObject's position
        xrRig.transform.position = transform.position;
        xrRig.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
