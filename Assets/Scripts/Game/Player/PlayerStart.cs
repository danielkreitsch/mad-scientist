using System.Collections;
using System.Collections.Generic;
using GameJam;
using UnityEngine;
using Utility;
using Zenject;

public class PlayerStart : MonoBehaviour
{
    [Inject]
    private GameController gameController;
    
    void Start()
    {
        this.Invoke(() =>
        {
            GameObject.Instantiate(this.gameController.PlayerPrefab, this.transform.position, this.transform.rotation);
        }, 0.05f);
    }
}