using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] private int points = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.AddScore(points);
            Destroy(gameObject); // Óםטקעמזאול ןנוהלוע ןמסכו סבמנא
        }
    }
}