using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Wave[] waves; // wave array
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float initialSpawnRate = 1f;

    private int currentWave = 0;
    private float spawnRate;

    private void Start()
    {
        spawnRate = initialSpawnRate;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while (currentWave < waves.Length)
        {
            Wave wave = waves[currentWave];

            for (int i = 0; i < wave.enemyCount; i++)
            {
                Instantiate(wave.enemyPrefab, spawnPos.position, Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }

            currentWave++;
            yield return new WaitForSeconds(timeBetweenWaves); // cooldown
        }
    }
}