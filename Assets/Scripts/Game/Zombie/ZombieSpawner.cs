using System.Collections;
using System.Collections.Generic;
using GameJam;
using UnityEngine;
using Zenject;

public class ZombieSpawner : MonoBehaviour
{
    [Inject]
    private GameController gameController;
    
    [SerializeField]
    private GameObject zombiePrefab;
    
    [SerializeField]
    private AnimationCurve spawnCooldownByTime;
    
    private float spawnTimer = 100;
    
    void Update()
    {
        this.spawnTimer += Time.deltaTime;

        if (this.spawnTimer > this.spawnCooldownByTime.Evaluate(this.gameController.Time / 60))
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
