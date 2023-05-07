using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlebMode : MonoBehaviour
{
    public bool IsGlebMode;
    public static GlebMode Instance;
    
    [SerializeField] private Sprite defaultDB;
    [SerializeField] private Sprite glebBg;
    [SerializeField] private Image BG;
    
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

    private void UpdateBackground()
    {
        if (IsGlebMode)
        {
            BG.sprite = glebBg;
        }
        else
        {
            BG.sprite = defaultDB;
        }
    }

    public void GlebModeSetActive()
    {
        IsGlebMode = !IsGlebMode;
        UpdateBackground();
    }
}
