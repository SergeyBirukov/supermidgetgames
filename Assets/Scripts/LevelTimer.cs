using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer: MonoBehaviour
{
    [SerializeField] private float levelTimeInSeconds = 30;
    [SerializeField] private string nextLevelName;

    private void Start()
    {
        StartCoroutine(LevelEndCountdown());
    }

    private IEnumerator LevelEndCountdown()
    {
        yield return new WaitForSeconds(levelTimeInSeconds);
        EndLevel();
    }

    private void EndLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}