using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using Range = UnityEngine.SocialPlatforms.Range;

public class HandSpawner : MonoBehaviour
{
    public SOSceneManager _SoSceneManager;

    [FormerlySerializedAs("highFiveHand")] public GameObject highFiveController;
    public float spawnInterval = 2.0f;
    private bool isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_SoSceneManager.pizzaBaking && !isSpawning)
        {
            StartCoroutine(SpawnHands());
        }
        
    }
    private IEnumerator SpawnHands()
    {
        isSpawning = true;
        while (_SoSceneManager.pizzaBaking)
        {
            Vector3 randomSpawnPosition =
                new Vector3(Random.Range(-2f, 2f), Random.Range(0f, 2f), Random.Range(-2f, 2f));
            Instantiate(highFiveController, randomSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;

    }
}


