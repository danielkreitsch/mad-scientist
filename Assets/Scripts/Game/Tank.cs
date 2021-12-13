using System;
using System.Collections;
using System.Collections.Generic;
using Development.Debugging;
using UnityEngine;
using Zenject;

public class Tank : MonoBehaviour
{
    [Inject]
    private DebugScreen debugScreen;

    [SerializeField]
    private Transform waterTransform;
    
    [SerializeField]
    private Transform brightWaterTransform;
    
    [SerializeField]
    private float maxWaterHeight = 2;

    [SerializeField]
    private float waterHeightInterpolationTime = 1;

    [SerializeField]
    private Transform cloneSpawn;

    [SerializeField]
    private GameObject clonePrefab;

    [SerializeField]
    private float requiredBiomassForClone = 10;

    [Header("Sounds")]
    [SerializeField]
    private AudioClip cloneSequenceSound;
    
    [SerializeField]
    private AudioClip openDoorSound;
    
    [SerializeField]
    private AudioClip closeDoorSound;

    [SerializeField]
    private AudioClip notEnoughBiomassSound;

    private float _biomass = 0;
    
    private float targetWaterY = 0;
    private Vector3 waterVelocity;

    public float Biomass
    {
        get => this._biomass;
        private set
        {
            this._biomass = value; 
            this.targetWaterY = this._biomass / this.requiredBiomassForClone * this.maxWaterHeight;
        }
    }

    public float RequiredBiomassForClone => this.requiredBiomassForClone;
    
    public bool IsFull => this.Biomass >= this.RequiredBiomassForClone;

    private void Update()
    {
        this.waterTransform.localPosition = Vector3.SmoothDamp(this.waterTransform.localPosition, new Vector3(0, this.targetWaterY, 0), ref this.waterVelocity, this.waterHeightInterpolationTime);
    
        this.debugScreen.Set("Tank", "Biomass", this.Biomass + "/" + this.requiredBiomassForClone);
    }

    public void AddBiomass(float biomass)
    {
        if (this.Biomass < this.requiredBiomassForClone)
        {
            this.Biomass += biomass;

            if (this.Biomass >= this.requiredBiomassForClone)
            {
                this.Biomass = this.requiredBiomassForClone;
                this.brightWaterTransform.gameObject.SetActive(true);
                Debug.Log("A new clone is waiting");
            }
        }
        else
        {
            Debug.Log("You should go to the tank");
        }
    }

    public void OnInteract()
    {
        if (this.Biomass >= this.requiredBiomassForClone)
        {
            this.Biomass = 0;
            this.StartCoroutine(this.SpawnClone_Coroutine());
        }
        else
        {
            this.GetComponent<AudioSource>().PlayOneShot(this.notEnoughBiomassSound);
        }
    }
    
    

    private IEnumerator SpawnClone_Coroutine()
    {
        var audioSource = this.GetComponent<AudioSource>();
        
        this.brightWaterTransform.gameObject.SetActive(false);

        audioSource.PlayOneShot(this.cloneSequenceSound);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(this.openDoorSound);
        yield return new WaitForSeconds(1f);
        GameObject.Instantiate(this.clonePrefab, this.cloneSpawn.position, Quaternion.Euler(new Vector3(0, 180, 0)));
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(this.closeDoorSound);
    }
}