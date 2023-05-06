﻿using System.Collections;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleSpawner: MonoBehaviour
    {
        [SerializeField] private SpawnArea spawnArea;
        [SerializeField] private Obstacle dummyObstaclePrefab;
        [SerializeField] private float spawnDelayInSeconds;

        private void Spawn(Obstacle obstacle)
        {
            Instantiate(obstacle, spawnArea.GetRandomPosition(), Quaternion.identity);
        }

        private void Start()
        {
            GetComponentInChildren<SpawnArea>();
            StartCoroutine(SpawnCoroutine());
        }


        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnDelayInSeconds);
                Spawn(dummyObstaclePrefab);
            }
        }
    }
}