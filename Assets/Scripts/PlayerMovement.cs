using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки движения")]
    [SerializeField] private float moveSpeed = 5f; // Скорость персонажа

    private Rigidbody2D rb; // Ссылка на физическое тело
    private Vector2 moveInput; // Вектор направления движения

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Update вызывается каждый кадр. Здесь мы считываем ввод с клавиатуры.
        float x = Input.GetAxisRaw("Horizontal"); //Стрелки Влево / Вправо
        float y = Input.GetAxisRaw("Vertical");   // Стрелки Вверх / Вниз

        // Формируем вектор, чтобы по диагонали персонаж не двигался быстрее.
        moveInput = new Vector2(x, y).normalized;
    }

    private void FixedUpdate()
    {
        // FixedUpdate вызывается с постоянной частотой (по умолчанию 50 раз в секунду).

        // MovePosition перемещает объект в новую позицию с учетом физики и коллизий.
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}