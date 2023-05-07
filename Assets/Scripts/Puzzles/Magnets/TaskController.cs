using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    private GameObject _uranium;

    private GameObject _goal;

    public Sprite winCellSprite;
    // Start is called before the first frame update
    void Start()
    {
        _uranium = GameObject.FindGameObjectWithTag("Player");
        _goal = GameObject.FindGameObjectWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(_uranium.transform.position.x - _goal.transform.position.x) > 0.1f ||
            Math.Abs(_uranium.transform.position.y - _goal.transform.position.y) > 0.1f) return;
        var goalSprite = _goal.GetComponent<SpriteRenderer>();
        goalSprite.sprite = winCellSprite;
    }
}
