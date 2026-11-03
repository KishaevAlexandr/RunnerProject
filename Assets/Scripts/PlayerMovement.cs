using UnityEngine;
using UnityEngine.InputSystem; // Обязательно для Gamepad

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки движения")]
    [SerializeField] private float moveSpeed = 5f;

    private float baseSpeed;
    private float speedMultiplier = 1f;
    private float boostTimer;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Сохраняем базовую скорость при старте
        baseSpeed = moveSpeed;
    }

    private void Update()
    {
        //Таймер ускорения
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0)
            {
                speedMultiplier = 1f; // Возвращаем обычную скорость
            }
        }

        // 1. Ввод с клавиатуры 
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 keyboardInput = new Vector2(x, y);

        // 2. Ввод с виртуального джойстика
        Vector2 joystickInput = Vector2.zero;
        if (Gamepad.current != null)
        {
            joystickInput = Gamepad.current.leftStick.ReadValue();
        }

        // 3. Ввод с гироскопа (только на мобильных устройствах)
        Vector2 gyroInput = Vector2.zero;
        if (Application.isMobilePlatform && SystemInfo.supportsGyroscope)
        {
            // Читаем направление из нашего скрипта GyroInput
            gyroInput = GyroInput.GyroDirection;
        }

        // 4. Суммируем все вводы и нормализуем
        moveInput = (keyboardInput + joystickInput + gyroInput).normalized;
    }

    private void FixedUpdate()
    {
        // Движение через физику (добавлен множитель speedMultiplier)
        rb.MovePosition(rb.position + moveInput * (baseSpeed * speedMultiplier) * Time.fixedDeltaTime);
    }

    public void ApplySpeedBoost(float multiplier, float duration)
    {
        speedMultiplier = multiplier;
        boostTimer = duration;
    }
}