using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool collisionTriggered = false;

    private void Update()
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * speed;
        
        // Effekt ausprobiert
        //this.transform.localScale = new Vector3(this.transform.localScale.x - 0.5f * Time.deltaTime, this.transform.localScale.y, this.transform.localScale.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!this.collisionTriggered)
        {
            this.collisionTriggered = true;

            if (other.gameObject.GetComponent<Zombie>())
            {
                Zombie zombie = other.gameObject.GetComponent<Zombie>();
                zombie.ReceiveShootDamage(1, this.transform.forward);
            }

            GameObject.Destroy(this.gameObject);
        }
    }
}
