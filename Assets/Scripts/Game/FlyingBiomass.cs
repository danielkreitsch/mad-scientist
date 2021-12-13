using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class FlyingBiomass : MonoBehaviour
{
    [Inject]
    private Tank tank;

    private NavMeshAgent navAgent;
    
    public float Amount { get; set; }
    
    void Start()
    {
        this.navAgent = this.GetComponent<NavMeshAgent>();
        navAgent.SetDestination(this.tank.transform.position);
    }
    
    void Update()
    {
        if (this.navAgent.remainingDistance < 0.1f)
        {
            // Add biomass
            this.tank.AddBiomass(this.Amount);
            
            GameObject.Destroy(this.gameObject);
        }
    }
}
