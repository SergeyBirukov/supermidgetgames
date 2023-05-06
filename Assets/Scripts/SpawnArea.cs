using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] private Transform top;
    [SerializeField] private Transform bottom;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private GameObject spawnPoint;

    public Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(left.position.x, right.position.x),
            Random.Range(bottom.position.y, top.position.y));
    }
}
