using System;
using System.Collections;
using System.Collections.Generic;
using Development.Debugging;
using GameJam;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Zenject;
using Random = UnityEngine.Random;

public class Scientist : MonoBehaviour
{
    [Inject]
    private DebugScreen debugScreen;

    [Inject]
    private GameController gameController;

    [Inject]
    private CameraController cameraController;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject healthBarObject;

    [SerializeField]
    private Image healthBarFillImage;

    [SerializeField]
    private float maxHealth = 10;

    [SerializeField]
    private int maxAmmo = 100;

    [SerializeField]
    private float ammoReloadTime;

    [Header("Shooting")]
    [SerializeField]
    private Transform rotatingTransform;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    private LayerMask bulletBlockingLayers;

    [SerializeField]
    private float shootCooldown = 0.2f;

    [SerializeField]
    private AudioClip shootSound;

    [SerializeField]
    private AudioClip noAmmoSound;

    [SerializeField]
    private AudioClip reloadWeaponSound;

    private AudioSource audioSource;

    private float health = 0;
    private int ammo = 0;

    private float shootTimer = 0;
    private float noAmmoSoundTimer = 0;

    public float Health
    {
        get => this.health;
        set
        {
            this.health = value;
            if (!this.healthBarObject.activeInHierarchy)
            {
                this.healthBarObject.SetActive(true);
            }
        }
    }

    public bool IsAlive => health > 0;

    public Scientist ProtectTarget { get; set; }

    public Zombie AttackTarget { get; set; }

    public float AimingAngle { get; set; }

    public Animator Animator => this.animator;

    private void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();

        this.health = this.maxHealth;
        this.ammo = this.maxAmmo;
    }

    private void OnEnable()
    {
        this.Invoke(() => { this.gameController.Scientists.Add(this); }, 0.1f);
    }

    private void OnDisable()
    {
        this.gameController.Scientists.Remove(this);
    }

    private void Update()
    {
        this.shootTimer += Time.deltaTime;
        this.noAmmoSoundTimer += Time.deltaTime;

        this.healthBarFillImage.fillAmount = this.health / this.maxHealth;

        this.animator.SetFloat("AimAngle", MathUtilty.WrapAngle(this.AimingAngle - this.rotatingTransform.eulerAngles.y, -180, 180));
    }

    public void Shoot()
    {
        if (this.shootTimer >= this.shootCooldown)
        {
            this.shootTimer = 0;

            if (this.ammo <= 0)
            {
                if (this.noAmmoSoundTimer > 5)
                {
                    this.noAmmoSoundTimer = 0;
                    this.StartCoroutine(this.ReloadWeapon_Coroutine());
                }
                return;
            }

            GameObject bulletObj = GameObject.Instantiate(this.bulletPrefab, this.bulletSpawn.position, Quaternion.Euler(0, this.AimingAngle + Random.Range(-6f, 6f), 0));
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.Shooter = this;

            this.ammo--;

            this.audioSource.PlayOneShot(this.shootSound);
        }
    }

    public void ShootAt(Vector3 targetPosition)
    {
        if (this.shootTimer >= this.shootCooldown)
        {
            if (!Physics.Raycast(this.transform.position, (this.AttackTarget.transform.position - this.transform.position).normalized, Vector3.Distance(this.transform.position, this.AttackTarget.transform.position), this.bulletBlockingLayers))
            {
                this.AimingAngle = Vector3.SignedAngle(Vector3.forward, new Vector3(targetPosition.x, this.transform.position.y, targetPosition.z) - this.transform.position, Vector3.up);
                //this.rotatingTransform.LookAt(targetPosition);
                this.Shoot();
            }
        }
    }

    private IEnumerator ReloadWeapon_Coroutine()
    {
        this.audioSource.PlayOneShot(this.noAmmoSound);
        yield return new WaitForSeconds(1);
        this.audioSource.PlayOneShot(this.reloadWeaponSound);
        yield return new WaitForSeconds(1);
        this.ammo = this.maxAmmo;
    }

    public void ReceiveDamageByAttack(float damage)
    {
        this.health -= damage;

        if (this.health > 0)
        {
            if (!this.healthBarObject.activeInHierarchy)
            {
                this.healthBarObject.SetActive(true);
            }
        }
        else
        {
            this.GetComponent<DeadScientist>().enabled = true;
            this.healthBarObject.SetActive(false);
            this.GetComponentInChildren<Animator>().enabled = false;
        }
    }
}