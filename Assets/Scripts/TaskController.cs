using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    [SerializeField] private Image screenCover;
    private bool finished;
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
        if(finished) return;
        finished = true;
        goalSprite.sprite = winCellSprite;
        StartCoroutine(HideScreen());
    }
    
    private IEnumerator HideScreen()
    {
        for (var i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.5f);
            var tmp = screenCover.color;
            tmp.a += 0.2f;
            screenCover.color = tmp;
        }

        SceneManager.LoadScene(nextLevelName);
    }
}
