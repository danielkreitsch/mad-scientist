using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GameJam
{
    public class DeadZombie : MonoBehaviour
    {
        private void OnEnable()
        {
            this.GetComponent<ZombieController>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<CapsuleCollider>().height *= 0.9f;
            this.GetComponent<CapsuleCollider>().radius *= 0.9f;
            this.StartCoroutine(this.Despawn_Coroutine(3));
        }

        private IEnumerator Despawn_Coroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            GameObject.Destroy(this.gameObject);
        }
    }
}