using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] private int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyIce();
        }
    }

    private void DestroyIce()
    {
        Destroy(gameObject);
    }
}
