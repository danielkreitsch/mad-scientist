using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private bool attackUsed = false;
    
    private void OnEnable()
    {
        this.attackUsed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.attackUsed)
        {
            return;
        }
        
        var scientist = other.GetComponent<Scientist>();
        if (scientist != null)
        {
            scientist.ReceiveDamageByAttack(1);
            this.attackUsed = true;
        }
    }
}
