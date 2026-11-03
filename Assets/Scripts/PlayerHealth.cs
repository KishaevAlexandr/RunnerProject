using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно для перезапуска сцены

public class PlayerHealth : MonoBehaviour
{
    [Header("Настройки здоровья")]
    [SerializeField] private int maxLives = 3; // Максимальное количество жизней
    private int currentLives;

    // Свойства для чтения из других скриптов
    public int CurrentLives => currentLives;
    public int MaxLives => maxLives;

    private void Awake()
    {
        // При старте игры устанавливаем текущее здоровье равным максимальному
        currentLives = maxLives;
    }

    // Метод для получения урона 
    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        Debug.Log($"Игрок получил {amount} урона. Осталось жизней: {currentLives}");

        // Если жизни закончились — перезапускаем уровень
        if (currentLives <= 0)
        {
            RestartLevel();
        }
    }

    // Метод для восстановления здоровья 
    public void Heal(int amount)
    {
        currentLives += amount;

        // Не позволяем здоровью превысить максимум
        if (currentLives > maxLives)
        {
            currentLives = maxLives;
        }

        Debug.Log($"Игрок восстановил {amount} здоровья. Текущее здоровье: {currentLives}");
    }

    private void RestartLevel()
    {
        Debug.Log("Игрок погиб! Перезапуск уровня...");

        // Загружаем текущую сцену заново 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}