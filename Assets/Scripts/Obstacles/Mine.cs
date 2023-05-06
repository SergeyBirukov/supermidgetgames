using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Interfaces;
using Obstacles;
using Unity.VisualScripting;
using UnityEngine;

public class Mine : Obstacle
{
    private float force;
    private bool shot;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private float forceCoef = 0.01f;
    [SerializeField] private int damage = 100;
    private void Update()
    {
        if (shot)
            Fly();
    }

    public void Shoot(float force)
    {
        shot = true;
        this.force = force * forceCoef;
    }

    private void Fly()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.up * maxDistance, force);
    }

    public override void SpecialInteraction(Collider2D col)
    {
        col.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
        Destroy(gameObject);
    }
}
