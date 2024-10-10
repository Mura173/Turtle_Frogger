using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGarbage : MonoBehaviour
{
    public float spawnDelay = 0.85f;

    public GameObject garbage;

    private float NextTimeToSpawn;

    void Update()
    {
        // Tempo inicial do jogo
        if (NextTimeToSpawn <= Time.time)
        {
            SpawnCar();

            NextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnCar()
    {
        Instantiate(garbage, transform.position, transform.rotation);

    }
}
