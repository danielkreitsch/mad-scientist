using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieColorAssigner : MonoBehaviour
{
    [SerializeField]
    private Material eyewhite;

    [SerializeField]
    private Material flesh;

    [SerializeField]
    private Material[] skinColors;

    [SerializeField]
    private Material[] coatColors;

    [SerializeField]
    private Material[] shirtColors;

    [SerializeField]
    private Material[] pantsColors;

    [SerializeField]
    private Material[] shoesColors;

    private void Start()
    {
        Material skinColor = this.GetRandomMaterial(this.skinColors);
        Material coatColor = this.GetRandomMaterial(this.coatColors);
        Material shirtColor = this.GetRandomMaterial(this.shirtColors);
        Material pantsColor = this.GetRandomMaterial(this.pantsColors);
        Material shoesColor = this.GetRandomMaterial(this.shoesColors);

        this.GetComponentInChildren<SkinnedMeshRenderer>().materials = new Material[]
        {
            skinColor,
            this.flesh,
            coatColor,
            shirtColor,
            pantsColor,
            shoesColor,
            this.eyewhite,
        };
    }

    private Material GetRandomMaterial(Material[] materials)
    {
        return materials[Random.Range(0, materials.Length)];
    }
}
