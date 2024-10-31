using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateItem : MonoBehaviour
{
    public GameObject itemToSpawn;
    public void SpawnItem()
    {
        Debug.Log("Spawn Item");
        //Fix Spawn in Scaling
        Instantiate(itemToSpawn, transform);
    }
}
