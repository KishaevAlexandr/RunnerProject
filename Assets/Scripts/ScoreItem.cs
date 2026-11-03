using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] private int points = 10;

    // Ссылка на менеджер очков
    [SerializeField] private ScoreManager scoreManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Если ссылка есть, добавляем очки
            if (scoreManager != null)
            {
                scoreManager.AddScore(points);
            }
            else
            {
                Debug.LogWarning("ScoreManager не привязан к ScoreItem!");
            }

            Destroy(gameObject); // Уничтожаем предмет
        }
    }
}