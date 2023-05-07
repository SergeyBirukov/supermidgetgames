using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismPlus : MonoBehaviour
{
    [SerializeField] private Transform prismDirection;
    private bool isUpdated;
    [SerializeField] private LineRenderer lineRenderer;
    private List<Color> lasers = new List<Color>();

    private void Update()
    {
        if (lasers.Count == 0)
            lineRenderer.enabled = false; 
        if (lasers.Count > 0 && !isUpdated)
        {
            Debug.Log("Here");
            lineRenderer.enabled = true;
            var color = CalculateColor();
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
            isUpdated = true;
        }
    }
    

    private Color CalculateColor()
    {
        return Color.white;
    }

    public void AddLaser(LineRenderer laser)
    {
        lasers.Add(laser.endColor);
        isUpdated = false;
    }

    public void DeleteLaser(LineRenderer laser)
    {
        lasers.Remove(laser.endColor);
        isUpdated = false;
    }
}
