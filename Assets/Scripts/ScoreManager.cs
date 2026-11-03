using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int CurrentScore { get; private set; } = 0;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        CurrentScore = 0;
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        CurrentScore += amount;
        UpdateScoreUI();
        Debug.Log("Очки добавлены! Текущий счет: " + CurrentScore); // Это покажет в консоли, работает ли метод
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Счет: {CurrentScore}";
        }
        else
        {
            Debug.LogError("Текст ScoreText не привязан в Инспекторе!");
        }
    }
}