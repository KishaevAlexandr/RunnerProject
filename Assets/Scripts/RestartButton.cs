using UnityEngine;
using UnityEngine.SceneManagement; // Возвращаем для перезагрузки

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        // Возвращаем нормальное течение времени
        Time.timeScale = 1f;

        // Загружаем текущую сцену заново
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}