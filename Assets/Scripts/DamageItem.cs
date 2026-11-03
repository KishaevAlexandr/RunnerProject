using UnityEngine;

public class DamageItem : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Если в триггер вошел объект с тегом Player
        if (other.CompareTag("Player"))
        {
            // Ищем у него компонент PlayerHealth и вызываем метод TakeDamage
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}