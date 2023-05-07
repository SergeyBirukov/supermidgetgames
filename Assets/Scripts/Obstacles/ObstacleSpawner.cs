using System.Collections;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleSpawner: MonoBehaviour
    {
        [SerializeField] private SpawnArea spawnArea;
        [SerializeField] private Obstacle dummyObstaclePrefab;
        [SerializeField] private float spawnDelayInSeconds;
        [SerializeField] private Sprite glebShark;

        private void Spawn(Obstacle obstacle)
        {
            var inst = Instantiate(obstacle, spawnArea.GetRandomPosition(), Quaternion.identity);
            if (GlebMode.Instance.IsGlebMode && (inst.GetComponent<FishLeft>() || inst.GetComponent<FishRight>()))
            {
                foreach (Transform tr in inst.transform)
                {
                    tr.GetComponent<SpriteRenderer>().sprite = glebShark;
                }
            }
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