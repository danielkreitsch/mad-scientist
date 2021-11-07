using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Character;
using GameJam;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class DeadScientist : MonoBehaviour
{
    [Inject]
    private GameController gameController;

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

        // Change layer
        this.gameObject.layer = LayerMask.NameToLayer("DeadBody");

        // Later: Turn into ragdoll
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<CapsuleCollider>().height *= 0.9f;
        this.GetComponent<CapsuleCollider>().radius *= 0.9f;

        this.StartCoroutine(this.Despawn_Coroutine(3));
    }

    private IEnumerator Despawn_Coroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (this.GetComponent<PlayerController>() != null)
        {
            var otherScientist = this.gameController.Scientists.FindAll(s => s != this.GetComponent<Scientist>() && s.IsAlive).FirstOrDefault();
            if (otherScientist != null)
            {
                var newPlayerObj = GameObject.Instantiate(this.gameController.PlayerPrefab, otherScientist.transform.position, Quaternion.identity);
                newPlayerObj.GetComponent<Scientist>().Health = otherScientist.Health;
                GameObject.Destroy(otherScientist.gameObject);
            }

            GameObject.Destroy(this.gameObject);
        }
        else if (this.GetComponent<CloneController>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}