using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTimer: MonoBehaviour
{
    [SerializeField] private float levelTimeInSeconds = 30;
    [SerializeField] private string nextLevelName;
    [SerializeField] private Image screenCover;

    private void Start()
    {
        StartCoroutine(LevelEndCountdown());
        StartCoroutine(ShowScreen());
    }

    private IEnumerator LevelEndCountdown()
    {
        yield return new WaitForSeconds(levelTimeInSeconds);
        StartCoroutine(HideScreen());
        yield return new WaitForSeconds(2.5f);
        EndLevel();
    }

    private void EndLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    private IEnumerator ShowScreen()
    {
        for (var i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.5f);
            var tmp = screenCover.color;
            tmp.a -= 0.2f;
            screenCover.color = tmp;
        }
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
    }
}