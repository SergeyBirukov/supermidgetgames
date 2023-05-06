using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private Transform shootPos;
    [SerializeField] private LineRenderer lineRenderer;
    // private int index;
    [SerializeField] private int reflections = 5;
    private int currentReflection = 0;

    private void Start()
    {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(currentReflection, shootPos.position);
        LaserMagic(shootPos.position, transform.up);
    }

    private void Update()
    {
        
    }
    
    public void LaserMagic(Vector2 startPosition, Vector2 direction)
    {
        var hit = Physics2D.Raycast(startPosition, direction, maxDistance);
        lineRenderer.positionCount++;
        if (!hit)
        { 
         lineRenderer.SetPosition(currentReflection+1, direction*maxDistance);   
         currentReflection++;
        }
        else
        {
            lineRenderer.SetPosition(currentReflection + 1, hit.point);
            currentReflection++;
            if (currentReflection < reflections)
            {
                LaserMagic(hit.point + hit.normal, Vector2.Reflect(direction, hit.normal).normalized);
            }
        }
    }

    // private void LaserWork(Vector2 startPos, Vector2 direction)
    // {
    //     var hit = Physics2D.Raycast(startPos, direction);
    //     if (hit)
    //     {
    //         Draw2DRay(startPos, hit.point);
    //         LaserWork(hit.point, hit.transform.up);
    //     }
    //     else
    //         Draw2DRay(startPos, direction * maxDistance);
    // }


    // private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    // {
    //     lineRenderer.SetPosition(index, startPos);
    //     index++;
    //     lineRenderer.SetPosition(index, endPos);
    // }
}
