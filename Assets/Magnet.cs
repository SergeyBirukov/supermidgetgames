using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private Transform minePosition;
    private bool ReadyToShoot;
    [SerializeField] private float mineMoveDelta = 0.1f;
    [SerializeField] private float maxForce = 5f;
    private Mine mine;
    private Vector3 mineStartPosition;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            GrabMine();
        if (Input.GetKey(KeyCode.Mouse1))
            GrabMine();
        if (Input.GetKeyUp(KeyCode.Mouse1))
            ShootMine();
    }

    private void GrabMine()
    {
        if (!mine)
        {
            var hit = Physics2D.Raycast(transform.position, transform.up);
            if (hit)
                mine = hit.transform.GetComponent<Mine>();
            if (mine)
                mineStartPosition = mine.transform.position;
        }
        else
        {
            mine.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            var direction = mine.transform.position - minePosition.position;
            var distance = direction.magnitude;
            if (distance < 0.1)
                ReadyToShoot = true;
            if (distance > 0.1)
                mine.transform.position =
                    Vector2.MoveTowards(mine.transform.position, minePosition.position, mineMoveDelta);
        }
    }

    private void ShootMine()
    {
        var force = ((mineStartPosition - mine.transform.position).magnitude / (mineStartPosition-minePosition.position).magnitude) * maxForce;
        mine.Shoot(force);
        ReadyToShoot = false;
        mine = null;
    }
}
