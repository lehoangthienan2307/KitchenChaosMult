using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlatesSpawned;
    public event EventHandler OnPlatesRemoved;
    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    private float spawnPlateTimer;
    private float spawnPlateMax = 4f;
    private int platesSpawnAmount;
    private int platesSpawnAmountMax = 4;
    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateMax)
        {
            spawnPlateTimer = 0f;

            if (platesSpawnAmount < platesSpawnAmountMax && KitchenGameManager.Instance.IsGamePlaying())
            {
                platesSpawnAmount++;

                OnPlatesSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            if (platesSpawnAmount > 0)
            {
                spawnPlateTimer = 0f;
                platesSpawnAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlatesRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
