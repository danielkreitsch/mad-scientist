using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace GameJam
{
    public class DeadZombie : MonoBehaviour
    {
        [Inject]
        private Tank tank;
        
        private void OnEnable()
        {
            // Deactivate zombie components
            this.GetComponent<ZombieController>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
            
            // Later: Turn into ragdoll
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<CapsuleCollider>().height *= 0.9f;
            this.GetComponent<CapsuleCollider>().radius *= 0.9f;
            
            // Add biomass
            this.tank.AddBiomass(this.GetComponent<Zombie>().Biomass);
            
            this.StartCoroutine(this.Despawn_Coroutine(3));
        }

        private IEnumerator Despawn_Coroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            GameObject.Destroy(this.gameObject);
        }
    }
}