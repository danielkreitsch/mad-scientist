using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;
    
    [SerializeField]
    private float spawnCooldown = 5;
    
    private float spawnTimer = 100;
    
    void Update()
    {
        this.spawnTimer += Time.deltaTime;

        if (this.spawnTimer > this.spawnCooldown)
        {
            this.spawnTimer = 0;
            this.SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        GameObject.Instantiate(this.zombiePrefab, this.transform.position, Quaternion.identity);
    }
}
