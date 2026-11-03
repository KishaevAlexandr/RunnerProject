using UnityEngine;
// Убираем SceneManagement, так как теперь перезапуск будет через кнопку

public class PlayerHealth : MonoBehaviour
{
    [Header("Настройки здоровья")]
    [SerializeField] private int maxLives = 3;
    private int currentLives;

    [Header("UI")]
    [SerializeField] private GameObject gameOverPanel; // Ссылка на нашу панель

    private void Awake()
    {
        currentLives = maxLives;
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        Debug.Log($"Игрок получил {amount} урона. Осталось жизней: {currentLives}");

        if (currentLives <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentLives += amount;
        if (currentLives > maxLives) currentLives = maxLives;
        Debug.Log($"Игрок восстановил здоровье. Текущее: {currentLives}");
    }

    private void Die()
    {
        Debug.Log("Игрок погиб!");

        // Включаем панель Game Over
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Останавливаем время в игре (чтобы враги/движение замерли)
        Time.timeScale = 0f;
    }
}