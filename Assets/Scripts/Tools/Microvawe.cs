using System;
using System.Collections;
using System.Collections.Generic;
using Obstacles;
using UnityEngine;

public class Microvawe : MonoBehaviour
{
    [SerializeField] private int damage = 34;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private Transform laserFirePoint;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float damageInterval = 0.3f;
    [SerializeField] private GameObject smoke;
    private float damageIntervalLeft;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            lineRenderer.enabled = true;
        if (Input.GetKey(KeyCode.Mouse0))
            Shoot();
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            lineRenderer.enabled = false;
            smoke.SetActive(false);
        }
    }

    private void Shoot()
    {
        var hit = Physics2D.Raycast(laserFirePoint.position, transform.up);
        if (hit)
        {
            Draw2DRay(laserFirePoint.position, hit.point);
            var ice = hit.transform.GetComponent<IceObstacle>();
            if (ice && damageIntervalLeft < 0)
            {
                ice.TakeDamage(damage);
                damageIntervalLeft = damageInterval;
            }
            else
                damageIntervalLeft -= Time.deltaTime;

            if (ice)
            {
                if (!smoke.gameObject.activeSelf)
                {
                    smoke.gameObject.SetActive(true);
                }

                smoke.transform.position = hit.point;
            }
            else
            {
                smoke.gameObject.SetActive(false);
            }
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.up * maxDistance);
            smoke.SetActive(false);
        }
    }
    

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
