using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private Transform minePosition;
    [SerializeField] private GameObject magnetEffect;
    private bool ReadyToShoot;
    [SerializeField] private float mineMoveDelta = 0.1f;
    [SerializeField] private float maxForce = 5f;
    private Mine mine;
    private Vector3 mineStartPosition;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
            GrabMine();
        if (Input.GetKeyUp(KeyCode.Mouse1))
            ShootMine();
    }

    private void GrabMine()
    {
        magnetEffect.SetActive(true);
        Debug.Log("grab mine");
        if (!mine)
        {
            Debug.Log("!mine");
            var hit = Physics2D.Raycast(minePosition.position, transform.up);
            Debug.DrawRay(transform.position, transform.up);
            if (hit)
                mine = hit.transform.GetComponent<Mine>();
            if (mine)
            {
                Debug.Log("mine found");
                mineStartPosition = mine.transform.position;
            }
        }
        else
        {
            Debug.Log("mine");
            mine.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            var direction = mine.transform.position - minePosition.position;
            var distance = direction.magnitude;
            Debug.Log(distance);
            if (distance < 0.1)
                ReadyToShoot = true;
            if (distance > 0.1)
                mine.transform.position =
                    Vector2.MoveTowards(mine.transform.position, minePosition.position, mineMoveDelta);
        }
    }

    private void ShootMine()
    {
        magnetEffect.SetActive(false);
        if (mine is null)
        {
            return;
        }
        var force = ((mineStartPosition - mine.transform.position).magnitude / (mineStartPosition-minePosition.position).magnitude) * maxForce;
        mine.Shoot(force);
        ReadyToShoot = false;
        mine = null;
    }
}
