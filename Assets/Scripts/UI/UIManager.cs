using System;
using DefaultNamespace;
using UnityEngine;

namespace UI
{
    public class UIManager: MonoBehaviour
    {
        [SerializeField] private GameObject PauseMenu;
        [SerializeField] private GameObject DeathMenu;

        private void Start()
        {
            FindObjectOfType<Player>().onDeath.AddListener(ShowDeathScreen);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && PauseManager.Instance.state == PauseState.Off)
            {
                ShowPauseMenu();
                PauseManager.Instance.PauseOn();
            }
        }

        public void ShowPauseMenu()
        {
            PauseMenu.gameObject.SetActive(true);
        }

        public void ShowDeathScreen()
        {
            PauseManager.Instance.PauseOn();
            DeathMenu.gameObject.SetActive(true);
        }
    }
}