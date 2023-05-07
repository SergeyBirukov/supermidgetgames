using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private Transform shootPos;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int reflections = 5;
    private int currentReflection = 0;
    private bool atTheEnd;
    private static int connections;

    private void Start()
    {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(currentReflection, shootPos.position);
        
    }

    private void Update()
    {
        if (currentReflection > 1)
            lineRenderer.positionCount = currentReflection;
        currentReflection = 0;
        LaserMagic(shootPos.position, transform.up);
    }
    
    public void LaserMagic(Vector2 startPosition, Vector2 direction)
    {
        var hit = Physics2D.Raycast(startPosition, direction, maxDistance);
        if (currentReflection == lineRenderer.positionCount - 1)
            lineRenderer.positionCount++;
        if (!hit)
        {
            if (atTheEnd)
            {
                atTheEnd = false;
                connections--;
            }
            lineRenderer.SetPosition(currentReflection+1, startPosition + direction*maxDistance);   
            currentReflection++;
        }
        else
        {
            lineRenderer.SetPosition(currentReflection + 1, hit.point);
            currentReflection++;
            var mirror = hit.transform.GetComponent<Mirror>();
            if (mirror)
            {
                if (currentReflection < reflections)
                {
                    LaserMagic(hit.point + hit.normal, Vector2.Reflect(direction, hit.normal).normalized);
                }
            }

            var end = hit.transform.GetComponent<CircleCollider2D>();
            if (end && atTheEnd != true)
            {
                atTheEnd = true;
                connections++;
                if (connections == 2)
                    Debug.Log("cringe");
                if (connections >= 3)
                    Debug.Log("VICTORY");
            }
            else if (atTheEnd)
            {
                atTheEnd = false;
                connections--;
            }
        }
        
    }
    
}
