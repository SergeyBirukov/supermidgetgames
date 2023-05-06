using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class DeathScreen: MonoBehaviour
    {
        public void Restart()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}