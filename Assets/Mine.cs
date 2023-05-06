using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private float force;
    private bool shot;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private float forceCoef = 0.1f;
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
}
