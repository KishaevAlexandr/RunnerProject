using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int CurrentScore { get; private set; } = 0;

    public static void AddScore(int amount)
    {
        CurrentScore += amount;
        Debug.Log($"ќчки: {CurrentScore}");
    }

    // —брос счета при перезапуске уровн€
    private void Awake()
    {
        CurrentScore = 0;
    }
}