using System;
using System.Collections;
using System.Collections.Generic;
using GameJam;
using UnityEngine;
using Zenject;

public class Zombie : MonoBehaviour
{
    [Inject]
    private GameController gameController;
    
    [SerializeField]
    private float startHealth = 10;

    [SerializeField]
    private float torqueByBulletFactor = 1;

    private float health = 0;

    public bool IsAlive => this.health > 0;
    
    public Scientist Target { get; set; }

    private void Start()
    {
        this.health = this.startHealth;
    }
    
    private void OnEnable()
    {
        this.gameController.Zombies.Add(this);
    }

    private void OnDisable()
    {
        this.gameController.Zombies.Remove(this);
    }

    public void ReceiveShootDamage(float damage, Vector3 direction)
    {
        this.health -= damage;
        if (this.IsAlive)
        {
            this.StartCoroutine(this.Blink_Coroutine(0.05f));
        }
        else
        {
            this.GetComponent<DeadZombie>().enabled = true;
            this.GetComponent<Rigidbody>().AddTorque(direction * torqueByBulletFactor);
        }
    }

    private IEnumerator Blink_Coroutine(float time)
    {
        this.SetVisible(false);
        yield return new WaitForSeconds(time);
        this.SetVisible(true);
    }

    private void SetVisible(bool visible)
    {
        foreach (Renderer renderer in this.GetComponentsInChildren<Renderer>())
        {
            if (visible)
            {
                renderer.transform.localScale = renderer.transform.localScale * 1.15f;
            }
            else
            {
                renderer.transform.localScale = renderer.transform.localScale / 1.15f;
            }
            //renderer.enabled = visible;
        }
    }
}