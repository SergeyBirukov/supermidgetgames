using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlebMode : MonoBehaviour
{
    public bool IsGlebMode;
    public static GlebMode Instance;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            Instance.IsGlebMode = false;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void GlebModeSetActive()
    {
        IsGlebMode = !IsGlebMode;
    }
}
