using System.Collections;
using System.Collections.Generic;
using Game.Character;
using GameJam;
using UnityEngine;
using UnityEngine.AI;

public class DeadScientist : MonoBehaviour
{
    private void OnEnable()
    {
        // Deactivate zombie components
        if (this.GetComponent<PlayerController>() != null)
        {
            this.GetComponent<PlayerController>().enabled = false;
        }
        else if (this.GetComponent<CloneController>() != null)
        {
            this.GetComponent<CloneController>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
        }
        
        // Later: Turn into ragdoll
        /*this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<CapsuleCollider>().height *= 0.9f;
        this.GetComponent<CapsuleCollider>().radius *= 0.9f;*/

        this.StartCoroutine(this.Despawn_Coroutine(3));
    }

    private IEnumerator Despawn_Coroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (this.GetComponent<PlayerController>() != null)
        {
            this.GetComponent<PlayerController>().enabled = true;
            GameObject.Destroy(this.GetComponent<Scientist>());
            this.gameObject.AddComponent<Scientist>();
        }
        else if (this.GetComponent<CloneController>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
