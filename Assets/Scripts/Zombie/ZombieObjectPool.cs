using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieObjectPool : MonoBehaviour
{
    public SOSceneManager _SoSceneManager;
    public GameObject [] zombie;
    public SceneManager _SceneManager;

    private int lastCorrectPizzasMade = 0;
    void Start()
    {
        //setting all zombies false
        for (int i = 0; i < zombie.Length; i++)
        {
            zombie[i].SetActive(false);
        }
        //Setting number of zombies active for the number of pizzas required
        for (int i = 0; i < _SceneManager.numPizzasRequired; i++)
        {
            zombie[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_SoSceneManager.correctPizzasMade > lastCorrectPizzasMade)
        {
            DeactivateRandomActiveZombie();
            lastCorrectPizzasMade = _SoSceneManager.correctPizzasMade;
        }
    }

    public void DeactivateRandomActiveZombie()
    {
        List<GameObject> activeZombies = new List<GameObject>();
        foreach (GameObject z in zombie)
        {
            if (z.activeSelf)
            {
                activeZombies.Add(z);
            }
        }

        if (activeZombies.Count > 0)
        {
            int randomIndex = Random.Range(0, activeZombies.Count);
            activeZombies[randomIndex].SetActive(false);
        }
    }
}
