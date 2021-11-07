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

        [SerializeField]
        private GameObject biomassPrefab;
        
        private void OnEnable()
        {
            // Deactivate zombie components
            this.GetComponent<ZombieController>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
            
            // Change layer
            this.gameObject.layer = LayerMask.NameToLayer("DeadBody");
                            
            // Later: Turn into ragdoll
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<CapsuleCollider>().height *= 0.9f;
            this.GetComponent<CapsuleCollider>().radius *= 0.9f;

            this.StartCoroutine(this.Despawn_Coroutine());
        }

        private IEnumerator Despawn_Coroutine()
        {
            yield return new WaitForSeconds(1.5f);

            if (!this.tank.IsFull)
            {
                GameObject biomassObj = GameObject.Instantiate(this.biomassPrefab, this.transform.position, Quaternion.identity);
                biomassObj.GetComponent<FlyingBiomass>().Amount = this.GetComponent<Zombie>().Biomass;
            }

            yield return new WaitForSeconds(5f);
            GameObject.Destroy(this.gameObject);
        }
    }
}