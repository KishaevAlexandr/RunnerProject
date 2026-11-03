using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    [SerializeField] private float boostMultiplier = 2f; // Ускорение в 2 раза
    [SerializeField] private float duration = 3f; // На 3 секунды

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement movement = other.GetComponent<PlayerMovement>();
            if (movement != null)
            {
                movement.ApplySpeedBoost(boostMultiplier, duration);
            }
            Destroy(gameObject);
        }
    }
}