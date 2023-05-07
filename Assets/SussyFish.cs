using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Interfaces;
using Obstacles;
using TreeEditor;
using UnityEngine;

public class SussyFish : Obstacle, IDamageable
{
    private Player player;
    [SerializeField] private int health = 100;
    public int Health => health;

    [SerializeField] private float moveXStep = 0.01f;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        transform.position += (new Vector3(player.transform.position.x, 0) - new Vector3(transform.position.x, 0)).normalized * moveXStep;
           // Vector3.MoveTowards(transform.position, new Vector2(player.transform.position.x, 0), moveXStep);
           
           _rigidbody2D.velocity = new Vector2(0, -speed);
    }
    

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
