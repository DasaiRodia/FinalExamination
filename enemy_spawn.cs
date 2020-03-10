using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject[] spawnObject; 
    [SerializeField] private float radius;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private bool constantSpawn;
    [SerializeField] private transform spawnPosition;
   
   


    void OnTriggerEnter(Collider ShipMaster) 
    {
        for (spawned = 0; spawned < 3; spawned++)
        {
            Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
        }
    }

    void OnTriggerExit(Collider ShipMaster)
    { 
            CancelInvoke("SpawnEnemy");
    }
    
    void RandomizeSpawnLocation()
    {
        float randLocationX = Random.Range(0, spawnPosition.Length);
        float randLocationZ = Random.Range(0, spawnPosition.Length);
        randomLocation = new Vector3(randLocationX, 0.0f, randLocationZ);
        randomLocation.y = 0.0f;
    }

    void SpawnEnemy()
    { 
      float spawnRadius = radius;
      int spawnObjectIndex = Random.Range(0, spawnObject.Length);
      Invoke("RandomizeSpawnLocation");
      Instantiate(spawnObject[spawnObjectIndex], spawnPosition.position + randomLocation, Quaternion.identity);
      CancelInvoke("RandomizeSpawnLocation");
    }
}
