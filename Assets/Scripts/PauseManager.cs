using UnityEngine;

public class PauseManager: MonoBehaviour
{
    public PauseState state = PauseState.Off;
    public static PauseManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    public void PauseOn()
    {
        state = PauseState.On;
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        state = PauseState.Off;
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}

public enum PauseState
{
    On,
    Off
}