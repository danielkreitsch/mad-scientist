using System;
using System.Collections;
using System.Collections.Generic;
using GameJam;
using UnityEngine;
using Zenject;

public class Scientist : MonoBehaviour
{
    [Inject]
    private GameController gameController;
    
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float startHealth = 10;

    [Header("Shooting")]
    [SerializeField]
    private GameObject bulletPrefab;
    
    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    private LayerMask bulletBlockingLayers;

    [SerializeField]
    private float shootCooldown = 0.2f;

    private float health = 0;
    
    private float shootTimer;
    
    public bool IsAlive => health > 0;
    
    public Scientist ProtectTarget { get; set; }

    public Zombie AttackTarget { get; set; }

    private void Start()
    {
        this.health = this.startHealth;
    }

    private void OnEnable()
    {
        this.gameController.Scientists.Add(this);
    }

    private void OnDisable()
    {
        this.gameController.Scientists.Remove(this);
    }

    private void Update()
    {
        this.shootTimer += Time.deltaTime;
    }

    public void Shoot()
    {
        if (this.shootTimer >= this.shootCooldown)
        {
            GameObject bulletObj = GameObject.Instantiate(this.bulletPrefab, this.bulletSpawn.position, this.transform.rotation);
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            
            this.shootTimer = 0;
        }
    }

    public void ShootAt(Vector3 targetPosition)
    {
        if (this.shootTimer >= this.shootCooldown)
        {
            if (!Physics.Raycast(this.transform.position, (this.AttackTarget.transform.position - this.transform.position).normalized, Vector3.Distance(this.transform.position, this.AttackTarget.transform.position), this.bulletBlockingLayers))
            {
                this.transform.LookAt(targetPosition);
                this.Shoot();
            }
        }
    }
}
