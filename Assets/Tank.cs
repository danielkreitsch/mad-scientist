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
    private float maxWaterHeight = 2;

    [SerializeField]
    private float waterHeightInterpolationTime = 1;

    [SerializeField]
    private Transform cloneSpawn;

    [SerializeField]
    private GameObject clonePrefab;

    [SerializeField]
    private float requiredBiomassForClone = 10;

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
                Debug.Log("A new clone is waiting (Voice?)");
            }
        }
        else
        {
            Debug.Log("You should go to the tank (Voice?)");
        }
    }

    public void OnInteract()
    {
        if (this.Biomass >= this.requiredBiomassForClone)
        {
            this.SpawnClone();
        }
        else
        {
            Debug.Log("Not enough biomass (*Sound*)");
        }
    }

    private void SpawnClone()
    {
        this.Biomass = 0;
        GameObject.Instantiate(this.clonePrefab, this.cloneSpawn.position, Quaternion.Euler(new Vector3(0, 180, 0)));
        Debug.Log("Opening door (*Sound*)");
    }
}