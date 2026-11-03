using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int CurrentScore { get; private set; } = 0;

    [Header("UI Ссылки")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject winPanel;

    [Header("Настройки")]
    [SerializeField] private int winScore = 40;

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

        if (CurrentScore >= winScore) return;

        CurrentScore += amount;
        UpdateScoreUI();

        if (CurrentScore >= winScore)
        {
            WinGame();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Счет: {CurrentScore}";
        }
    }

    private void WinGame()
    {
        Debug.Log("Победа!");

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}