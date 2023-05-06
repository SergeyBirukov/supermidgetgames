using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Close();
            }
        }

        public void Close()
        {
            PauseManager.Instance.PauseOff();
            gameObject.SetActive(false);
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}